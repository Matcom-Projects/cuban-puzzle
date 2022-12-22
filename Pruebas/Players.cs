using System.Collections.Generic;
using System;
using System.Diagnostics;
namespace AppConsole
{
    public class ManualPlayer : IPlayer
    {
        public string Name { get; }
        public TablePlayer Table { get; set; }

        public ManualPlayer ( string name ) 
        {
            this.Name = name;
            this.Table=new TablePlayer();
        }

        public int SelectActionCard(List<ICostable> ActionsCards)
        {
            return int.Parse(Console.ReadLine());
        }

        public int SelectHero()
        {
            return 0;
        }

        public int SelectCardHand()
        {
            Console.Clear();
            Console.WriteLine("HandCards:");
            for(int i=0; i<TablePlayer.HandCards; i++)
            {
                Console.WriteLine($"[{i}].{TablePlayer.HandCards[i].Name}");
            }
            Console.WriteLine("Escoja una carta: ");
            int opc = int.Parse(Console.ReadLine());

            return opc;
        }

        public Card SelectCardOnGoing()
        {
            Console.Clear();
            Console.WriteLine("OnGoing:");
            for(int i=0; i<TablePlayer.OnGoing; i++)
            {
                Console.WriteLine($"[{i}].{TablePlayer.OnGoing[i].Name}");
            }
            Console.WriteLine("Escoja una carta: ");
            int opc = int.Parse(Console.ReadLine());

            return TablePlayer.OnGoing[opc];
        }

        public int SelectGem()
        {
            Console.WriteLine("GemPile:");
            for(int i=0; i<TablePlayer.GemPile; i++)
            {
                Console.WriteLine($"[{i}].{TablePlayer.GemPile[i].Name}");
            }
            Console.WriteLine("Escoja una gema: ");
            int opc = int.Parse(Console.ReadLine());

            return opc;
        }

        public IPlayer SelectPlayer(IPlayer a)
        {
            Console.WriteLine("Jugadores:");
            for(int i=0; i<GameEngine.Turns.Players.Count; i++)
            {
                if(GameEngine.Turns.Players[i]==a) continue;
                Console.WriteLine($"[{i}].{GameEngine.Turns.Players[i].Name}");
            }
            Console.WriteLine("Escoja un jugador: ");
            int opc = int.Parse(Console.ReadLine());

            return GameEngine.Turns.Players[opc];
        }

        public void ChooseActionRealize(Card card, Bank bank)
        {
            Console.Clear();
            Console.WriteLine("Acciones:");
            if(card.Actions[0]) Console.WriteLine("[D].Dar acciones");
            if(card.Actions[1]) Console.WriteLine("[S].Guardar carta para el proximo turno");
            if(card.Actions[2]) Console.WriteLine("[R].Robar cartas del deck");
            if(card.Actions[3]) Console.WriteLine("[M].Meter un toque");
            if(card.Actions[4]) Console.WriteLine("[T].Trashear");
            if(card.Actions[5]) Console.WriteLine("[G].Ganar cartas");
            ConsoleKey key = Console.ReadKey(true).Key;

            switch(key)
            {
                case ConsoleKey.D :
                {
                    card.GiveActions();
                    break;
                }
                case ConsoleKey.S :
                {
                    int index = SelectCardHand();
                    card.SaveCards(index);
                    break;
                }
                case ConsoleKey.R :
                {
                    card.GetDeck();
                    break;
                }
                case ConsoleKey.M :
                {
                    int index = SelectGem();
                    card.Attack(index,SelectPlayer(this));
                    a.TablePlayer.GemPile.RemoveAt(index);
                    break;
                }
                case ConsoleKey.T :
                {
                    
                }
            }

        }

        public void PlayBuyPhase()
        {
            
        }

        public void PlayCleanUpPhase()
        {
            
        }

        
    }
}
