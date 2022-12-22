namespace engine_cuban_puzzle;
using System.Collections.Generic;

public class GameEngine
{
    string Historial = "";
    int CantActionsPerTurn = 1;
    int CantMoneyPerTurn = 0;
    GameTurns? Turns ;
    public void PlayGame(List<IPlayer> players,Bank bank)
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