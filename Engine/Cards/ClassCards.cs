namespace engine_cuban_puzzle;
using System.Collections.Generic;

public abstract class Card
{
    public string Name { get; private set; }
    public string Color { get; private set; }
    public int Money { get; set; }
    public string Information {get; private set;}
    public Card ( string name,string color,int money,string information)
    {
        this.Name = name;
        this.Color = color;
        this.Money = money;
        this.Information =information;
    }
}
public abstract class BankCard : Card
{
    public int Cost{ get; private set; }
    
    public BankCard ( string name,string color,int money ,int cost,string information): base (name,color,money,information)
    {
        this.Cost = cost;
    }
}

public abstract class ActionCard : Card,IActionable
{
    public ActionCard(string name, string color, int money,string information): base( name , color , money ,information){}
    public abstract void Action();
}

public abstract class ActionBankCard : BankCard,IActionable
{
    public ActionBankCard(string name, string color, int money,int cost,string information) : base( name , color , money , cost ,information){}

    public abstract void Action();
}
public class CreateCards
{
    public static List<BankCard>? AllActionsCards;
    public static List<Card>? AllHeroCards;

    public static void ReadCards()
    {
        AllActionsCards = new List<BankCard>();
        AllHeroCards = new List<Card>();

        string[] DirectionsActionsCards = Directory.GetFiles(@"../ActionCards","*.txt");
        string[] DirectionsHeroCards = Directory.GetFiles(@"../HeroCards","*.txt");

        for(int i =0;i < DirectionsActionsCards.Length;i++){
                
            StreamReader fileReader = new StreamReader(@DirectionsActionsCards[i]);
            string text = fileReader.ReadToEnd();
            System.Console.WriteLine("Parseando "+Path.GetFileNameWithoutExtension(DirectionsActionsCards[i]));
            ActionBankCard card = new ActionCardByUser(Path.GetFileNameWithoutExtension(DirectionsActionsCards[i]),new ActionCard_Node(text));
            AllActionsCards.Add(card);
        }
        for(int i =0;i < DirectionsHeroCards.Length;i++){
                
            StreamReader fileReader = new StreamReader(@DirectionsHeroCards[i]);
            string text = fileReader.ReadToEnd();
            System.Console.WriteLine("Parseando "+Path.GetFileNameWithoutExtension(DirectionsHeroCards[i]));
            ActionCard card = new HeroCardByUser(Path.GetFileNameWithoutExtension(DirectionsHeroCards[i]),new HeroCard_Node(text));
            AllHeroCards.Add(card);
        }
    }
}
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