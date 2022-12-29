namespace engine_cuban_puzzle;

public class UnstablePower : Card, IActionable
{
    public bool[] Actions {get; set;}
    public UnstablePower() : base("Unstable Power", new string[]{"purple"}, 0)
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
        a.Table.DiscardPile.Add(GameEngine.bank.Get(5));
        a.Table.DiscardPile.AddRange(GameEngine.bank.GetCant(7,2));
    }

    /*Informacion de la carta:
    1. Gana un doble crash gem, pero tambien dos CUP 
    */
}
