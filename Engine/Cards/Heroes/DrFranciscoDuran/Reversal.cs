namespace engine_cuban_puzzle;

public class Reversal : Card, IActionable
{
    public bool[] Actions {get; set;}
    public Reversal() : base("Reversal", new string[]{"purple"}, 0)
    {
        this.Actions = new bool[] {false, false, true, false, false, false};
    }
    public void GiveActions(){}
    public void SaveCards(int index, IPlayer a){}
    public void Draw(IPlayer a)
    {
        a.Table.DrawDeck(2);
    }
    public void Attack(int index,IPlayer a){}
    public void Trash(IPlayer a){}
    public void GainCard(IPlayer a){}

    /*Informacion de la carta:
    1. Coge dos cartas del deck
    */
}
