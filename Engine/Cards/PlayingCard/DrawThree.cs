namespace engine_cuban_puzzle;

public class DrawThree : BankCard, IActionable
{
    public bool[] Actions {get; set;}
    public DrawThree() : base("Draw Three", new string[]{"yellow"}, 0,3)
    {
        this.Actions = new bool[] {false, false, true, false, false, false};
    }

    public void GiveActions(){}
    public void SaveCards(int index, IPlayer a){}
    public void Draw(IPlayer a)
    {
        a.Table.DrawDeck(3);
    }
    public void Attack(int index,IPlayer a){}
    public void Trash(IPlayer a){}
    public void GainCard(IPlayer a){}
    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        return $"[{this.Name}]";
    }

    /*Informacion de la carta:
    1. Coge tres cartas del deck
    */
}
