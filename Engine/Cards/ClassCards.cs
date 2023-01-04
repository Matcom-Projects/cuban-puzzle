namespace engine_cuban_puzzle;
using System.Collections.Generic;

public abstract class Card
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Color { get; private set; }
    public int Money { get; set; }
    public Card ( string name,string color,int money )
    {
        this.Id = GameUtils.CreateId();
        this.Name = name;
        this.Color = color;
        this.Money = money;
    }
}
public abstract class BankCard : Card
{
    public int Cost{ get; private set; }
    
    public BankCard ( string name,string color,int money ,int cost): base (name,color,money)
    {
        this.Cost = cost;
    }
}

public abstract class ActionCard : Card,IActionable
{
    public ActionCard(string name, string color, int money): base( name , color , money ){}
    public abstract void Action();
}

public abstract class ActionBankCard : BankCard,IActionable
{
    public ActionBankCard(string name, string color, int money,int cost) : base( name , color , money , cost ){}

    public abstract void Action();
}
public static class CreateCards
{
    public static List<BankCard>? AllActionsCard;
    public static List<Card>? AllHeroCards;
    public static List<Card> ListHeroeByUser = new List<Card>();
    public static List<BankCard> ListActionCardByUser = new List<BankCard>();
    public static List<BankCard> ListBankCardByUser = new List<BankCard>();
}
