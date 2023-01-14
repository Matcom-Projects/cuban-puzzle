namespace engine_cuban_puzzle;

public class Player_Node : AST_Node
{
    public IPlayer Player;
    public Player_Node(IPlayer player)
    {
        this.Player = player;
    }
}