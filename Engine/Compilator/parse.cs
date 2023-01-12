namespace engine_cuban_puzzle;

public class Parse
{
    public Lexer Lexer;
    private Token Current_Token;
    private Dictionary<string,Type> PrivateScope;
    public Parse(Lexer lexxer)
    {
        this.Lexer = lexxer;
        this.Current_Token = lexxer.Get_Next_Token();
        this.PrivateScope = new Dictionary<string, Type>();
    }
    public void Eat(Type token_type)
    {
        if(Current_Token.Type == token_type) Current_Token = Lexer.Get_Next_Token();
        else throw new Exception("Se esperaba un " + token_type);
    }

    public Expression_Node Factor()
    {
        Token token = Current_Token;
        if(token.Type == Type.Sum || token.Type == Type.Rest)
        {
            Eat(token.Type);
            return new Expression_Node(Type.Int,new UnaryOperation_Node(token,Factor()));
        }
        else if(token.Type == Type.Int)
        {
            Eat(Type.Int);
            return new Expression_Node(Type.Int,new Num_Node(int.Parse(token.Value)));
        }
        else if (token.Type == Type.Me)
        {
            Eat(Type.Me);
            return new Expression_Node(Type.iPlayer,new Player_Node(GameEngine.Turns.Current));
        }
        else if (token.Type == Type.LParen)
        {
            Eat(Type.LParen);
            Expression_Node result = Exp();
            Eat(Type.RParen);
            return result;
        }
        else if (token.Type == Type.True)
        {
            Eat(Type.True);
            return new Expression_Node(Type.Boolean,new Bool_Node(true));
        }
        else if (token.Type == Type.False)
        {
            Eat(Type.False);
            return new Expression_Node(Type.Boolean,new Bool_Node(false));
        }
        else if(token.Type == Type.selectplayer||token.Type == Type.getrandomplayer)
        {
            Function_Node node = Function_statement(Type.selectplayer,new Type[0],Type.iPlayer);
            return new Expression_Node(Type.iPlayer,node);
        }
        else if ( token.Type == Type.selectcardongoing || token.Type == Type.selectcardhand || token.Type == Type.selectcarddeck
        || token.Type == Type.selectcarddiscardpile || token.Type == Type.selectgem || token.Type == Type.round
        || token.Type == Type.cantgem || token.Type == Type.getrandomcard )
        {
            Function_Node node = Function_statement(token.Type,new Type[0],Type.Int);
            return new Expression_Node(Type.Int,node);
        }
        else if (token.Type == Type.selectcardbank)
        {
            Function_Node node = Function_statement(Type.selectcardbank,new Type[0],Type.BCard);
            return new Expression_Node(Type.BCard,node);
        }
        else if (token.Type == Type.deck||token.Type == Type.hand||token.Type == Type.discardpile
        ||token.Type == Type.ongoing || token.Type == Type.gempile )
        {
            Eat(token.Type);
            return new Expression_Node(Type.list,new List_Node(token.Type));
        }
        else if (token.Type == Type.selectcard||token.Type == Type.selectbcard)
        {
            Function_Node result = Function_statement(token.Type,new Type[]{Type.list},Type.Int);
            return new Expression_Node(Type.Int,result);
        }
        else if (token.Type == Type.gem1)
        {
            Eat(Type.gem1);
            return new Expression_Node(Type.BCard,new BankCard_Node(GameEngine.bank.keys[0]));
        }
        else if (token.Type == Type.gem2)
        {
            Eat(Type.gem2);
            return new Expression_Node(Type.BCard,new BankCard_Node(GameEngine.bank.keys[1]));
        }
        else if (token.Type == Type.gem3)
        {
            Eat(Type.gem3);
            return new Expression_Node(Type.BCard,new BankCard_Node(GameEngine.bank.keys[2]));
        }
        else if (token.Type == Type.gem4)
        {
            Eat(Type.gem4);
            return new Expression_Node(Type.BCard,new BankCard_Node(GameEngine.bank.keys[3]));
        }
        else if (token.Type == Type.cup)
        {
            Eat(Type.cup);
            return new Expression_Node(Type.BCard,new BankCard_Node(GameEngine.bank.keys[7]));
        }
        else if (token.Type == Type.crashgem)
        {
            Eat(Type.crashgem);
            return new Expression_Node(Type.BCard,new BankCard_Node(GameEngine.bank.keys[4]));
        }
        else if (token.Type == Type.doblecrashgem)
        {
            Eat(Type.doblecrashgem);
            return new Expression_Node(Type.BCard,new BankCard_Node(GameEngine.bank.keys[5]));
        }
        else if (token.Type == Type.combine)
        {
            Eat(Type.combine);
            return new Expression_Node(Type.BCard,new BankCard_Node(GameEngine.bank.keys[6]));
        }
        else if (token.Type == Type.ID)
        {
            Eat(Type.ID);
            if(!PrivateScope.ContainsKey(token.Value)) throw new Exception("esta instancia no existe");
            return new Expression_Node(PrivateScope[token.Value],new Var_Node(token,PrivateScope[token.Value]));
        }


        throw new Exception("Sintaxis error");
    }

