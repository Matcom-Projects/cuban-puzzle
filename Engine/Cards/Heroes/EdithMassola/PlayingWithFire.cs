namespace engine_cuban_puzzle;

public class PlayingWithFire : Card, IActionable
{
    public bool[] Actions {get; set;}
    public PlayingWithFire() : base("Playing With Fire", new string[]{"yellow"}, 0)
    {
        this.Actions = new bool[] {true, false, true, false, false, false};
    }

    public void GiveActions()
    {
        GameEngine.CantActionsPerTurn += 2;
    }
    public void SaveCards(int index, IPlayer a){}
    public void Draw(IPlayer a)
    {
        a.Table.DrawDeck(1);
    }
    public void Attack(int index,IPlayer a){}
    public void Trash(IPlayer a){}
    public void GainCard(IPlayer a){}

    /*Informacion de la carta:
    1. Da dos acciones mas
    2. Coge una carta del deck 
    */
}
