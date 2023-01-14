namespace engine_cuban_puzzle;

public class List_Node : AST_Node
{
    public Type List;

    public List_Node(Type list)
    {
        this.List = list;
    }
}