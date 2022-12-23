namespace AppConsole
{
    public class CombosAreHard : Card, ICostable,IActionable
    {
        public int Cost{ get; }
        public bool[] Actions {get; set;}
        public string Id{ get; private set; }
        public CombosAreHard() : base("Combos Are Hard", new string[]{"yellow"}, 0)
        {
            this.Cost = 6;
            this.Actions = new bool[] {false, false, false, false, false, true};
            this.Id = GameUtils.CreateId();
        }

        private void GiveActions();
        private void SaveCards(int index);
        private void ExecuteGetDeck(IPlayer a);
        private void Attack(int index,IPlayer a);
        private void Trash(Bank bank, IPlayer a);
        public void GainCard(Bank bank, IPlayer a)
        {
            for(int i=0; i<2; i++)
            {
                List<Card> list = new List<Card>();
                foreach(var key in bank.GameBank.Keys)
                {
                    list.Add(key);
                }
                
                a.Table.DiscardPile.Add(bank.Get(a.SelectCardBank(list)));
            }

            bank.Add(this);
            a.Table.OnGoing.Remove(this);
        }

        /*Informacion de la carta:
        1. Gana dos cartas y despues trashea esta carta 
        */
    }
}