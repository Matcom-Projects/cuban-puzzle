namespace engine_cuban_puzzle;

public abstract class ActionBankCard : BankCard,IActionable
{
    public ActionBankCard(string name, string color, int money,int cost,string information) : base( name , color , money , cost ,information){}

    public abstract void Action();
}