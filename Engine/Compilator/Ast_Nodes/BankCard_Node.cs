namespace engine_cuban_puzzle;

public class BankCard_Node : AST_Node
{
    public  BankCard Card;
    public BankCard_Node(BankCard card)
    {
        this.Card = card;
    }
}