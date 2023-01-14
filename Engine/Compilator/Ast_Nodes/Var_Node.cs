namespace engine_cuban_puzzle;

public class Var_Node : AST_Node
{
    public Type Type;
    public Token token;
    public string Value;
    public Var_Node(Token id,Type type)
    {
        this.token = id;
        this.Value = id.Value;
        this.Type = type;
    }
}