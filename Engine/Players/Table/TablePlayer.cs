namespace engine_cuban_puzzle;

public class TablePlayer
{
    private List<Card> Deck ;
    public List<Card> DiscardPile ;
    public  List<Card> OnGoing { get; private set; }
    private List<Card> HandCards ;
    public List<ICostable> GemPile ;

    public TablePlayer( )
    {
        this.DiscardPile = new List<Card>();
        this.OnGoing = new List<Card>();
        this.HandCards = new List<Card>();
        this.GemPile = new List<ICostable>();
    }

    public void CreateDeck(List<Card> initialdeck)
    {
        this.Deck = initialdeck;
    }

    public Card GetDeck()
    {

        if(Deck.Count == 0)
        {
            Deck.AddRange(DiscardPile);
            DiscardPile.Clear();
            MixDeck();
        }

        Card result = Deck[0];
        Deck.RemoveAt(0);

        return result;
    }

    public List<Card> GetCantDeck(int n)
    {
        List<Card> result = new List<Card>();

        for(int i =0; i < n;i++)
        {
            result.Add(GetDeck());
        }

        return result;
    }

    public void MixDeck()
    {
        List<Card> result = new List<Card>();    
        int index;

        while(Deck.Count != 0)
        {
            index = GameUtils.GetRandom(0,Deck.Count);
            result.Add(Deck[index]);
            Deck.RemoveAt(index);
        }

        Deck = result;
    }
    public void HandToOnGoing(int index)
    {
        GameUtils.Move(HandCards,OnGoing,index);
    }
    public void DeckToHand(int index)
    {
        GameUtils.Move(Deck,HandCards,index);
    }
    public void DiscardPileToHand(int index)
    {
        GameUtils.Move(DiscardPile,HandCards,index);
    }
    public void ToOnGoing(Card a)
    {
        OnGoing.Add(a);
    }

    public void ToDiscardPile(Card a)
    {
        DiscardPile.Add(a);
    }
    public void ToDiscardPile(IEnumerable<Card> a)
    {
        DiscardPile.AddRange(a);
    }
    public int CantGem()
    {
        int result = 0;

        foreach(ICostable gems in GemPile)
        {
            result += ((Card)gems).Money;
        }

        return result;
    }

    public void CleanUp()
    {
        DiscardPile.AddRange(OnGoing);
        OnGoing.Clear();
    }
}