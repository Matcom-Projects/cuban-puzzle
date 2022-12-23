namespace AppConsole
{
    public class PlayingWithFire : Card, IActionable
    {
        public bool[] Actions {get; set;}
        public string Id{ get; private set; }
        public PlayingWithFire() : base("Playing With Fire", new string[]{"yellow"}, 0)
        {
            this.Actions = new bool[] {true, false, true, false, false, false};
            this.Id = GameUtils.CreateId();
        }

        public void GiveActions()
        {
            GameEngine.CantActionsPerTurn += 2;
        }
        private void SaveCards(int index);
        public void ExecuteGetDeck(IPlayer a)
        {
            int index = a.SelectCardDeck();
            GameUtils.Move(a.Table.Deck, a.Table.DiscardPile, index);
        }
        private void Attack(int index,IPlayer a);
        private void Trash(Bank bank, IPlayer a);
        private void GainCard(Bank bank, IPlayer a);

        /*Informacion de la carta:
        1. Da dos acciones mas
        2. Coge una carta del deck 
        */
    }
}