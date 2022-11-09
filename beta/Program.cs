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