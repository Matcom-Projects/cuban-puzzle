namespace engine_cuban_puzzle;

public class GameActions
{
    public static void Move ( List<Card> a , List<Card> b , int index )
    {
        if(index==-1) return;
        b.Add(a[index]);
        a.RemoveAt(index);
    }

    public static void GiveActions(int cant)
    {
        GameEngine.CantActionsPerTurn += cant;
    }

    public static void GiveMoney(int cant)
    {
        GameEngine.CantMoneyPerTurn += cant;
    }

    public static void Draw(int cant)
    {
        GameEngine.Turns.Current.Table.DrawDeck(cant);
    }

    public static void SaveCards(int index)
    {
        if(index == -1) return;
        GameEngine.Turns.Current.Table.HandToSaveCards(index);
    }
    public static void Trash(int index, List<Card> list)
    {
        if(index == -1) return;
        GameEngine.bank.Add( (BankCard)list[index]);
        list.RemoveAt(index);
    }

    public static void Attack(IPlayer Victim,int cantgem)
    {
        List<BankCard> result = new List<BankCard>();

        for(int i = 0 ; i < cantgem ; i++ )
        {
            int index = GameEngine.Turns.Current.SelectGem();
            result.AddRange(GameEngine.bank.GetCant(0,GameEngine.Turns.Current.Table.GemPile[index].Money));
            GameEngine.Turns.Current.Table.GemPile.RemoveAt(index);
        }

        Victim.Table.ToGemPile(result);
    }

    public static void GainCard ( IPlayer Player, BankCard card )
    {
        Player.Table.ToDiscardPile( GameEngine.bank.Get(card));
    }

    public static void Sacrifice (IPlayer Player, int index)
    {
        if(index == -1) return;
        Player.Table.HandToDiscardPile(index);
    }

    public static void OverTaking(IPlayer Player, int index)
    {
        if(index == -1) return;
        Player.Table.DeckToHand(index);
    }

    public static void Revive(IPlayer Player, int index)
    {
        if(index == -1) return;
        Player.Table.DiscardPileToHand(index);
    }

    public static void CombineFunction()
    {
        IPlayer a = GameEngine.Turns.Current;
        int[] GemsSelect = a.SelectGem(2);

        if(GemsSelect[0] == -1 || GemsSelect[1] == -1) return;

        BankCard x = (BankCard)a.Table.GemPile[GemsSelect[0]];
        BankCard y = (BankCard)a.Table.GemPile[GemsSelect[1]];

        GameEngine.bank.Add(x); 
        GameEngine.bank.Add(y);
        a.Table.GemPile.RemoveAt(Math.Max(GemsSelect[0],GemsSelect[1]));
        a.Table.GemPile.RemoveAt(Math.Min(GemsSelect[0],GemsSelect[1]));

        if(x is Gem1 && y is Gem1)
        {
            a.Table.GemPile.Add(GameEngine.bank.Get(GameEngine.bank.keys[1]));
        }
        else if((x is Gem1 && y is Gem2) || (x is Gem2 && y is Gem1))
        { 
            a.Table.GemPile.Add(GameEngine.bank.Get(GameEngine.bank.keys[2]));
        }
        else if((x is Gem1 && y is Gem3) || (x is Gem2 && y is Gem2) || (x is Gem3 && y is Gem1)) 
        {
            a.Table.GemPile.Add(GameEngine.bank.Get(GameEngine.bank.keys[3]));
        }
    }
}