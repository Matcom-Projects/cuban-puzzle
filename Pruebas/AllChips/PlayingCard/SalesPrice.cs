namespace AppConsole
{
    public class SalesPrice : Card, ICostable, IActionable
    {
        public int Cost{ get; }
        public bool[] Actions {get; set;}
        public string Id{ get; private set; }
        public SalesPrice() : base("Sales Price", new string[]{"yellow"}, 3)
        {
            this.Cost = 2;
            this.Actions = new bool[] {false, false, false, false, false, true};
            this.Id = GameUtils.CreateId();
        }

        private void GiveActions();
        private void SaveCards(int index, IPlayer a);
        private void ExecuteGetDeck(IPlayer a);
        private void Attack(int index,IPlayer a);
        private void Trash(IPlayer a);
        public void GainCard(IPlayer a)
        {
            a.TablePlayer.DiscardPile.Add(GamEngine.bank.Get(new Gem1()));
        }

        /*Informacion de la carta:
        1. Gana un gem1 y 3$ para la fase de compra
        */
    }
}