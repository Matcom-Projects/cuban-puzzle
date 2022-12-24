namespace engine_cuban_puzzle;

public interface ICostable
{
    public int Cost{ get; }
}

public interface IPlayer
{
    public string Name { get; }
    public TablePlayer Table { get; set; }
    
    public int SelectHero(List<Card> a);
    public int SelectActionCard(List<ICostable> a);
    public int SelectCardHand();
    public Card SelectCardOnGoing();
    //public bool SelectField();
    public int SelectGem();
    public IPlayer SelectPlayer(IPlayer a);
    public void ChooseActionRealize(IActionable card, Bank bank);
    public ICostable PlayBuyPhase();
}
public interface IActionable
{
    public bool[] Actions { get; }
    public void GiveActions();
    public void SaveCards(int index);
    public void ExecuteGetDeck();
    public void Attack(int index,IPlayer a);
    public void Trash(Card card);
    public void GainCard(Card card);
}