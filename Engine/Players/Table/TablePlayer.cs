namespace engine_cuban_puzzle;

public class TablePlayer
{
    public List<Card> Deck {get; private set;}
    public List<Card> DiscardPile ;
    public  List<Card> OnGoing { get; private set; }
    public List<Card> HandCards { get; private set; }
    public List<BankCard> GemPile ;
    private List<Card> SaveCards;

    public TablePlayer( )
    {
        this.DiscardPile = new List<Card>();
        this.OnGoing = new List<Card>();
        this.HandCards = new List<Card>();
        this.GemPile = new List<BankCard>();
        this.SaveCards = new List<Card>();
    }

    public void CreateDeck(List<Card> initialdeck)
    {
        this.Deck = initialdeck;
    }

    public void DrawDeck(int n)
    {
        for(int i =0; i < n;i++)
        {
            if(Deck.Count == 0)
            {
                Deck.AddRange(DiscardPile);
                DiscardPile.Clear();
                MixDeck();
            }
            GameActions.Move(Deck,HandCards,0);
        }
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
        GameActions.Move(HandCards,OnGoing,index);
    }

    public void HandToSaveCards(int index)
    {
        GameActions.Move(HandCards,SaveCards,index);
    }
    public void DeckToHand(int index)
    {
        GameActions.Move(Deck,HandCards,index);
    }
    public void DiscardPileToHand(int index)
    {
        GameActions.Move(DiscardPile,HandCards,index);
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

    public void ToGemPile(BankCard gem)
    {
        GemPile.Add(gem);
    }
    public void ToGemPile(List<BankCard> gem)
    {
        GemPile.AddRange(gem);
    }
    public List<BankCard> GetGemPile(params int[] index)
    {
        List<BankCard> result = new List<BankCard>();

        foreach(int i in index)
        {
            result.Add(GemPile[i]);
            GemPile.RemoveAt(i);
        }
        
        return result;
    }
    public int CantGem()
    {
        int result = 0;

        foreach(BankCard gems in GemPile)
        {
            result += ((Card)gems).Money;
        }

        return result;
    }

    public int CleanUp()
    {
        int CantGemResult = this.CantGem();
        int CantCardsDraw = SaveCards.Count();
        CleanOnGoing();
        CleanHand();
        CleanSaveCards();

        if( CantGemResult <= 2 )
        {
            CantCardsDraw = 5 - CantCardsDraw;
        }
        else if ( CantGemResult <= 5 )
        {
            CantCardsDraw = 6 - CantCardsDraw;
        }
        else if ( CantGemResult <= 8)
        {
            CantCardsDraw = 7 - CantCardsDraw;
        }
        else if( CantCardsDraw <= 9 )
        {
            CantCardsDraw = 8 - CantCardsDraw;
        }
        else return CantCardsDraw;

        if( CantCardsDraw > 0 )
        {
            DrawDeck(CantCardsDraw);
        }

        return CantGemResult;
    }

    private void CleanSaveCards()
    {
        HandCards.AddRange(SaveCards);
        SaveCards.Clear();
    }

    private void CleanOnGoing()
    {
        DiscardPile.AddRange(OnGoing);
        OnGoing.Clear();        
    }

    private void CleanHand()
    {
        DiscardPile.AddRange(HandCards);
        HandCards.Clear();       
    }

    public int CantMoneyBuyPhases()
    {
        int CantMoneyResult = 0;
        foreach(Card ongoingcards in OnGoing)
        {
            CantMoneyResult += ongoingcards.Money;
        }
        foreach(Card handcards in HandCards)
        {
            if(handcards is Gem1||handcards is Gem2||handcards is Gem3||handcards is Gem4)
            {
                CantMoneyResult += handcards.Money;
            }
        }
        return CantMoneyResult;
    }
}