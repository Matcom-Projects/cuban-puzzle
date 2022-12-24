using System.Linq;
using System.Collections.Generic;
using System;
using System.Diagnostics;
namespace AppConsole //cambios 3.0
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

        public int SelectHero(List<Card> HeroCards)
        {
            return int.Parse(Console.ReadLine());
        }

        public int SelectCardHand()
        {
            Console.Clear();
            Console.WriteLine("HandCards:");
            for(int i=0; i<Table.HandCards.Count; i++)
            {
                Console.WriteLine($"[{i}].{Table.HandCards[i].Name}");
            }
            Console.WriteLine("Escoja una carta: ");
            int opc = int.Parse(Console.ReadLine());

            return opc;
        }

        public Card SelectCardOnGoing()
        {
            Console.Clear();
            Console.WriteLine("OnGoing:");
            for(int i=0; i<Table.OnGoing.Count; i++)
            {
                Console.WriteLine($"[{i}].{Table.OnGoing[i].Name}");
            }
            Console.WriteLine("Escoja una carta: ");
            int opc = int.Parse(Console.ReadLine());

            return Table.OnGoing[opc];
        }

        public bool SelectField()
        {
            Console.Clear();
            Console.WriteLine("[E].Escoger una carta de la mano");
            Console.WriteLine("[A].Activar una carta del OnGoing");
            ConsoleKey key = new ConsoleKey.ReadKey(true).Key;

            if(key==ConsoleKey.A) return true;

            return false;
        }

        public int SelectGem()
        {
            Console.WriteLine("GemPile:");
            for(int i=0; i<Table.GemPile.Count; i++)
            {
                Console.WriteLine($"[{i}].{Table.GemPile[i].Name}");
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

        public bool Exit()
        {
            Console.Clear();
            Console.WriteLine("[J].Jugar fase de accion");
            Console.WriteLine("[E].Continuar");
            ConsoleKey key = new ConsoleKey.ReadKey(true).Key;

            if(key==ConsoleKey.E) return true;

            return false;
        }

        public void ChooseActionRealize(IActionable card)
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
                    card.SaveCards(index, this);
                    break;
                }
                case ConsoleKey.R :
                {
                    card.ExecuteGetDeck(this);
                    break;
                }
                case ConsoleKey.M :
                {
                    int index = SelectGem();
                    card.Attack(index,SelectPlayer(this));
                    break;
                }
                case ConsoleKey.T :
                {
                    card.Trash(this);
                    break;
                }
                case ConsoleKey.G :
                {
                    card.GainCard(this);
                    break;
                }
            }

        }

        public Card SelectCardBank(List<Card> list)
        {
            Console.Clear();
            Console.WriteLine("Bank:");
            for(int i=0; i<list.Count; i++)
            {
                Console.WriteLine($"[{i}].{list[i].Name}");
            }
            Console.WriteLine("Escoja una carta: ");
            int opc = int.Parse(Console.ReadLine());

            return list[opc];
        }
        public int SelectCardDeck()
        {
            Console.WriteLine("Deck:");
            for(int i=0; i<Table.Deck.Count; i++)
            {
                Console.WriteLine($"[{i}].{Table.Deck[i].Name}");
            }
            Console.WriteLine("Escoja una carta: ");
            int opc = int.Parse(Console.ReadLine());

            return opc;
        }

        public ICostable PlayBuyPhase()
        {
            return null;
        }

        public void PlayCleanUpPhase()
        {
            
        }

        
    }
}
