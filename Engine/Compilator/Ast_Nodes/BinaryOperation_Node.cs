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