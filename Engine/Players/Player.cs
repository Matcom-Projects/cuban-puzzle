namespace engine_cuban_puzzle;

public abstract class Player
{
    public string Name{ get; private set; }
    public TablePlayer? Table { get; private set; }

    public Player( string name )
    {
        this.Name = name;
    }

    public abstract void SelectHero();
    public abstract void SelectActionCard();
}

public class ManualPlayer : Player
{
    public ManualPlayer(string name) : base(name)
    {

    }

    public override void SelectActionCard()
    {
        
    }

    public override void SelectHero()
    {
        
    }
}
