namespace engine_cuban_puzzle;

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