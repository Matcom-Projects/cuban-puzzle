namespace AppConsole
{
    public class UnstablePower : Card, IActionable
    {
        public bool[] Actions {get; set;}
        public string Id{ get; private set; }
        public UnstablePower() : base("Unstable Power", new string[]{"purple"}, 0)
        {
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
            a.TablePlayer.DiscardPile.Add(bank.Get(new DobleCrashGem()));
            a.TablePlayer.DiscardPile.Add(bank.Get(new Cup()));
            a.TablePlayer.DiscardPile.Add(bank.Get(new Cup()));
        }

        /*Informacion de la carta:
        1. Gana un doble crash gem, pero tambien dos CUP 
        */
    }
}