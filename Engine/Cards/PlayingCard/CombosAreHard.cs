namespace engine_cuban_puzzle;

public class CombosAreHard : BankCard, IActionable
{
    public bool[] Actions {get; set;}
    public CombosAreHard() : base("Combos Are Hard", new string[]{"yellow"}, 0,6)
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
        for(int i=0; i < 2; i++)
        {
            List<BankCard> list = new List<BankCard>();
            foreach(var key in GameEngine.bank.keys)
            {
                list.Add(key);
            }
            
            a.Table.DiscardPile.Add(GameEngine.bank.Get(list[GamePrint.SelectCard(list)]));
        }

        GameEngine.bank.Add(this);
        a.Table.OnGoing.Remove(this);
    }
    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        return $"[{this.Name}]";
    }

    /*Informacion de la carta:
    1. Gana dos cartas y despues trashea esta carta 
    */
}
