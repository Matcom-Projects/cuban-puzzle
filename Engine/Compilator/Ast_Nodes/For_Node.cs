namespace engine_cuban_puzzle;

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