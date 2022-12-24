using System.Collections.Generic;
using System.Linq;
namespace AppConsole
{
    public class MartialMastery : Card, IActionable
    {
        public bool[] Actions {get; set;}
        public string Id{ get; private set; }
        public MartialMastery() : base("Martial Mastery", new string[]{"yellow"}, 0)
        {
            this.Actions = new bool[] {true, false, false, false, true, false};
            this.Id = GameUtils.CreateId();
        }
        private Card gain {get; set;}
        public void GiveActions()
        {
            GameEngine.CantActionsPerTurn ++;
        }

        private void SaveCards(int index, IPlayer a);
        private void ExecuteGetDeck(IPlayer a);
        private void Attack(int index,IPlayer a);

        public void Trash(IPlayer a)
        {
            do{
                Card card = a.Table.HandCards[a.SelectCardHand()];
            }while(card.Color.Contains("purple"));
            
            GameEngine.bank.Add(card);
            a.Table.HandCards.Remove(card);
            Actions[5] = true;
            gain = card;
            GameEngine.CantActionsPerTurn ++;
        }

        public void GainCard(IPlayer a)
        {
            List<Card> list = new List<Card>();
            foreach(var key in GameEngine.bank.GameGameEngine.bank.Keys)
            {
                if(key.Cost == (gain.Cost+2)) list.Add(key);
            }
            a.Table.DiscardPile.Add(GameEngine.bank.Get(a.SelectCardGameEngine.bank(list)));
        }

        /*Informacion de la carta:
        1. Da una accion mas
        2. Trashea una carta de su mano que no sea morada: (Da una accion mas y activa accion 2.1)
         2.1 Gana una carta que tenga costo exactamente 2 mas que la carta trasheada
        */
    }
}