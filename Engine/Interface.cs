namespace engine_cuban_puzzle;

public interface IPlayer
    {
        public string Name { get; }
        public TablePlayer Table { get; set; }
        
            public bool Exit();
            public bool ExistIActionable();
            public int SelectCardHand();
            public Card SelectCardOnGoing();
            public void ExecuteAction(IActionable card);
            public int SelectGem();
            public IPlayer SelectPlayer();
            public BankCard PlayBuyPhase();
            public bool PlayNextBuyPhases();
    }
    public interface IActionable
    {
        public void Action();
    }
