namespace engine_cuban_puzzle;

public class Parse
{
    public Lexer Lexer;
    private Token Current_Token;
    public Parse(Lexer lexxer)
    {
        this.Lexer = lexxer;
        this.Current_Token = lexxer.Get_Next_Token();
    }
    public void Eat(Type token_type)
    {
        if(Current_Token.Type == token_type) Current_Token = Lexer.Get_Next_Token();
        else throw new Exception("Se esperaba un " + token_type);
    }

    public AST_Node Factor()
    {
        Token token = Current_Token;
        if(token.Type == Type.Sum)
        {
            Eat(Type.Sum);
            return new UnaryOperation_Node(token,Factor());
        }
        else if(token.Type == Type.Rest)
        {
            Eat(Type.Rest);
            return new UnaryOperation_Node(token,Factor());
        }
        else if(token.Type == Type.Int)
        {
            Eat(Type.Int);
            return new Num_Node(token);
        }
        else if (token.Type == Type.LParen)
        {
            Eat(Type.LParen);
            AST_Node result = Exp();
            Eat(Type.RParen);
            return result;
        }
        else
        {
            return Variable();
        }

        throw new Exception("Sintaxis error");
    }

    public AST_Node Term()
    {
        AST_Node result = Factor();

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
            result = new BinaryOperation_Node(result,token,Factor(),Type.Int);
        }

        return result;
    }

    public AST_Node Exp()
    {
        AST_Node result = Term();

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

            result = new BinaryOperation_Node(result,token,Term(),Type.Int);
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
        while(Current_Token.Type==Type.Semi)
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

        return new NoOp_Node();
    }
    public AST_Node Assignment_statement()
    {
        Var_Node left = Variable();
        Token token = Current_Token;
        Eat(Type.Assign);
        AST_Node right = Exp();

        return new ASSIGN_Node(left,token,right);
    }

    public Var_Node Variable()
    {
        Var_Node node = new Var_Node(Current_Token,Type.Int);
        Eat(Type.ID);
        return node;
    }
}
