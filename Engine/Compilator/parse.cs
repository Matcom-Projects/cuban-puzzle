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
        if(token.Type == Type.Sum)
        {
            Eat(Type.Sum);
            return new Expression_Node(Type.Int,new UnaryOperation_Node(token,Factor()));
        }
        else if(token.Type == Type.Rest)
        {
            Eat(Type.Rest);
            return new Expression_Node(Type.Int,new UnaryOperation_Node(token,Factor()));
        }
        else if(token.Type == Type.Int)
        {
            Eat(Type.Int);
            return new Expression_Node(Type.Int,new Num_Node(token));
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
            return new Expression_Node(Type.Boolean,new Bool_Node(token));
        }
        else if (token.Type == Type.False)
        {
            Eat(Type.False);
            return new Expression_Node(Type.Boolean,new Bool_Node(token));
        }
        else
        {
            return Variable();
        }

        throw new Exception("Sintaxis error");
    }

    public Expression_Node Term()
    {
        Expression_Node result = Factor();

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
            result = new Expression_Node(Type.Int,new BinaryOperation_Node(result,token,right,Type.Int));
        }

        return result;
    }

    public Expression_Node Exp()
    {
        Expression_Node result = Term();

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
            result = new Expression_Node(Type.Int,new BinaryOperation_Node(result,token,Term(),Type.Int));
        }

        return result;
    }
    public AST_Node Parsing()
    {
        AST_Node result = Compound_statement();
        if(Current_Token.Type != Type.EOF) throw new Exception("aqui paso algo");

        return result;
    }

    public AST_Node Compound_statement()
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
            return Function_statement(Type.move,3);
        }
        else if (Current_Token.Type == Type.giveactions)
        {
            return Function_statement(Type.giveactions,1);
        }
        else if (Current_Token.Type == Type.givemoney)
        {
            return Function_statement(Type.givemoney,1);
        }
        else if (Current_Token.Type == Type.draw)
        {
            return Function_statement(Type.draw,1);
        }
        else if (Current_Token.Type == Type.savecards)
        {
            return Function_statement(Type.savecards,1);
        }
        else if (Current_Token.Type == Type.trash)
        {
            return Function_statement(Type.trash,2);
        }
        else if (Current_Token.Type == Type.attack)
        {
            return Function_statement(Type.attack,3);
        }
        else if (Current_Token.Type == Type.gaincard)
        {
            return Function_statement(Type.gaincard,2);
        }
        else if (Current_Token.Type == Type.sacrifice)
        {
            return Function_statement(Type.sacrifice,2);
        }
        else if (Current_Token.Type == Type.revive)
        {
            return Function_statement(Type.revive,2);
        }
        else if (Current_Token.Type == Type.overtaking)
        {
            return Function_statement(Type.overtaking,2);
        }

        return new NoOp_Node();
    }
    public AST_Node Conditional_statement()
    {
        Eat(Type.If);
        AST_Node condition = Exp();
        AST_Node whentrue = Compound_statement();
        if(Current_Token.Type == Type.Else) return new Conditional_Node(condition,whentrue,Compound_statement());
        return new Conditional_Node(condition,whentrue,new NoOp_Node());
    }

    public AST_Node Function_statement(Type functiontype,int cantexp)
    {
        Eat(functiontype);
        List<AST_Node> pass = new List<AST_Node>();

        if(cantexp == 0) return new Function_Node(functiontype,Type.Void,new List<AST_Node>());

        while(true)
        {
            pass.Add(Exp());
            cantexp--;
            if(cantexp == 0) break;
            Eat(Type.Comma);
        }

        return new Function_Node(functiontype,Type.Void,pass);
    }

    public AST_Node Assignment_statement()
    {
        Expression_Node left = Variable();
        Var_Node Var = (Var_Node)left.Expression;
        Token token = Current_Token;
        Eat(Type.Assign);
        Expression_Node right = Exp();

        if(Var.token.Type == Type.Var) 
        {
            PrivateScope.Add(Var.Value,right.TypeReturn);
        }

        left.TypeReturn = right.TypeReturn;
        PrivateScope[Var.Value] = right.TypeReturn;
        
        return new ASSIGN_Node((Var_Node)left.Expression,token,right);
    }

    public AST_Node For_statement()
    {
        Eat(Type.For);
        AST_Node times = Exp();
        return new For_Node(times,Compound_statement());
    }

    public Expression_Node Variable()
    {
        Var_Node Var = new Var_Node(Current_Token);
        Eat(Type.ID);

        if(PrivateScope.ContainsKey(Var.Value)) return new Expression_Node(PrivateScope[Var.Value],Var);
        return new Expression_Node(Type.Var,Var);
    }
}
