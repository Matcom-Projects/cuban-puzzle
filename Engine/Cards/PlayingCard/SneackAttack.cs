namespace engine_cuban_puzzle;

public class SneackAttack : BankCard, IActionable
{
    public bool[] Actions {get; set;}
    public SneackAttack() : base("Sneack Attack", new string[]{"red"}, 0,3)
    {
        this.Actions = new bool[] {true, false, false, false, false, true};
    }

    public void GiveActions()
    {
        GameEngine.CantActionsPerTurn ++;
    }

    public void GainCard(IPlayer a)
    {
        a.Table.DiscardPile.Add((Card)GameEngine.bank.Get(0));            
        foreach(var p in GameEngine.Turns.Players)
        {
            if(p==a) continue;
            p.Table.GemPile.Add(GameEngine.bank.Get(0));
        }
    }

    void IActionable.SaveCards(int index, IPlayer a)
    {
        throw new NotImplementedException();
    }

    void IActionable.Draw(IPlayer a)
    {
        throw new NotImplementedException();
    }

    void IActionable.Attack(int index, IPlayer a)
    {
        throw new NotImplementedException();
    }

    void IActionable.Trash(IPlayer a)
    {
        throw new NotImplementedException();
    }
    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        return $"[{this.Name}]";
    }

    /*Informacion de la carta:
    1. Da una accion mas
    2. Gana un gem1 y pone un gem1 en las pilas de gemas de los oponentes
    */
}