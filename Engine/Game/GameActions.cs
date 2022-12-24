namespace engine_cuban_puzzle;

public class GameActions
{

    public static void GiveActions()
    {
        GameEngine.CantActionsPerTurn ++;
    }

    public static void Draw(int n,IPlayer a)
    {
        a.Table.DrawDeck(n);
    }

    public static void SaveCards(int index,IPlayer a)
    {
        a.Table.HandToSaveCards(index);
    }
    public static void Trash(int index, List<Card> list)
    {
        GameEngine.bank.Add( (BankCard)list[index]);
        list.RemoveAt(index);
    }

    public static void GainCard ( IPlayer a, BankCard card )
    {
        a.Table.ToDiscardPile( GameEngine.bank.Get(card));
    }
}