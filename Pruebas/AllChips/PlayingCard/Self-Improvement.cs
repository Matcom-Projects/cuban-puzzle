namespace AppConsole
{
    public class SelfImprovement : Card, ICostable, IActionable
    {
        public int Cost{ get; }
        public bool[] Actions {get; set;}
        public string Id{ get; private set; }
        public SelfImprovement() : base("Self-Improvement", new string[]{"blue"}, 0)
        {
            this.Cost = 4;
            this.Actions = new bool[] {false, false, true, false, true, false};
            this.Id = GameUtils.CreateId();
        }

        private void GiveActions();
        private void SaveCards(int index, IPlayer a);
        public void ExecuteGetDeck(IPlayer a)
        {
            List<Card> indexs = new List<Card>();
            for(int i=0; i<3; i++)
            {
                indexs[i] = a.SelectCardDeck();
            }

            while(indexs.Count>0)
            {
                GameUtils.Move(a.Table.Deck, a.Table.DiscardPile, indexs[indexs.Count-1]);
                indexs.RemoveAt(indexs.Count-1);
            }
        }
        private void Attack(int index,IPlayer a);
        private void Trash(IPlayer a)
        {
            Card card = a.SelectCardHand();
            GameEngine.bank.Add(card);
            a.Table.HandCards.Remove(card);
        }
        private void GainCard(IPlayer a);

        /*Informacion de la carta:
        1. Coge tres cartas del deck
        2. Trashea una carta de su mano
        */
    }
}