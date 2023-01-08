namespace engine_cuban_puzzle;

public class Interpreter
{
    public Parse Parser;
    public Dictionary<string,int> Global_Scope;
    public Interpreter(Parse parser)
    {
        this.Parser = parser;
        this.Global_Scope = new Dictionary<string, int>();
    }

    public int Visit(AST_Node node)
    {
        if(node is UnaryOperation_Node) return Visit_UnaryOperation((UnaryOperation_Node) node);
        else if(node is BinaryOperation_Node) return Visit_BinaryOperatior((BinaryOperation_Node) node);
        else if(node is Num_Node) return Visit_Num((Num_Node) node);
        else if(node is Compound_Node) return Visit_Compound((Compound_Node) node);
        else if(node is ASSIGN_Node) return Visit_Assignment((ASSIGN_Node) node);
        else if(node is Var_Node) return Visit_Var((Var_Node) node);
        else if(node is NoOp_Node) return Visit_NoOp((NoOp_Node)node) ;
        else throw new Exception("Introduzca una operacion valida");
    }

    private int Visit_UnaryOperation(UnaryOperation_Node Unar_op)
    {
        if(Unar_op.Operation.Type == Type.Sum)
        {
            return +Visit(Unar_op.Node);
        }
        else if(Unar_op.Operation.Type == Type.Rest)
        {
            return -Visit(Unar_op.Node);
        }
        throw new Exception("sintaxis error");
    }

    private int Visit_BinaryOperatior(BinaryOperation_Node Bin_op)
    {
        if(Bin_op.Operation.Type == Type.Sum)
        {
            return Visit(Bin_op.Left) + Visit(Bin_op.Right);
        }
        else if(Bin_op.Operation.Type == Type.Rest)
        {
            return Visit(Bin_op.Left) - Visit(Bin_op.Right);
        }
        else if(Bin_op.Operation.Type == Type.Mult)
        {
            return Visit(Bin_op.Left) * Visit(Bin_op.Right);
        }
        else if(Bin_op.Operation.Type == Type.Div)
        {
            return Visit(Bin_op.Left) / Visit(Bin_op.Right);
        }
        System.Console.WriteLine(Bin_op.Operation.Value);
        throw new Exception("Sintaxis error");
    }

    private int Visit_Num(Num_Node Number)
    {
        return Number.Value;
    }

    public int Interpret()
    {
        AST_Node root = Parser.Parsing();
        return Visit(root);
    }

    public int Visit_Compound(Compound_Node node)
    {
        foreach(AST_Node child in node.Children )
        {
            Visit(child);
        }
        return 0;
    }

    public int Visit_Assignment(ASSIGN_Node node)
    {
        string var_name = node.Left.Value;
        Global_Scope.Add(var_name,Visit(node.Right));
        return Visit(node.Right);
    }

    public int Visit_Var(Var_Node node)
    {
        return Global_Scope[node.Value];
    }

    public int Visit_NoOp(NoOp_Node node){return 0;}

}