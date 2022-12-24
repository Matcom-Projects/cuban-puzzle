namespace engine_cuban_puzzle
{
    public class SelfImprovement : BankCard, IActionable
    {
        public bool[] Actions {get; set;}
        public SelfImprovement() : base("Self-Improvement", new string[]{"blue"}, 0,4)
        {
            this.Actions = new bool[] {false, false, true, false, true, false};
        }

        public void GiveActions(){}
        public void SaveCards(int index, IPlayer a){}
        public void Draw(IPlayer a)
        {
            a.Table.DrawDeck(3);
        }
        public void Attack(int index,IPlayer a){}
        public void Trash(IPlayer a)
        {
            Card card = a.Table.HandCards[a.SelectCardHand()];
            GameEngine.bank.Add((BankCard)card);
            a.Table.HandCards.Remove(card);
        }
        public void GainCard(IPlayer a){}

        /*Informacion de la carta:
        1. Coge tres cartas del deck
        2. Trashea una carta de su mano
        */
    }
}