namespace engine_cuban_puzzle;

public class OneOfEach : BankCard, IActionable
{
    public bool[] Actions {get; set;}
    public OneOfEach() : base("One Of Each", new string[]{"yellow"}, 1,5)
    {
        this.Actions = new bool[] {true, true, true, false, false, false};
    }

    public void GiveActions()
    {
        GameEngine.CantActionsPerTurn ++;
    }
    public void SaveCards(int index, IPlayer a)
    {
        a.Table.HandToSaveCards(index);
    }
    public void Attack(int index,IPlayer a){}
    public void Trash(IPlayer a){}
    public void GainCard(IPlayer a){}

    public void Draw(IPlayer a)
    {
        a.Table.DrawDeck(1);
    }
    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        return $"[{this.Name}]";
    }

    /*Informacion de la carta:
    1. Da una accion mas y 1$ para la fase de compra
    2. Guarda una carta para el proximo turno
    3. Coge una carta del deck
    */
}
