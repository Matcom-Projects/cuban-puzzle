using System.Collections.Generic;
namespace AppConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();
                PrintMenu();

                ConsoleKey key = Console.ReadKey(true).Key;
                Console.Clear();

                switch (key)
                {
                    case ConsoleKey.N :
                    {
                        LogIn();
                        PrintChooseActionCards(actionsCards);
                        GameEngine.LoadScenary();
                        dic = GameEngine.LoadScenary();
                        break;
                    }
                    case ConsoleKey.E :
                    {
                        return;
                    } 
                }
            }
        }

        static void PrintMenu()
        {
            System.Console.WriteLine("Presione [N] para un nuevo juego.");
            System.Console.WriteLine("Presione [E] para salir.");
        }

        public static List<Player> Players{get; private set;}//Jugadores
        public static List<Card> heroePlayer{get; private set;}//Heroes de cada jugador
        public static List<Card> actionCardsChoosed{get; private set;}//Cartas de accion a utilizar en el juego
        public static Dictionary<Player,Table> dic {get; set;}

        static void PrintLogIn()
        {
            Console.Clear();
            Console.WriteLine("\tIniciar sesion: ");
            Console.WriteLine("Elija modo de juego:");
            Console.WriteLine("[2]: 2 jugadores");
            Console.WriteLine("[3]: 3 jugadores");
            Console.WriteLine("[4]: 4 jugadores");
        }

        static void LogIn()
        {
            int opc = -1;
            while(opc<0 || opc>4)
            {
                PrintLogIn();
                opc = int.Parse(Console.ReadLine());
            }

            for(int i=0; i<opc; i++)
            {
                Console.Clear();
                PrintLogIn();
                Console.Write($"[{i}]Nombre: ");
                string name = Console.ReadLine();
                Players.Add(new Player(name));

                Console.Write("Heroe: ");
                heroePlayer.Add(ChooseHeroe(allHeroes, name)); 
                /*El metodo ChooseHeroe recibe una lista con todos los heroes(allHeroes, que hay que crearla)
                para escoger uno y ademas el nombre(name) del jugador que esta eligiendo su heroe */
            }
        }

        static Card ChooseHeroe(List<Card> heroes, string name)
        {
            Console.Clear();
            System.Console.WriteLine("Heroes:");
            for(int i=0; i<heroes.Count; i++)
            {
                Console.WriteLine($"[{i}].{heroes[i].Name}");
            }

            System.Console.WriteLine("\n");
            System.Console.WriteLine($"{name} elija un heroe:");
            int opc = int.Parse(Console.ReadLine());
            
            return heroes[opc];
        }

        static void PrintChooseActionCards(List<Card> actionsCards)
        //Este metodo recibe una lista con todas las cartas de acciones(actionsCards, que hay que crearla)
        {
            int opc = -1;
            Random r = new Random();
            int n = r.Next(0,Players.Count-1);

            System.Console.WriteLine("Eligiendo las cartas de accion para la partida:");
            System.Console.WriteLine("Nota: Cada jugador elige una carta de accion");
            System.Console.WriteLine($"Empieza a elegir {Players[n].Name} y despues le siguen los otros en orden");

            for(int j=0; j<actionsCards.Count; j++)
            {
                System.Console.WriteLine($"{j}.{actionsCards[j].Name}");
            }

            System.Console.WriteLine("\n");

            for(int i=0; i<10; i++)
            {
                while(opc<0 || opc>10)
                {
                    System.Console.Write($"Card{i}:");
                    opc = int.Parse(Console.ReadLine());
                }

                actionCardsChoosed.Add(actionsCards[opc]);
                opc = -1;
            }
        }
    }
}
