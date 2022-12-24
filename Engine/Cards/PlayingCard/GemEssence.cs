namespace AppConsole
{
    public class GemEssence : Card, ICostable, IActionable
    {
        public int Cost{ get; }
        public bool[] Actions {get; set;}
        public string Id{ get; private set; }
        public GemEssence() : base("Gem Essence", new string[]{"yellow"}, 0)
        {
            this.Cost = 3;
            this.Actions = new bool[] {false, false, false, false, true, false};
            this.Id = GameUtils.CreateId();
        }

        private void GiveActions();
        private void SaveCards(int index, IPlayer a);
        private void ExecuteGetDeck(IPlayer a);
        private void Attack(int index,IPlayer a);
        public void Trash(IPlayer a)
        {
            if(a.Table.HandCards.Contains(new Gem1()))
            {
                Card card = new Gem1();
                GameEngine.bank.Add(card);
                a.Table.HandCards.Remove(card);
                GameEngine.CantActionsPerTurn++;
            }
        }
        private void GainCard(IPlayer a);

        /*Informacion de la carta:
        1. Trashea una gema de 1 y tienes una accion mas
        */
    }
}