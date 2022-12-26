namespace engine_cuban_puzzle;

public class GemEssence : BankCard, IActionable
{
    public bool[] Actions {get; set;}
    public GemEssence() : base("Gem Essence", new string[]{"yellow"}, 0,3)
    {
        this.Actions = new bool[] {false, false, false, false, true, false};
    }

    public void GiveActions(){}
    public void SaveCards(int index, IPlayer a){}
    public void Draw(IPlayer a){}
    public void Attack(int index,IPlayer a){}
    public void Trash(IPlayer a)
    {
        if(a.Table.HandCards.Contains(new Gem1()))
        {
            BankCard card = new Gem1();
            GameEngine.bank.Add(card);
            a.Table.HandCards.Remove(card);
            GameEngine.CantActionsPerTurn++;
        }
    }
    public void GainCard(IPlayer a){}
    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        return $"[{this.Name}]";
    }

    /*Informacion de la carta:
    1. Trashea una gema de 1 y tienes una accion mas
    */
}
