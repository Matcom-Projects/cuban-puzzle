namespace engine_cuban_puzzle;

public abstract class ActionCard : Card,IActionable
{
    public ActionCard(string name, string color, int money,string information): base( name , color , money ,information){}
    public abstract void Action();
}