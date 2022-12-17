namespace engine_cuban_puzzle;

public abstract class Card
{
    public string Name{get;private set;}
    public string[] Color{get;private set;}
    public int Money{get;private set;}
    public Card(string name,string[]color,int money)
    {
        this.Name = name;
        this.Color = color;
        this.Money = money;
    }
}
