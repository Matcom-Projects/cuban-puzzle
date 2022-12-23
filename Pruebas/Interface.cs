namespace AppConsole//Cambios 2.0
{
    public interface ICostable
    {
        public int Cost{ get; }
    }

    public interface IPlayer
    {
        public string Name { get; }
        public TablePlayer Table { get; set; }
        
        public int SelectActionCard(List<ICostable> a);
        public int SelectHero(List<Card> a);
        public int SelectCardHand();//parche momentaneo
        public void SelectCardHandM();//parche momentaneo
        public Card SelectCardOnGoing();
        public bool SelectField();
        public int SelectGem();
        public IPlayer SelectPlayer(IPlayer a);
        public void ChooseActionRealize(Card card, Bank bank);
        public Card SelectCardBank(List<Card> list);
        public int SelectCardDeck();
        public ICostable PlayBuyPhase();
        public void PlayCleanUpPhase();
        
    }

    public interface IActionable
    {
        public bool[] Actions {get{ this.Actions = new bool[6];}}

        public void GiveActions();
        public void SaveCards(int index, IPlayer a);
        public void ExecuteGetDeck(IPlayer a);
        public void Attack(int index,IPlayer a);
        public void Trash(Bank bank, IPlayer a);
        public void GainCard(Bank bank, IPlayer a);
    }
}
