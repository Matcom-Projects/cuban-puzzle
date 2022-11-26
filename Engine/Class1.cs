namespace engine_cuban_puzzle;

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
    public override string ToString()
    {
        string result= @$"
{Name} {Color}
acciones: {Actions}
salvar carta: {SaveCard}
Robar carta del deck: {DeckRobbery}
Dinero extra: {Money}
        ";
        return result;
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
        return $"[Gem {Count}]";
    }
}

public class Wound : BankCards
{
    public Wound() : base(0,"CUP")
    {
        
    }
    public override string ToString()
    {
        return $"[{Name}]";
    }
}

public class CrashGem : PlayingCard
{
    public CrashGem( ) : base(5, "purple","Crash Gem",  0 , 0 ,  0 ,  1 , 1,new bool[] {false,false,false,true})
    {

    }
}

public class PlayingCard : BankCards
{
    public bool[] OriginStateActions{ get; private set; }
    public bool[] GameStateActions{ get; private set; }
    public string Color { get ; private set; }
    public int Actions { get ; private set; }
    public int SaveCard { get ; private set; }
    public int DeckRobbery { get ; private set; }
    public int Attack { get ; private set; }
    public int Money { get ; private set; }


    public PlayingCard(int cost , string color , string name , int actions , int savecard , int deckrobbery , int attack , int money , bool[] stateactions) : base (cost,name)
    {
        this.Color = color;
        this.Actions = actions;
        this.SaveCard = savecard;
        this.DeckRobbery = deckrobbery;
        this.Money = money;
        this.Attack = attack;
        this.OriginStateActions = stateactions;
        this.GameStateActions = (bool[])stateactions.Clone();
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

    public void Reset()
    {
        this.GameStateActions = (bool[])this.OriginStateActions.Clone();
    }

}
public class Bank
{
    public Gem gem1 { get { return new Gem(1,1); } private set{} }
    public Gem gem2 { get { return new Gem(2,3); } private set{} }
    public Gem gem3 { get { return new Gem(3,5); } private set{} }
    public Gem gem4 { get {return new Gem(4,7); } private set{} }
    public Wound wound{ get {return new Wound();} private set{} }
    public CrashGem crashgem { get{ return new CrashGem();} private set{}}
    public Dictionary <BankCards,int> bank ;
    public Bank ( List <PlayingCard> choosecard )
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
    public int NumberActions{get;set;}
    public int CantMoney{get;set;}
    public int NumberAttack{get;set;}
    public int NumberSaveCard{get;set;}
    public int NumberRoberryCard{get;set;}
    public string Name{ get; private set; }
    public int CantGem{ get; private set; }
    public  List <Card> Deck { get; set; }
    public  List <Card> Hand { get; set; } 
    public  List <Card> DiscardPile { get; set; }
    public  List <Gem> GemPile { get; set; }
    public  List <Card> Ongoing { get; set; }
    public List<Card> SavingCards{ get; set; }

    public Player(string name,HeroCards a,List<Card> initialdeck)
    {
        this.SavingCards= new List<Card>();
        this.Name = name;
        this.CantGem = 0;
        this.Hand = new List<Card>();
        this.DiscardPile = new List<Card>();
        this.GemPile = new List<Gem>();
        this.Ongoing = new List<Card>();
        this.Deck = new List<Card>();
        this.Deck.Add(a);
        this.Deck.AddRange(initialdeck);
        this.NumberActions = 1;
    }

    public override string ToString()
    {
        return this.Name;
    }

    public void Draw(int n) 
    {
        Random r = new Random();
        int num;
        for (int i = 0 ; i < n; i++)
        {
            if(Deck.Count==0)
            {
                Deck.AddRange(DiscardPile);
                DiscardPile.RemoveRange(0,DiscardPile.Count());
            }
            num = r.Next(0,Deck.Count-1);
            Hand.Add(Deck[num]);
            Deck.RemoveAt(num);
        }
    }

    public void Attack(List<Gem> a, Player b)
    {
        b.GemPile.AddRange(a);
    }

    public void SaveCard(Card a)
    {
        SavingCards.Add(a);
    }

    public void Actions(int n)
    {
        NumberActions += n;
    }

    public void Reset()
    {
        this.NumberActions = 1;
        this.CantMoney = 0;
        this.NumberRoberryCard = 0;
        this.NumberSaveCard = 0;
        this.NumberRoberryCard = 0;
    }
}

