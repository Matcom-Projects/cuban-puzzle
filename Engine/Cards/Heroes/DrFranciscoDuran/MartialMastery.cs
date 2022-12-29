namespace engine_cuban_puzzle;

public class MartialMastery : Card, IActionable
{
        public bool[] Actions {get; set;}
        public MartialMastery() : base("Martial Mastery", new string[]{"yellow"}, 0)
        {
            this.Actions = new bool[] {true, false, false, false, false, false};
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
            while(true)
            {    
                do
                {
                    card = a.Table.HandCards[a.SelectCardHand()];
                }while(card.Color.Contains("purple"));
            
            
                try
                {
                    GameEngine.bank.Add((BankCard)card);
                    break;
                }
                catch (System.InvalidCastException ex)
                {
                    System.Console.WriteLine("No se puede trashear un heroe");
                }
            }
            
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
