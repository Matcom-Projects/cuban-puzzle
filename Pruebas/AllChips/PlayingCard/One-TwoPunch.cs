namespace AppConsole.AllChips.PlayingCards
{
    public class OneTwoPunch : Card, ICostable, IActionable
    {
        public int Cost{ get; }
        public bool[] Actions {get; set;}
        public string Id{ get; private set; }
        public OneTwoPunch() : base("One-Two Punch", new string[]{"yellow"}, 0)
        {
            this.Cost = 4;
            this.Actions = new bool[] {true, false, false, false, false, false};
            this.Id = GameUtils.CreateId();
        }

        public void GiveActions()
        {
            GameEngine.CantActionsPerTurn += 2;
        }
        private void SaveCards(int index);
        private void ExecuteGetDeck(IPlayer a);
        private void Attack(int index,IPlayer a);
        private void Trash(Bank bank, IPlayer a);
        private void GainCard(Bank bank, IPlayer a);

        /*Informacion de la carta:
        1. Da dos acciones mas
        */
    }
}