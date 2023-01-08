namespace engine_cuban_puzzle;

public class Token
{
    public Type Type;
    public string Value;
    public Token(Type type, string value)
    {
        this.Type = type;
        this.Value = value;
    }
}