namespace engine_cuban_puzzle;

public interface IPlayer
{
    public string Name { get; }
    public TablePlayer Table { get; set; }
    
        public int SelectActionCard(List<BankCard> a);
        public int SelectHero(List<Card> a);
        public int SelectCardHand();
        public Card SelectCardOnGoing();
        public bool SelectField();
        public int SelectGem();
        public IPlayer SelectPlayer(IPlayer a);
        public bool Exit();//este metodo puede que sirva o puede q no
        public void ChooseActionRealize(IActionable card);
        public BankCard SelectCardBank(List<BankCard> list);//este metodo quitarlo desp
        public int SelectCardDeck();//este metodo quitarlo desp
        public BankCard PlayBuyPhase();
        public bool PlayNextBuyPhases();
}
public interface IActionable
{
    public bool[] Actions { get; }
    public void GiveActions();
    public void SaveCards(int index, IPlayer a);
    public void Draw(IPlayer a);
    public void Attack(int index,IPlayer a);
    public void Trash(IPlayer a);
    public void GainCard(IPlayer a);
}