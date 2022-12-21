namespace engine_cuban_puzzle;

public interface ICostable
{
    public int Cost{ get; }
}

public interface IPlayer
{
    public string Name { get; }
    public TablePlayer Table { get; set; }
    
    public int SelectHero();
    public int SelectActionCard(List<ICostable> a);
    public void PlayActionPhase();
    public void PlayBuyPhase();
    public void PlayCleanUpPhase();
}