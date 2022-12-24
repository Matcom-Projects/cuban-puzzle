using System.Collections.Generic;
using System.Linq;
namespace engine_cuban_puzzle
{
    public class BurningVigor : Card, IActionable
    {
        public bool[] Actions { get; set; }
        public BurningVigor() : base("Burning Vigor", new string[]{"red"}, 0)
        {
            this.Actions = new bool[] {false, false, false, false, true, false};
        }
        public void GiveActions(){}
        public void SaveCards(int index, IPlayer a){}
        public void Draw(IPlayer a){}
        public void Attack(int index,IPlayer a){}
        public void Trash(IPlayer a)
        {
            if(a.Table.HandCards.Contains(new Cup()))
            {
                BankCard card = new Cup();
                GameEngine.bank.Add(card);
                a.Table.HandCards.Remove(card);
                GameEngine.CantActionsPerTurn++;
                foreach(var p in GameEngine.Turns.Players)
                {
                    if(p==a) continue;
                    p.Table.GemPile.Add(GameEngine.bank.Get(new Gem1()));
                }
                return;
            }
            else if(a.Table.DiscardPile.Contains(new Cup()))
            {
                BankCard card = new Cup();
                GameEngine.bank.Add(card);
                a.Table.DiscardPile.Remove(card);
                GameEngine.CantActionsPerTurn++;
                foreach(var p in GameEngine.Turns.Players)
                {
                    if(p==a) continue;
                    p.Table.GemPile.Add(GameEngine.bank.Get(new Gem1()));
                }
                return;
            }
        }
        public void GainCard(IPlayer a){}

        /*Informacion de la carta:
        1. Trashea un CUP de la mano o pila de descartes
         1.1 Da una accion mas y agrega una gem1 a la gema de pila de los oponentes
        */
    }
}