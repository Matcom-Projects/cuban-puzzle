using System.Collections.Generic;
using System.Linq;
namespace AppConsole
{
    public class BurningVigor : Card, IActionable
    {
        public bool[] Actions {get; set;}
        public string Id{ get; private set; }
        public BurningVigor() : base("Burning Vigor", new string[]{"red"}, 0)
        {
            this.Actions = new bool[] {false, false, false, false, true, false};
            this.Id = GameUtils.CreateId();
        }
        private void GiveActions();
        private void SaveCards(int index);
        private void ExecuteGetDeck(IPlayer a);
        private void Attack(int index,IPlayer a);
        public void Trash(Bank bank, IPlayer a)
        {
            if(a.Table.HandCards.Contains(new Cup()))
            {
                Card card = new Cup();
                bank.Add(card);
                a.Table.HandCards.Remove(card);
                GameEngine.CantActionsPerTurn++;
                foreach(var p in GameEngine.Turns.Players)
                {
                    if(p==a) continue;
                    p.Table.GemPile.Add(bank.Get(new Gem1()));
                }
                return;
            }
            else if(a.Table.DiscardPile.Contains(new Cup()))
            {
                Card card = new Cup();
                bank.Add(card);
                a.Table.DiscardPile.Remove(card);
                GameEngine.CantActionsPerTurn++;
                foreach(var p in GameEngine.Turns.Players)
                {
                    if(p==a) continue;
                    p.Table.GemPile.Add(bank.Get(new Gem1()));
                }
                return;
            }
        }
        private void GainCard(Bank bank, IPlayer a);

        /*Informacion de la carta:
        1. Trashea un CUP de la mano o pila de descartes
         1.1 Da una accion mas y agrega una gem1 a la gema de pila de los oponentes
        */
    }
}