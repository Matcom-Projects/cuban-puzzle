namespace AppConsole//Cambios 3.0
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
        public int SelectCardHand();
        public Card SelectCardOnGoing();
        public bool SelectField();
        public int SelectGem();
        public IPlayer SelectPlayer(IPlayer a);
        public bool Exit();//este metodo puede que sirva o puede q no
        public void ChooseActionRealize(IActionable card, Bank bank);
        public Card SelectCardBank(List<Card> list);//este metodo quitarlo desp
        public int SelectCardDeck();//este metodo quitarlo desp
        public ICostable PlayBuyPhase();
    }

    public interface IActionable
    {
        public bool[] Actions {get;}

        public void GiveActions();
        public void SaveCards(int index, IPlayer a);
        public void ExecuteGetDeck(IPlayer a);
        public void Attack(int index,IPlayer a);
        public void Trash(IPlayer a);
        public void GainCard(IPlayer a);
    }
}
