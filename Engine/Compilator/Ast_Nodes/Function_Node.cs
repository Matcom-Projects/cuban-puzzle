namespace engine_cuban_puzzle;

public class Function_Node : AST_Node
{
    public Type Function;
    public Type TypeReturn;
    public List<Expression_Node> Pass;

    public Function_Node(Type function,Type typereturn,List<Expression_Node> pass)
    {
        this.Function = function;
        this.TypeReturn = typereturn;
        this.Pass = pass;
    }
}