namespace engine_cuban_puzzle
{
    public class BankCardByUser : BankCard
    {
        public BankCardByUser() : base (Result.Name, new string[] {Result.Color}, Result.Money, Result.Cost)
        {

        }
    }

    public class HeroeByUser : Card, IActionable
    {
        public bool[] Actions {get; set;}
        public HeroeByUser() : base(Result.Name, new string[]{Result.Color}, Result.Money)
        {
            this.Actions = Result.MapActions;
        }
        public void GiveActions()
        {
            GameEngine.CantActionsPerTurn += Result.GiveAction;
        }

        public void SaveCards(int index, IPlayer a)
        {
            a.Table.HandToSaveCards(index);
        }
        public void Draw(IPlayer a)
        {
            a.Table.DrawDeck(Result.Draw);
        }
        public void Attack(int index,IPlayer a){}

        public void Trash(IPlayer a)
        {
                   
        }

        public void GainCard(IPlayer a)
        {
        }
    }

    public class ActionCardByUser : BankCard, IActionable
    {
        public bool[] Actions {get; set;}
        public ActionCardByUser() : base(Result.Name, new string[]{Result.Color}, Result.Money, Result.Cost)
        {
            this.Actions = Result.MapActions;
        }

        public void GiveActions()
        {
            GameEngine.CantActionsPerTurn += Result.GiveAction;
        }

        public void SaveCards(int index, IPlayer a)
        {
            a.Table.HandToSaveCards(index);
        }
        public void Draw(IPlayer a)
        {
            a.Table.DrawDeck(Result.Draw);
        }
        public void Attack(int index,IPlayer a){}

        public void Trash(IPlayer a)
        {
                   
        }

        public void GainCard(IPlayer a)
        {
        }
    }
}