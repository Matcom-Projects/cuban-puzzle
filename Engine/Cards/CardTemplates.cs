namespace engine_cuban_puzzle;

public class BankCardByUser : BankCard
    {
        public BankCardByUser() : base (Result.Name, new string[] {Result.Color}, Result.Money, Result.Cost)
        {

        }
    }

    public class HeroeByUser : ActionCard
    {
        public HeroeByUser() : base(Result.Name, new string[]{Result.Color}, Result.Money)
        {
            
        }

        public override void Action(IPlayer a)
        {
            GameEngine.CantActionsPerTurn += Result.GiveAction;
            GameActions.Draw(Result.Draw, a);
        }
        
    }

    public class ActionCardByUser : ActionBankCard
    {
        public ActionCardByUser() : base(Result.Name, new string[]{Result.Color}, Result.Money, Result.Cost)
        {
            
        }

        public override void Action(IPlayer a)
        {
            GameEngine.CantActionsPerTurn += Result.GiveAction;
            GameActions.Draw(Result.Draw, a);
        }
    }
