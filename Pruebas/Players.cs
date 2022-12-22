using System.Collections.Generic;
using System;
using System.Diagnostics;
namespace AppConsole //cambios
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

        public void SelectCardHand()
        {
            Console.Clear();
            Console.WriteLine("HandCards:");
            for(int i=0; i<Table.HandCards; i++)
            {
                Console.WriteLine($"[{i}].{Table.HandCards[i].Name}");
            }
            Console.WriteLine("Escoja una carta: ");
            int opc = int.Parse(Console.ReadLine());

            GameUtils.Move(a.Table.HandCards, a.Table.OnGoing, opc);//moverla hacia el ongoing
        }

        public Card SelectCardOnGoing()
        {
            Console.Clear();
            Console.WriteLine("OnGoing:");
            for(int i=0; i<Table.OnGoing; i++)
            {
                Console.WriteLine($"[{i}].{Table.OnGoing[i].Name}");
            }
            Console.WriteLine("Escoja una carta: ");
            int opc = int.Parse(Console.ReadLine());

            return Table.OnGoing[opc];
        }

        public bool SelectField()
        {
            Console.WriteLine("[E].Escoger una carta de la mano");
            Console.WriteLine("[A].Activar una carta del OnGoing");
            ConsoleKey key = new ConsoleKey.ReadKey(true).Key;

            if(key==ConsoleKey.A) return true;

            return false;
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
                    card.ExecuteGetDeck();
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
                    card.Trash(bank,this);
                    break;
                }
                case ConsoleKey.G :
                {
                    card.GainCard(bank,this);
                    break;
                }
            }

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
