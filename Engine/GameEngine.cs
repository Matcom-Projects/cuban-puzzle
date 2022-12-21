namespace engine_cuban_puzzle;

public class GameUtils
{
    public static void Move ( List<Card> a , List<Card> b , int index )
    {
        b.Add(a[index]);
        a.RemoveAt(index);
    }

    public static int GetRandom(int min,int max)
    {
        Random e = new Random();
        return e.Next(min,max);
    }
    public static string CreateId ()//para cuando se haga la ast
    {
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        string result = "";
        Random e = new Random();

        for( int i = 0 ; i < 8 ; i++ )
        {
            result += letters [ e.Next(0,letters.Length) ];
        }

        return result;
    }
}

public class GameActions
{
    public static void Attack(int index,Player attacke)
    {
        
    }
}

public class GameEngine
{
    string Historial = "";
    GameTurns a;
    public void PlayGame()
    {
        while(true)
        {
            a.MoveNext();
            ActionPhase(a.Current);
            BuyPhase(a.Current);

        }
    }

    public void ActionPhase(Player a)
    {

    }

    public void BuyPhase(Player a)
    {

    }
}