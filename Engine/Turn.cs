namespace engine_cuban_puzzle;
using System.Collections;

public class GameTurns : IEnumerator
{
    private int Index;
    public List<Player> Players { get; private set; }

    public Player Current
    { 
        get
        {
            return Players [ Index % Players.Count ] ;
        } 
    
    }

    object IEnumerator.Current => throw new NotImplementedException();

    public GameTurns(List<Player> players)
    {
        this.Players = players;
        this.Index = -1;
    }

    public bool MoveNext()
    {
        Index++;
        return true;
    }

    public void Reset()
    {
        Index = -1;
    }
}