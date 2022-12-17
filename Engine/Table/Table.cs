namespace engine_cuban_puzzle;

public class Table
{
    public List<Card> Deck { get; }
    public List<Card> DiscardPile { get; set;}
    public  List<Card> OnGoing { get; private set; }
    public List<Card> HandCards { get; }
    public List<ICostable> GemPile { get; }

    public Table( List<Card> initialdeck )
    {
        this.Deck = initialdeck;
        this.DiscardPile = new List<Card>();
        this.OnGoing = new List<Card>();
        this.HandCards = new List<Card>();
        this.GemPile = new List<ICostable>();
    }
}