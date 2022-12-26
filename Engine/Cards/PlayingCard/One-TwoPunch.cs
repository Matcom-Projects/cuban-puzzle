namespace engine_cuban_puzzle;

public class OneTwoPunch : BankCard, IActionable
{
    public bool[] Actions {get; set;}
    public OneTwoPunch() : base("One-Two Punch", new string[]{"yellow"}, 0,4)
    {
        this.Actions = new bool[] {true, false, false, false, false, false};
    }

    public void GiveActions()
    {
        GameEngine.CantActionsPerTurn += 2;
    }
    public void SaveCards(int index, IPlayer a){}
    public void Draw(IPlayer a){}
    public void Attack(int index,IPlayer a){}
    public void Trash(IPlayer a){}
    public void GainCard(IPlayer a){}
    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        return $"[{this.Name}]";
    }

    /*Informacion de la carta:
    1. Da dos acciones mas
    */
}
