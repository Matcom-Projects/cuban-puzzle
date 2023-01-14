namespace engine_cuban_puzzle;

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