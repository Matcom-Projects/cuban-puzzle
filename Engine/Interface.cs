namespace engine_cuban_puzzle;

public interface IPlayer
    {
        public string Name { get; }
        public TablePlayer Table { get; set; }
        
            public bool Exit();
            public int SelectCardHand();
            public Card SelectCardOnGoing();
            public bool SelectField();
            public void ChooseActionRealize(IActionable card);
            public int SelectGem();
            public IPlayer SelectPlayer();
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
