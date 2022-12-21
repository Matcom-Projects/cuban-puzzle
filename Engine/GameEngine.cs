namespace engine_cuban_puzzle;
using System.Collections.Generic;

public class GameUtils
{
    public static void Move ( List<Card> a , List<Card> b , int index )
    {
        b.Add(a[index]);
        a.RemoveAt(index);
    }
    public static List<IPlayer> Mezclar(List<IPlayer> a)
    {
        List<IPlayer> result = new List<IPlayer>();    
        int index;

        while(a.Count != 0)
        {
            index = GetRandom(0,a.Count);
            result.Add(a[index]);
            a.RemoveAt(index);
        }

        return result;
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
    public static void Attack(int index,IPlayer attacke)
    {
        
    }
}

public class GameEngine
{
    string Historial = "";
    GameTurns? Turns ;
    public void PlayGame(List<IPlayer> players)
    {
        Turns = new GameTurns(players);
        while(true)
        {
            Turns.MoveNext();
            ActionPhase(Turns.Current);
            BuyPhase(Turns.Current);
            CleanUpPhase(Turns.Current);
        }
    }

    public void ActionPhase(IPlayer a)
    {
        a.PlayActionPhase();
    }

    public void BuyPhase(IPlayer a)
    {

    }

    public void CleanUpPhase(IPlayer a)
    {

    }
}