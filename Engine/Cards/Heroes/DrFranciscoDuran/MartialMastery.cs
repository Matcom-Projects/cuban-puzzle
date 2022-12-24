using System.Collections.Generic;
using System.Linq;
namespace engine_cuban_puzzle
{
    public class MartialMastery : Card, IActionable
    {
        public bool[] Actions {get; set;}
        public MartialMastery() : base("Martial Mastery", new string[]{"yellow"}, 0)
        {
            this.Actions = new bool[] {true, false, false, false, true, false};
        }
        public void GiveActions()
        {
            GameEngine.CantActionsPerTurn ++;
        }

        public void SaveCards(int index, IPlayer a){}
        public void Draw(IPlayer a){}
        public void Attack(int index,IPlayer a){}

        public void Trash(IPlayer a)
        {
            Card card;
            do{
                card = a.Table.HandCards[a.SelectCardHand()];
            }while(card.Color.Contains("purple"));
            
            GameEngine.bank.Add((BankCard)card);
            a.Table.HandCards.Remove(card);
            Actions[5] = true;
            GameEngine.CantActionsPerTurn ++;
            GameEngine.CantMoneyPerTurn+= 4;        
        }

        public void GainCard(IPlayer a)
        {
        }

        /*Informacion de la carta:
        1. Da una accion mas
        2. Trashea una carta de su mano que no sea morada: (Da una accion mas y activa accion 2.1)
         2.1 Gana una carta que tenga costo exactamente 2 mas que la carta trasheada
        */
    }
}