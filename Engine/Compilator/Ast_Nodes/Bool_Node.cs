namespace engine_cuban_puzzle;

public class Bool_Node : AST_Node
{
    public bool Value;
    public Bool_Node(bool value)
    {
        this.Value = value;
    }
}