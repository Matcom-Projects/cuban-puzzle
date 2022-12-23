namespace AppConsole
{
    public class Knockdown : Card, ICostable, IActionable
    {
        public int Cost{ get; }
        public bool[] Actions {get; set;}
        public string Id{ get; private set; }
        public Knockdown() : base("Knockdown", new string[]{"red"}, 0)
        {
            this.Cost = 2;
            this.Actions = new bool[] {true, false, false, false, true, false};
            this.Id = GameUtils.CreateId();
        }

        public void GiveActions()
        {
            GameEngine.CantActionsPerTurn ++;
        }
        private void SaveCards(int index);
        private void ExecuteGetDeck(IPlayer a);
        private void Attack(int index,IPlayer a);
        public void Trash(Bank bank, IPlayer a)
        {
            IPlayer b = a.SelectPlayer(a);
            foreach (var card in b.Table.HandCards)
            {
                if(card.Color.Contains("purple"))
                {
                    bank.Add(card);
                    b.Table.HandCards.Remove(card);
                }
            }
        }
        private void GainCard(Bank bank, IPlayer a);

        /*Informacion de la carta:
        1. Da una accion mas
        2. Trashea una carta morada de la mano de un oponente seleccionado
        */
    }
}