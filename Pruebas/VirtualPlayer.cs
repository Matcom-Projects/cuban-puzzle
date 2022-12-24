namespace AppConsole//cambios 3.0
{
    public class VirtualPlayer : IPlayer
    {
        public string Name { get; }
        public TablePlayer Table { get; set; }
        public VirtualPlayer(string name)
        {
            this.Name = name;
            this.Table = new TablePlayer();
        }
        
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
}