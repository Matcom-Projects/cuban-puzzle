namespace engine_cuban_puzzle;

public class BinaryOperation_Node : AST_Node
{
    public AST_Node Left;
    public Token Operation;
    public Type TypeReturn;
    public AST_Node Right;
    public BinaryOperation_Node (AST_Node left, Token op, AST_Node right,Type typereturn)
    {
        this.TypeReturn = typereturn;
        this.Left = left;
        this.Operation = op;
        this.Right = right;
    }
}

public class UnaryOperation_Node : AST_Node
{
    public AST_Node Node;
    public Token Operation;
    public UnaryOperation_Node (Token op,AST_Node node)
    {
        this.Operation = op;
        this.Node = node;
    }
}

public class Num_Node : AST_Node
{
    public Token Token;
    public int Value;
    public Num_Node(Token token)
    {
        this.Token = token;
        this.Value = int.Parse(token.Value);
    }
}

public class Player_Node : AST_Node
{
    public IPlayer Player;
    public Player_Node(IPlayer player)
    {
        this.Player = player;
    }
}

public class Bool_Node : AST_Node
{
    public Token Token;
    public bool Value;
    public Bool_Node(Token token)
    {
        this.Token = token;
        if(token.Value=="true") this.Value = true;
        else this.Value = false;
    }
}

public class Conditional_Node
{
    public Compound_Node WhenTrue;
    public Compound_Node WhenFalse;
    public BinaryOperation_Node Condition;
    public Conditional_Node(BinaryOperation_Node condition,Compound_Node whentrue,Compound_Node whenfalse)
    {
        this.WhenTrue = whentrue;
        this.WhenFalse = whenfalse;
        this.Condition = condition;
    }
}

public abstract class AST_Node
{
    public AST_Node()
    {

    }
}

public class Compound_Node : AST_Node
{
    public List<AST_Node> Children;
    public Compound_Node()
    {
        this.Children=new List<AST_Node>();
    }
}

public class Var_Node : AST_Node
{
    public Token token;
    public Type Type;
    public string Value;
    public Var_Node(Token id,Type type)
    {
        this.Type = type;
        this.token = id;
        this.Value = id.Value;
    }
}

public class VarDeclaring_Node : AST_Node
{
    public Type typeResult;
    public Var_Node Left;
    public Token Op;
    public AST_Node Right;

    public VarDeclaring_Node(Type type,Var_Node left,Token op,AST_Node right)
    {
        this.typeResult = type;
        this.Left = left;
        this.Op = op;
        this.Right = right;
    }

}

public class Function_Node : AST_Node
{
    public Token Function;
    public Type TypeReturn;

    public Function_Node(Token function,Type typereturn)
    {
        this.Function = function;
        this.TypeReturn = typereturn;
    }
}

public class DotReference_Node : AST_Node
{
    public Token User;
    public Token Reference;
    public DotReference_Node(Token user,Token reference)
    {
        this.User = user;
        this.Reference = reference;
    }
}

public class ASSIGN_Node : AST_Node
{
    public Var_Node Left;
    public Token Op;
    public AST_Node Right;
    public ASSIGN_Node(Var_Node left,Token op,AST_Node right)
    {
        this.Left = left;
        this.Op = op;
        this.Right = right;
    }
}
public class NoOp_Node : AST_Node
{
    public NoOp_Node(){}
}
