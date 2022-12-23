namespace AppConsole.AllChips.Heroes.DrFrancicoDuran
{
    public class VersatileStyle : Card, IActionable
    {
        public bool[] Actions {get; set;}
        public string Id{ get; private set; }
        public VersatileStyle() : base("Versatile Style", new string[]{"yellow"}, 0)
        {
            this.Actions = new bool[] {true, true, true, false, false, false};
            this.Id = GameUtils.CreateId();
        }
        public void GiveActions()
        {
            GameEngine.CantActionsPerTurn ++;
            GameEngine.CantMoneyPerTurn += 2;
        }

        public void SaveCards(int index)
        {
            GameUtils.Move(TablePlayer.HandCards, TablePlayer.SavedCards, index);
        }
        public void ExecuteGetDeck(IPlayer a)
        {
            List<Card> indexs = new List<Card>();
            for(int i=0; i<2; i++)
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
        private void Trash(Bank bank, IPlayer a);
        private void GainCard(Bank bank, IPlayer a);

        /*Informacion de la carta:
        1. Da una accion mas y 2 pesos mas para la fase de compra
        2. Guarda una carta para el proximo turno
        3. Coge dos cartas del deck
         */
    }
}