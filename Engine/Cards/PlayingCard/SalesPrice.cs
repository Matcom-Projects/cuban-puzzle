namespace engine_cuban_puzzle;

public class SalesPrice : BankCard, IActionable
{
    public bool[] Actions {get; set;}
    public SalesPrice() : base("Sales Price", new string[]{"yellow"}, 3,2)
    {
        this.Actions = new bool[] {false, false, false, false, false, true};
    }

    public void GiveActions(){}
    public void SaveCards(int index, IPlayer a){}
    public void Draw(IPlayer a){}
    public void Attack(int index,IPlayer a){}
    public void Trash(IPlayer a){}
    public void GainCard(IPlayer a)
    {
        a.Table.DiscardPile.Add((Card)GameEngine.bank.Get(new Gem1()));
    }
    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        return $"[{this.Name}]";
    }

    /*Informacion de la carta:
    1. Gana un gem1 y 3$ para la fase de compra
    */
}
