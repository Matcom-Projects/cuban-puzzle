namespace AppConsole//Cambios 
{
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
        public void SelectCardHand();
        public Card SelectCardOnGoing();
        public bool SelectField();
        public int SelectGem();
        public IPlayer SelectPlayer(IPlayer a);
        public void ChooseActionRealize(Card card, Bank bank);
        public ICostable PlayBuyPhase();
        public void PlayCleanUpPhase();
        
    }

    public interface IActionable
    {
        public bool[] Actions {get{ this.Actions = new bool[6];}}

        public void GiveActions();
        public void SaveCards(int index);
        public void ExecuteGetDeck();
        public void Attack(int index,IPlayer a);
        public void Trash(Card card);
        public void GainCard(Card card);
    }
}