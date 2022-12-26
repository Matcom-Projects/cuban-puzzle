namespace engine_cuban_puzzle;

public class Knockdown : BankCard, IActionable
{
    public bool[] Actions {get; set;}
    public Knockdown() : base("Knockdown", new string[]{"red"}, 0,2)
    {
        this.Actions = new bool[] {true, false, false, false, true, false};
    }

    public void GiveActions()
    {
        GameEngine.CantActionsPerTurn ++;
    }
    public void SaveCards(int index, IPlayer a){}
    public void Draw(IPlayer a){}
    public void Attack(int index,IPlayer a){}
    public void Trash(IPlayer a)
    {
        IPlayer b = a.SelectPlayer(a);
        foreach (BankCard card in b.Table.HandCards)
        {
            if(card.Color.Contains("purple"))
            {
                GameEngine.bank.Add(card);
                b.Table.HandCards.Remove(card);
            }
        }
    }
    public void GainCard(IPlayer a){}
    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        return $"[{this.Name}]";
    }

    /*Informacion de la carta:
    1. Da una accion mas
    2. Trashea una carta morada de la mano de un oponente seleccionado
    */
}