    public Expression_Node Term()
    {
        Expression_Node result = Factor();

        if(Current_Token.Type == Type.Mult || Current_Token.Type == Type.Div)
        {
            while( Current_Token.Type == Type.Mult || Current_Token.Type == Type.Div ) 
            {
                Token token = Current_Token;

                if (token.Type == Type.Mult)
                { 
                    Eat(Type.Mult);
                }
                else if (token.Type == Type.Div)
                {
                    Eat(Type.Div);
                }
                Expression_Node right = Factor();
                if(result.TypeReturn != Type.Int || right.TypeReturn != Type.Int) throw new Exception("no se pueden multiplicar dos cosas q no sean numeros.");
                result = new Expression_Node(Type.Int,new BinaryOperation_Node(result,token.Type,right,Type.Int));
            }
        }
        else if ( Current_Token.Type == Type.MinorEqual || Current_Token.Type == Type.GreaterEqual 
        || Current_Token.Type == Type.Greater  ||  Current_Token.Type == Type.Minor )
        {
            Token token = Current_Token;
            Eat(token.Type);
            Expression_Node right = Factor();
            if(result.TypeReturn != Type.Int || right.TypeReturn != Type.Int) throw new Exception("no se puede comparar 2 cosas q no sean numeros");
            return new Expression_Node(Type.Boolean,new BinaryOperation_Node(result,token.Type,right,Type.Boolean));
        }
        else if (Current_Token.Type == Type.EqualEqual || Current_Token.Type == Type.Different)
        {
            Token token = Current_Token;
            Eat(token.Type);
            Expression_Node right = Factor();
            if(result.TypeReturn != right.TypeReturn) throw new Exception("no se puede comparar 2 types distintos");
            return new Expression_Node(Type.Boolean,new BinaryOperation_Node(result,token.Type,right,Type.Boolean));
        }
        else if(Current_Token.Type == Type.DOT )
        {
            Eat(Type.DOT);
            if(result.TypeReturn != Type.iPlayer) throw new Exception("no hace la referencia correcta");
            Expression_Node right = Factor();
            if(right.TypeReturn == Type.list)
            {
                return new Expression_Node(Type.list,new DotReference_Node(result,right));
            }
            if (right.Expression is Function_Node)
            {
                if(((Function_Node)right.Expression).Function == Type.cantgem)
                {
                    return new Expression_Node(Type.Int,new DotReference_Node(result,right));
                }
            }
            throw new Exception("no hace referencia a nada");
        }

        return result;
    }

    public Expression_Node Exp()
    {
        Expression_Node result = Term();
        if(Current_Token.Type == Type.Sum||Current_Token.Type == Type.Rest)
        {
            while( Current_Token.Type == Type.Sum || Current_Token.Type == Type.Rest ) 
            {
                Token token = Current_Token;

                if (token.Type == Type.Sum)
                { 
                    Eat(Type.Sum);
                }
                else if (token.Type == Type.Rest)
                {
                    Eat(Type.Rest);
                }

                Expression_Node right = Term();
                if(result.TypeReturn!=Type.Int || right.TypeReturn != Type.Int) throw new Exception("no se pueden sumar cosas q no sean numeros.");
                result = new Expression_Node(Type.Int,new BinaryOperation_Node(result,token.Type,right,Type.Int));
            }
        }
        else if (Current_Token.Type == Type.And || Current_Token.Type == Type.Or)
        {
            Token token = Current_Token;
            Eat(token.Type);

            Expression_Node right = Term();

            if(result.TypeReturn != Type.Boolean || right.TypeReturn != Type.Boolean) throw new Exception("no puedes evaluar una manzana con una pera.");

            return new Expression_Node(Type.Boolean,new BinaryOperation_Node(result,token.Type,right,Type.Boolean));
        }

        return result;
    }
    public Compound_Node Parsing()
    {
        Compound_Node result = Compound_statement();
        if(Current_Token.Type != Type.EOF) throw new Exception("aqui paso algo");

        return result;
    }

    public Compound_Node Compound_statement()
    {
        Eat(Type.LBrace);
        List<AST_Node> nodes = Statement_list();
        Eat(Type.RBrace);

        Compound_Node root = new Compound_Node();

        foreach (AST_Node node in nodes)
        {
            root.Children.Add(node);
        }

        return root;
    }

    public List<AST_Node> Statement_list()
    {
        List<AST_Node> result = new List<AST_Node>();

        result.Add(Statement());
        while(Current_Token.Type == Type.Semi)
        {
            Eat(Type.Semi);
            result.Add(Statement());
        }
        if(Current_Token.Type == Type.ID) throw new Exception("y esto q cosa es");
        return result;
    }

