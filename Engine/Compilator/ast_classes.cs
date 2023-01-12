namespace engine_cuban_puzzle;

public class BinaryOperation_Node : AST_Node
{
    public Expression_Node Left;
    public Type Operation;
    public Type TypeReturn;
    public Expression_Node Right;
    public BinaryOperation_Node (Expression_Node left, Type op, Expression_Node right,Type typereturn)
    {
        this.TypeReturn = typereturn;
        this.Left = left;
        this.Operation = op;
        this.Right = right;
    }
}

public class UnaryOperation_Node : AST_Node
{
    public Expression_Node Node;
    public Token Operation;
    public UnaryOperation_Node (Token op,Expression_Node node)
    {
        this.Operation = op;
        this.Node = node;
    }
}

public class Num_Node : AST_Node
{
    public int Value;
    public Num_Node(int value)
    {
        
        this.Value = value;
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
    public bool Value;
    public Bool_Node(bool value)
    {
        this.Value = value;
    }
}

public class Conditional_Node : AST_Node
{
    public Compound_Node WhenTrue;
    public Compound_Node WhenFalse;
    public Expression_Node Condition;
    public Conditional_Node(Expression_Node condition,Compound_Node whentrue,Compound_Node whenfalse)
    {
        this.WhenTrue = whentrue;
        this.WhenFalse = whenfalse;
        this.Condition = condition;
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
    public Type Type;
    public Token token;
    public string Value;
    public Var_Node(Token id,Type type)
    {
        this.token = id;
        this.Value = id.Value;
        this.Type = type;
    }
}

public class Function_Node : AST_Node
{
    public Type Function;
    public Type TypeReturn;
    public List<Expression_Node> Pass;

    public Function_Node(Type function,Type typereturn,List<Expression_Node> pass)
    {
        this.Function = function;
        this.TypeReturn = typereturn;
        this.Pass = pass;
    }
}

public class BankCard_Node : AST_Node
{
    public  BankCard Card;
    public BankCard_Node(BankCard card)
    {
        this.Card = card;
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
    public Expression_Node User;
    public Expression_Node Reference;
    public DotReference_Node(Expression_Node user,Expression_Node reference)
    {
        this.User = user;
        this.Reference = reference;
    }
}

public class List_Node : AST_Node
{
    public Type List;

    public List_Node(Type list)
    {
        this.List = list;
    }
}

public class For_Node : AST_Node
{
    public Expression_Node Times;
    public Compound_Node Execute;
    public For_Node(Expression_Node times,Compound_Node execute)
    {
        this.Times = times;
        this.Execute = execute;
    }
}

public class ASSIGN_Node : AST_Node
{
    public Var_Node Variable;
    public Expression_Node Value;
    public ASSIGN_Node(Var_Node variable,Expression_Node value)
    {
        this.Variable = variable;
        this.Value = value;
    }
}
public class NoOp_Node : AST_Node
{
    public NoOp_Node(){}
}
