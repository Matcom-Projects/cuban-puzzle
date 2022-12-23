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
    //ESTE METODO QUE HACE???
    // public static void ExecuteGetDeck(List<int> indexs)
    // {
    //     while(indexs.Count>0)
    //     {
    //         GameUtils.Move(TablePlayer.Deck, TablePlayer.DiscardPile, indexs[indexs.Count-1]);
    //         indexs.RemoveAt(indexs.Count-1);
    //     }
    // }
    //implementar despues...
    // public static void Attack(IPlayer a,int index,IPlayer attack)
    // {
    //     GameUtils.Move(List<Gem1>, attack.TablePlayer.GemPile, index);
    // }

    public static void Trash(int index, List<Card> list)
    {
        GameEngine.bank.Add((ICostable) list[index]);
        list.RemoveAt(index);
    }

    public static void GainCard ( IPlayer a, ICostable card )
    {
        a.Table.ToDiscardPile((Card) GameEngine.bank.Get(card));
    }
}