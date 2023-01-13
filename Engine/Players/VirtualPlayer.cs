namespace engine_cuban_puzzle;

public class VirtualPlayer : IPlayer
{
    public string Name { get; }
    public TablePlayer Table { get; set; }
    public VirtualPlayer(string name)
    {
        this.Name = name;
        this.Table = new TablePlayer();
    }
    
    public bool Exit()
    {
        return !ExistIActionable();
    }
    public bool ExistIActionable()
    {
        for(int i=0; i<Table.HandCards.Count; i++)
        {
            if(Table.HandCards[i] is IActionable) return true;
        }

        return false;
    }
    public int SelectCardHand()
    {
        Console.ReadLine();
        
        if(Table.HandCards.Contains(GameEngine.bank.keys[6])) return Table.HandCards.IndexOf(GameEngine.bank.keys[6]);
        if(Table.HandCards.Contains(GameEngine.bank.keys[5])) return Table.HandCards.IndexOf(GameEngine.bank.keys[5]);
        if(Table.HandCards.Contains(GameEngine.bank.keys[4])) return Table.HandCards.IndexOf(GameEngine.bank.keys[4]);
        
        for(int i=0; i<Table.HandCards.Count; i++)
        {
            if(Table.HandCards[i] is IActionable)
                return i;
        }

        return 0;
    }
    public int SelectCardOnGoing()
    {
        Console.ReadLine();
        
        if(Table.OnGoing.Count == 0) return -1;
        return GameUtils.GetRandom(0,Table.OnGoing.Count);
    }
    public void ExecuteAction(IActionable card)
    {
        System.Console.WriteLine($"Jugó {((Card)card).Name}");
        Console.ReadLine();
        
        if(card is Combine)
        {
            card.Action();
            return;
        }
        if(card is CrashGem)
        {
            card.Action();
            return;
        }
        if(card is DobleCrashGem)
        {
            card.Action();
            return;
        }
        
        card.Action();
    }
    public int SelectGem()
    {            
        int max = int.MinValue;
        int index = 0;
        for(int i=0; i<Table.GemPile.Count; i++)
        {
            if(Table.GemPile[i].Money > max)
            {
                max = Table.GemPile[i].Money;
                index = i;
            }
        }
        return index;
    }
    public IPlayer SelectPlayer()
    {   
        int max = int.MinValue;
        int index = 0;
        for(int i=0; i<GameEngine.Turns.Players.Count; i++)
        {
            if((GameEngine.Turns.Players[i]!=this) && (GameEngine.Turns.Players[i].Table.GemPile.Count > max))
            {
                max = GameEngine.Turns.Players[i].Table.GemPile.Count;
                index = i;
            }
        }
        return GameEngine.Turns.Players[index];
    }

    public BankCard PlayBuyPhase()
    {
        Console.ReadLine();
        
        int money = GameEngine.CantMoneyPerTurn;
        if(money >= 9)
        {
            System.Console.WriteLine("Compro un Double CrashGem");
            Console.ReadLine();
            return GameEngine.bank.keys[5];
        }
        if(money >= 7)
        {
            System.Console.WriteLine("Compro un Gem 4");
            Console.ReadLine();
            return GameEngine.bank.keys[3];
        }
        if(money >= 5)
        {
            System.Console.WriteLine("Compro un CrashGem");
            Console.ReadLine();
            return GameEngine.bank.keys[4];
        }
        if(money >= 4)
        {
            System.Console.WriteLine("Compro un Combine");
            Console.ReadLine();
            return GameEngine.bank.keys[6];
        }
        if(money >= 3) 
        {
            System.Console.WriteLine("Compro un Gem 2");
            Console.ReadLine();
            return GameEngine.bank.keys[1];
        }
        if(money >= 1) 
        {
            System.Console.WriteLine("Compro un Gem 1");
            Console.ReadLine();
            return GameEngine.bank.keys[0];
        }
        if(money == 0)
        {
            for(int i=0; i<GameEngine.bank.keys.Count; i++)
            {
                if(GameEngine.bank.keys[i].Cost==0 && GameEngine.bank.keys[i] !is Cup)
                {
                    System.Console.WriteLine($"Compro un {GameEngine.bank.keys[i].Name}");
                    Console.ReadLine();
                    return GameEngine.bank.keys[i];
                }
            }
        } 

        System.Console.WriteLine("Compro un Cup");
        Console.ReadLine();
        return GameEngine.bank.keys[7];
    }
    public bool PlayNextBuyPhases()
    {
        Console.ReadLine();
        
        int money = GameEngine.CantMoneyPerTurn;
        if(money <= 0) 
        {
            System.Console.WriteLine("Termino su fase de compra");
            Console.ReadLine();
            return true;
        }

        System.Console.WriteLine("Sigue su fase de compra");
        Console.ReadLine();
        return false;
    }

   public int SelectCardDeck()
        {
            if(Table.Deck.Contains(GameEngine.bank.keys[6])) return Table.HandCards.IndexOf(GameEngine.bank.keys[6]);
            if(Table.Deck.Contains(GameEngine.bank.keys[5])) return Table.HandCards.IndexOf(GameEngine.bank.keys[5]);
            if(Table.Deck.Contains(GameEngine.bank.keys[4])) return Table.HandCards.IndexOf(GameEngine.bank.keys[4]);
            return 0;
        }

        public int SelectCardDiscardPile()
        {
            if(Table.DiscardPile.Contains(GameEngine.bank.keys[6])) return Table.HandCards.IndexOf(GameEngine.bank.keys[6]);
            if(Table.DiscardPile.Contains(GameEngine.bank.keys[5])) return Table.HandCards.IndexOf(GameEngine.bank.keys[5]);
            if(Table.DiscardPile.Contains(GameEngine.bank.keys[4])) return Table.HandCards.IndexOf(GameEngine.bank.keys[4]);
            return 0;
        }

    public BankCard SelectCardBank()
    {
        return GameEngine.bank.keys[GameUtils.GetRandom(0,GameEngine.bank.keys.Count)];
    }

    public int[] SelectGem(int cantgem)
    {
        if(!GameUtils.ExistCombination(Table.GemPile)) return new int[]{-1,-1};
        int HighCombination=0;
        int indexi=-1;
        int indexj=-1;

        for(int i =0;i<Table.GemPile.Count-1;i++)
        {
            for(int j = i+1;j<Table.GemPile.Count;j++)
            {
                if(Table.GemPile[i].Money+Table.GemPile[j].Money<=4 && Table.GemPile[i].Money+Table.GemPile[j].Money>HighCombination)
                {
                    indexi = i;
                    indexj = j;
                    HighCombination = Table.GemPile[i].Money+Table.GemPile[j].Money;
                }
            }
        }
        return new int[]{indexi,indexj};
    }
    public int SelectCard(List<Card>list)
    {
        if(list.Count==0) return -1;
        return GameUtils.GetRandom(0,list.Count);
    }

    public int SelectBCard(List<Card> cardslist)
    {
        for(int i =0;i<cardslist.Count;i++)
        {
            if (cardslist[i] is BankCard) return i;
        }
        return -1;
    }
}