    public AST_Node Statement()
    {
        if(Current_Token.Type == Type.LBrace)
        {
            return Compound_statement();
        }
        else if (Current_Token.Type == Type.ID)
        {
            return Assignment_statement();
        }
        else if (Current_Token.Type == Type.If)
        {
            return Conditional_statement();
        }
        else if (Current_Token.Type == Type.For)
        {
            return For_statement();
        }
        else if (Current_Token.Type == Type.move)
        {
            return Function_statement(Type.move,new Type[]{Type.list,Type.list,Type.Int},Type.Void);
        }
        else if (Current_Token.Type == Type.giveactions)
        {
            return Function_statement(Type.giveactions,new Type[]{Type.Int},Type.Void);
        }
        else if (Current_Token.Type == Type.givemoney)
        {
            return Function_statement(Type.givemoney,new Type[]{Type.Int},Type.Void);
        }
        else if (Current_Token.Type == Type.draw)
        {
            return Function_statement(Type.draw,new Type[]{Type.Int},Type.Void);
        }
        else if (Current_Token.Type == Type.savecards)
        {
            return Function_statement(Type.savecards,new Type[]{Type.Int},Type.Void);
        }
        else if (Current_Token.Type == Type.trash)
        {
            return Function_statement(Type.trash,new Type[]{Type.Int,Type.list},Type.Void);
        }
        else if (Current_Token.Type == Type.attack)
        {
            return Function_statement(Type.attack,new Type[]{Type.iPlayer,Type.Int},Type.Void);
        }
        else if (Current_Token.Type == Type.gaincard)
        {
            return Function_statement(Type.gaincard,new Type[]{Type.iPlayer,Type.BCard},Type.Void);
        }
        else if (Current_Token.Type == Type.sacrifice)
        {
            return Function_statement(Type.sacrifice,new Type[]{Type.iPlayer,Type.Int},Type.Void);
        }
        else if (Current_Token.Type == Type.revive)
        {
            return Function_statement(Type.revive,new Type[]{Type.iPlayer,Type.Int},Type.Void);
        }
        else if (Current_Token.Type == Type.overtaking)
        {
            return Function_statement(Type.overtaking,new Type[]{Type.iPlayer,Type.Int},Type.Void);
        }

        return new NoOp_Node();
    }
    public Conditional_Node Conditional_statement()
    {
        Eat(Type.If);
        Eat(Type.RBracket);
        Expression_Node condition = Exp();
        Eat(Type.LBracket);
        Compound_Node whentrue = Compound_statement();
        if(Current_Token.Type == Type.Else) return new Conditional_Node(condition,whentrue,Compound_statement());
        return new Conditional_Node(condition,whentrue,new Compound_Node());
    }

    public Function_Node Function_statement(Type functiontype,Type[] TypeRecive,Type TypeReturn)
    {
        Eat(functiontype);
        Eat(Type.RBracket);
        List<Expression_Node> pass = new List<Expression_Node>();

        if(TypeRecive.Length == 0)
        {
            Eat(Type.LBracket); 
            return new Function_Node(functiontype,TypeReturn,new List<Expression_Node>());
        }

        for(int i =0 ; i < TypeRecive.Length;i++)
        {
            Expression_Node exp = Exp();

            if(functiontype == Type.move && exp.TypeReturn == Type.list && TypeRecive[i] == Type.list)
            {
                if(IsGemPileList(exp)) throw new Exception("no se pueden hacer movimientos con la lista gempile");
            }
            else if(exp.TypeReturn != TypeRecive[i]) throw new Exception("Se esperaba un elemento de tipo"+TypeRecive[i]);

            pass.Add(exp);

            if(i == TypeRecive.Length-1) break;

            Eat(Type.Comma);
        }
        Eat(Type.LBracket);
        return new Function_Node(functiontype,TypeReturn,pass);
    }

    private bool IsGemPileList(Expression_Node node)
    {

        if(node.Expression is DotReference_Node)
        {
            DotReference_Node auxnode = (DotReference_Node)node.Expression;

            if(auxnode.Reference.Expression is List_Node)
            {
                List_Node listnode = (List_Node)auxnode.Reference.Expression;
                if(listnode.List == Type.gempile)
                {
                    return true;
                }
                return false;
            }
            throw new Exception("aqui deberia haber una lista");
        }

        throw new Exception("aqui deberia haber un dotreference");
    }

    public ASSIGN_Node Assignment_statement()
    {
        Var_Node left = Variable();
        Eat(Type.Assign);
        Expression_Node right = Exp();
        if(right.TypeReturn == Type.list) throw new Exception("no se pueden asignar listas a variables");
        PrivateScope.Add(left.Value,right.TypeReturn);
        left.Type = right.TypeReturn;
        PrivateScope[left.Value] = right.TypeReturn;
        return new ASSIGN_Node(left,right);
    }

    public For_Node For_statement()
    {
        Eat(Type.For);
        Eat(Type.RBracket);
        Expression_Node times = Exp();
        Eat(Type.LBracket);
        return new For_Node(times,Compound_statement());
    }

    public Var_Node Variable()
    {
        Eat(Type.ID);
        return new Var_Node(Current_Token,Type.Var);
    }
}
// tengo dudas si pincha correctamente la deteccion de errores a la hora de crear variables...
//IMPORTANTE!!!
//IMPORTANTE!!!
//IMPORTANTE!!!
//IMPORTANTE!!!