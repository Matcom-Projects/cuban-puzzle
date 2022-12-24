namespace AppConsole
{
    public class DrawThree : Card, ICostable, IActionable
    {
        public int Cost{ get; }
        public bool[] Actions {get; set;}
        public string Id{ get; private set; }
        public DrawThree() : base("Draw Three", new string[]{"yellow"}, 0)
        {
            this.Cost = 3;
            this.Actions = new bool[] {false, false, true, false, false, false};
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
        private void Trash(IPlayer a);
        private void GainCard(IPlayer a);

        /*Informacion de la carta:
        1. Coge tres cartas del deck
        */
    }
}