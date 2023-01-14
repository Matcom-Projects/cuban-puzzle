namespace engine_cuban_puzzle;

public class HeroCardByUser : ActionCard
{
    public HeroCard_Node Node;
    public HeroCardByUser(string name,HeroCard_Node node) : base(name,node.Color,node.Money,node.Information)
    {
        this.Node = node;
    }
    public override void Action()
    {
        Node.Action.Interpret();
    }
}