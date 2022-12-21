namespace engine_cuban_puzzle;
using System.Collections;

public class GameTurns : IEnumerator
{
    private int Index;
    public List<IPlayer> Players { get; private set; }

    public IPlayer Current
    { 
        get
        {
            return Players [ Index % Players.Count ] ;
        } 
    
    }

    object IEnumerator.Current => throw new NotImplementedException();

    public GameTurns(List<IPlayer> players)
    {
        this.Players = players;
        this.Index = -1;
    }

    public bool MoveNext()
    {
        Index++;
        return true;
    }

    public int GameRound()
    {
        return (Index/Players.Count)+ 1;
    }

    public void Reset()
    {
        Index = -1;
    }
}