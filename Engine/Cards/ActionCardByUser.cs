namespace engine_cuban_puzzle;

public class ActionCardByUser : ActionBankCard
{
    public ActionCard_Node Node;
    public ActionCardByUser(string name,ActionCard_Node node) : base(name,node.Color,node.Money,node.Cost,node.Information)
    {
        this.Node = node;
    }
    public override void Action()
    {
        Node.Action.Interpret();
    }
}