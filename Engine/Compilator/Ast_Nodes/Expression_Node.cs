namespace engine_cuban_puzzle;

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