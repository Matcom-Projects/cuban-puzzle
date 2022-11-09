namespace cuban_puzzle;

public abstract class Card
{
    public string Name{get;private set;}
    public Card(string name)
    {
        this.Name = name;
    }
}

public class HeroCards : Card
{
    public string Color { get ; private set; }
    public int Actions { get ; private set; }
    public int SaveCard { get ; private set; }
    public int DeckRobbery { get ; private set; }
    public int Money { get ; private set; }

    public HeroCards (string name,string color,int actions , int savecard , int deckrobbery , int money):base(name)
    {
        this.Color = color;
        this.Actions = actions;
        this.SaveCard = savecard;
        this.DeckRobbery = deckrobbery;
        this.Money = money;
    }
}

public abstract class BankCards : Card
{
    public int Cost{get; private set;}
    public BankCards(int cost,string name):base(name)
    {
        this.Cost = cost;
    }
}

public class Gem : BankCards
{
    public int Count{get; private set;}
    public Gem (int count,int cost): base(cost,"Gem "+count)
    {
        this.Count = count;
    }

    public override string ToString()
    {
        return $"[Gem {Count}] Costo: {Cost}";
    }
}

public class Wound : BankCards
{
    public Wound() : base(0,"CUP")
    {
        
    }
}

public class PlayingCard : BankCards
{
    public string Color { get ; private set; }
    public int Actions { get ; private set; }
    public int SaveCard { get ; private set; }
    public int DeckRobbery { get ; private set; }
    public int Money { get ; private set; }
    public int Attack { get ; private set; }


    public PlayingCard(int cost , string color , string name , int actions , int savecard , int deckrobbery , int money , int attack) : base (cost,name)
    {
        this.Color = color;
        this.Actions = actions;
        this.SaveCard = savecard;
        this.DeckRobbery = deckrobbery;
        this.Money = money;
        this.Attack = attack;
    }

    public override string ToString()
    {
        string result= @$"
{Name} {Color}
acciones: {Actions}
salvar carta: {SaveCard}
Robar carta del deck: {DeckRobbery}
Dinero extra: {Money}
Ataque: {Attack}
Costo: {Cost}
        ";
        return result;
    }

}
public class Bank
{
    public Gem gem1 { get {return new Gem(1,1);} private set{} }
    public Gem gem2 { get{return new Gem(2,3);} private set{} }
    public Gem gem3 { get{return new Gem(3,5);} private set{} }
    public Gem gem4 { get{return new Gem(4,7);} private set{} }
    public Wound wound{ get {return new Wound();} private set{} }
    public PlayingCard crashgem { get{ return new PlayingCard(5,"purple","crash gem",0,0,0,1,1);} private set{}}
    public Dictionary<BankCards,int> bank { get; set; }
    public Bank(List<PlayingCard> choosecard)
    {
        this.bank = new Dictionary<BankCards, int>();
        foreach( PlayingCard a in choosecard)
        {
            this.bank.Add(a,5);
        }
    }
}

public class Player
{
    public string Name{ get; private set; }
    public int CantGem{ get; private set; }
    public  List <Card> Deck { get; set; }
    public  List <Card> Hand { get; set; } 
    public  List <Card> DiscardPile { get; set; }
    public  List <Gem> GemPile { get; set; }
    public  List <Card> Ongoing { get; set; }

    public Player(string name,HeroCards a,List<Card> initialdeck)
    {
        this.Name = name;
        this.CantGem = 0;
        this.Hand = new List<Card>();
        this.DiscardPile = new List<Card>();
        this.GemPile = new List<Gem>();
        this.Ongoing = new List<Card>();
        this.Deck = new List<Card>();
        this.Deck.Add(a);
        this.Deck.AddRange(initialdeck);
    }

    public override string ToString()
    {
        return"";
    }

    public void Draw(int n) 
    {
        for (int i = 0 ; i < n; i++)
        {
            if(Deck.Count==0)
            {
                Deck.AddRange(DiscardPile);
                DiscardPile.RemoveRange(0,DiscardPile.Count());
            }
            Hand.Add(Deck[0]);
            Deck.RemoveAt(0);
        }
    }
}