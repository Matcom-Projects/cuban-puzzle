namespace engine_cuban_puzzle;

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