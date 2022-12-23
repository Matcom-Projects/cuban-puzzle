namespace AppConsole
{
    public class SneackAttack : Card, ICostable, IActionable
    {
        public int Cost{ get; }
        public bool[] Actions {get; set;}
        public string Id{ get; private set; }
        public SneackAttack() : base("Sneack Attack", new string[]{"red"}, 0)
        {
            this.Cost = 3;
            this.Actions = new bool[] {true, false, false, false, false, true};
            this.Id = GameUtils.CreateId();
        }

        public void GiveActions()
        {
            GameEngine.CantActionsPerTurn ++;
        }
        private void SaveCards(int index);
        private void ExecuteGetDeck(IPlayer a);
        private void Attack(int index,IPlayer a);
        private void Trash(Bank bank, IPlayer a);
        public void GainCard(Bank bank, IPlayer a)
        {
            a.TablePlayer.DiscardPile.Add(bank.Get(new Gem1()));            
            foreach(var p in GameEngine.Turns.Players)
            {
                if(p==a) continue;
                p.Table.GemPile.Add(bank.Get(new Gem1()));
            }
        }

        /*Informacion de la carta:
        1. Da una accion mas
        2. Gana un gem1 y pone un gem1 en las pilas de gemas de los oponentes
        */
    }
}