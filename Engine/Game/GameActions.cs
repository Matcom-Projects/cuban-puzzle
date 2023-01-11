namespace engine_cuban_puzzle;

public class GameActions
{
    public static void Move ( List<Card> a , List<Card> b , int index )
    {
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
        GameEngine.Turns.Current.Table.HandToSaveCards(index);
    }
    public static void Trash(int index, List<Card> list)
    {
        GameEngine.bank.Add( (BankCard)list[index]);
        list.RemoveAt(index);
    }

    public static void Attack(IPlayer Victim,int cantgem)
    {
        List<BankCard> result = new List<BankCard>();
        List<int> indexs = new List<int>();
        for(int i = 0 ; i < cantgem ; i++ )
        {
            int index = GameTurns.Current.SelectGem();
            result.AddRange(GameEngine.bank.GetCant(0,GameTurns.Table.GemPile[index].Money));
            indexs.Add(index);
        }
        Victim.Table.ToGemPile(result);

        indexs.Sort();
        for(int j = indexs.Count-1; j >= 0; j--)
        {
            GameTurns.Current.Table.GemPile.RemoveAt(j);
        }
        

    public static void GainCard ( IPlayer Player, int index )
    {
        Player.Table.ToDiscardPile( GameEngine.bank.Get(index));
    }

    public static void Sacrifice (IPlayer Player, int index)
    {
        Player.Table.HandToDiscardPile(index);
    }

    public static void OverTaking(IPlayer Player, int index)
    {
        Player.Table.DeckToHand(index);
    }

    public static void Revive(IPlayer Player, int index)
    {
        Player.Table.DiscardPileToHand(index);
    }
}
