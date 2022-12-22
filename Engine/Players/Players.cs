namespace engine_cuban_puzzle;

public class ManualPlayer : IPlayer
{
    public string Name { get; }
    public TablePlayer Table { get; set; }

    public ManualPlayer ( string name ) 
    {
        this.Name = name;
        this.Table = new TablePlayer();
    }

    public int SelectActionCard(List<ICostable> ActionsCards)
    {
        return int.Parse(Console.ReadLine());
    }

    public int SelectHero(List<Card> HeroCards)
    {
        return int.Parse(Console.ReadLine());
    }

    public void PlayActionPhase()
    {
        
    }

    public ICostable PlayBuyPhase()
    {
        return null;
    }
}
