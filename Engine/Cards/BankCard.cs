namespace engine_cuban_puzzle;

public abstract class BankCard : Card
{
    public int Cost{ get; private set; }
    
    public BankCard ( string name,string color,int money ,int cost,string information): base (name,color,money,information)
    {
        this.Cost = cost;
    }
}