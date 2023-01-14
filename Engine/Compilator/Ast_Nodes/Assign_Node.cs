namespace engine_cuban_puzzle;

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