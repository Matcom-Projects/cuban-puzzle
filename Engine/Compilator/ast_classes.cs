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

public class Conditional_Node : AST_Node
{
    public AST_Node WhenTrue;
    public AST_Node WhenFalse;
    public AST_Node Condition;
    public Conditional_Node(AST_Node condition,AST_Node whentrue,AST_Node whenfalse)
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
    public string Value;
    public Var_Node(Token id)
    {
        this.token = id;
        this.Value = id.Value;
    }
}

public class Function_Node : AST_Node
{
    public Type Function;
    public Type TypeReturn;
    public List<AST_Node> Pass;

    public Function_Node(Type function,Type typereturn,List<AST_Node> pass)
    {
        this.Function = function;
        this.TypeReturn = typereturn;
        this.Pass = pass;
    }
}

public class Expression_Node : AST_Node
{
    public Type TypeReturn;
    public AST_Node Expression;
    public Expression_Node(Type typereturn , AST_Node expression)
    {
        this.TypeReturn = typereturn;
        this.Expression = expression;
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

public class For_Node : AST_Node
{
    public AST_Node Times;
    public AST_Node Execute;
    public For_Node(AST_Node times,AST_Node execute)
    {
        this.Times = times;
        this.Execute = execute;
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
