namespace engine_cuban_puzzle;

public abstract class Card
{
    public string Id{ get; private set; }
    public string Name{get;private set;}
    public string[] Color{get;private set;}
    public int Money{get;private set;}
    public Card(string name,string[]color,int money)
    {
        this.Id = GameUtils.CreateId();
        this.Name = name;
        this.Color = color;
        this.Money = money;
    }
}

public static class CreateCards
{
    public static List<ICostable>? AllActionsCard;
    public static List<Card>? AllHeroCards;
}