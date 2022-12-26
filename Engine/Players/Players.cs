namespace engine_cuban_puzzle;
using System;

public class ManualPlayer : IPlayer
    {
        public string Name { get; }
        public TablePlayer Table { get; set; }

        public ManualPlayer ( string name ) 
        {
            this.Name = name;
            this.Table = new TablePlayer();
        }

        public bool Exit()
        {
            Console.WriteLine("[J].Jugar fase de accion");
            Console.WriteLine("[E].Continuar");

            if(GamePrint.Read()==ConsoleKey.E) return true;

            return false;
        }

        public int SelectCardHand()
        {
            Console.WriteLine("De HandCards:");

            return GamePrint.SelectCard(Table.HandCards);
        }

        public Card SelectCardOnGoing()
        {
            Console.WriteLine("De OnGoing:");

            return Table.OnGoing[GamePrint.SelectCard(Table.OnGoing)];
        }

        public bool SelectField()
        {
            Console.WriteLine("[E].Escoger una carta de la mano");
            Console.WriteLine("[A].Activar una carta del OnGoing");
            ConsoleKey key = new ConsoleKey();
            do{
                key = Console.ReadKey(true).Key;
            }while(key!=ConsoleKey.A && key!=ConsoleKey.E);
            
            if(key==ConsoleKey.A) return true;

            return false;
        }

        public void ChooseActionRealize(IActionable card)
        {
            Console.WriteLine($"{((Card)card).Name} --> Acciones:");
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
                    card.SaveCards(SelectCardHand(),this);
                    break;
                }
                case ConsoleKey.R :
                {
                    card.Draw(this);
                    break;
                }
                case ConsoleKey.M :
                {
                    card.Attack(SelectGem(),SelectPlayer());
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

        public int SelectGem()
        {
            Console.WriteLine("De GemPile");

            return GamePrint.SelectCard(Table.GemPile);
        }

        public IPlayer SelectPlayer()
        {
            Console.WriteLine("Jugadores:");
            for(int i=0; i<GameEngine.Turns.Players.Count; i++)
            {
                if(GameEngine.Turns.Players[i]==this) continue;
                Console.WriteLine($"[{i}].{GameEngine.Turns.Players[i].Name}");
            }

            int index = 0;
            do{
                index = GamePrint.SelectCard(GameEngine.Turns.Players);
            }while(index == GameEngine.Turns.Players.IndexOf(this));

            return GameEngine.Turns.Players[index];
        }

        public BankCard PlayBuyPhase()
        {
            Console.Clear();
            Console.WriteLine($"Fase de Compra: {this.Name}");
            Console.WriteLine($"Cantidad de dinero: {GameEngine.CantMoneyPerTurn} $");
            for( int i = 0 ; i < GameEngine.bank.keys.Count ; i++ )
            {
                Console.WriteLine($"[{i+1}][{(GameEngine.bank.keys[i]).Name}] : {GameEngine.bank.keys[i].Cost} $");
            }
            Console.WriteLine();
            Console.WriteLine("Seleccione la carta que desea comprar.(Debe hacer obligatoriamente una compra por turno)");
            int index = int.Parse(Console.ReadLine());

            return GameEngine.bank.keys[index-1];
        }

        public bool PlayNextBuyPhases()
        {
            Console.Clear();
            System.Console.WriteLine("Desea finalizar ya la fase de compra??? [S]i o [N]o");
            ConsoleKey key = Console.ReadKey(true).Key;

            if(key == ConsoleKey.S) return true;
            return false;
        }

        public BankCard SelectCardBank(List<BankCard> list)
        {
            throw new NotImplementedException();
        }

        public int SelectCardDeck()
        {
            throw new NotImplementedException();
        }

    }
