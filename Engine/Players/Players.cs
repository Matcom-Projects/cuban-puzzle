namespace engine_cuban_puzzle;

public class ManualPlayer : IPlayer
{
    public string Name { get; }
    public TablePlayer Table { get; set; }

    public ManualPlayer ( string name ) 
    {
        this.Name = name;
        this.Table=new TablePlayer();
    }

    public int SelectActionCard()
    {
        return 0;
    }

    public int SelectHero()
    {
        return 0;
    }

    public void PlayActionPhase()
    {
        
    }

    public void PlayBuyPhase()
    {
        
    }

    public void PlayCleanUpPhase()
    {
        
    }
}
