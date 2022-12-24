namespace AppConsole
{
    public class OneOfEach : Card, ICostable, IActionable
    {
        public int Cost{ get; }
        public bool[] Actions {get; set;}
        public string Id{ get; private set; }
        public OneOfEach() : base("One Of Each", new string[]{"yellow"}, 1)
        {
            this.Cost = 5;
            this.Actions = new bool[] {true, true, true, false, false, false};
            this.Id = GameUtils.CreateId();
        }

        public void GiveActions()
        {
            GameEngine.CantActionsPerTurn ++;
        }
        public void SaveCards(int index, IPlayer a)
        {
            GameUtils.Move(a.Table.HandCards, a.Table.SavedCards, index);
        }
        public void ExecuteGetDeck(IPlayer a)
        {
            int index = a.SelectCardDeck();
            GameUtils.Move(a.Table.Deck, a.Table.DiscardPile, index);
        }
        
        private void Attack(int index,IPlayer a);
        private void Trash(IPlayer a);
        private void GainCard(IPlayer a);

        /*Informacion de la carta:
        1. Da una accion mas y 1$ para la fase de compra
        2. Guarda una carta para el proximo turno
        3. Coge una carta del deck
        */
    }
}