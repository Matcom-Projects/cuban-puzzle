namespace engine_cuban_puzzle;

public class Compound_Node : AST_Node
{
    public List<AST_Node> Children;
    public Compound_Node()
    {
        this.Children=new List<AST_Node>();
    }
}