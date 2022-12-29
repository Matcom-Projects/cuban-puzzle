namespace engine_cuban_puzzle;

public class GamePrint
    {
        public static void PrintTable(List<IPlayer> Players)
        {
            Console.Clear();
            foreach(IPlayer player in Players)
            {    
                if(player==GameEngine.Turns.Current)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Turno: ");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine(player.Name);
                System.Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
                PrintGemPile(player.Table.GemPile);
                PrintOnGoing(player.Table.OnGoing);
                if(player==GameEngine.Turns.Current)    
                    PrintHand(player.Table.HandCards);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
                System.Console.WriteLine();
            }
        }

        static void PrintGemPile( List <BankCard> GemPile )
        {
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"GemPile: ");
            Console.ForegroundColor = ConsoleColor.Green;
            PrintList(GemPile);
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PrintOnGoing(List<Card> OnGoing)
        {
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("On-Going: ");
            Console.ForegroundColor = ConsoleColor.Red;
            PrintList(OnGoing);
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PrintHand(List<Card> HandCards)
        {
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("Hand-Cards: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintList(HandCards);
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Presione [N] para un nuevo juego.");
            Console.WriteLine("Presione [E] para salir.");
        }
        public static ConsoleKey Read()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            return key;
        }

        public static int ChooseIndex(int min,int max)
        {
            return 0;
        }

        public static void PrintList(List<Card> list)//cambios Kpiro
        {
            for(int i=0; i<list.Count; i++)
            {
                System.Console.Write($"[{i}].{list[i].Name}  ");
            }
        }

        public static void PrintList(List<BankCard> list)//cambios Kpiro
        {
            for(int i=0; i<list.Count; i++)
            {
                System.Console.Write($"[{i}].{list[i].Name}  ");
            }
        }

        public static int SelectCard(List<Card> list)//cambios Kpiro
        {
            int index = int.MaxValue;
            while(index >= list.Count || index<0)
            {
                try
                {
                    System.Console.Write("Seleccione un elemento: ");                    
                    index = int.Parse(Console.ReadLine());
                    
                }
                catch (System.FormatException ex)
                {
                    System.Console.WriteLine("Debe digitar un numero");
                }
            }
            
            return index;
        }

        public static int SelectCard(List<BankCard> list)//cambios Kpiro
        {
            int index = int.MaxValue;
            while(index >= list.Count || index < 0)
            {
                try
                {
                    System.Console.Write("Seleccione un elemento: ");                    
                    index = int.Parse(Console.ReadLine());
                    
                }
                catch (System.FormatException ex)
                {
                    System.Console.WriteLine("Debe digitar un numero");
                }
            }
            
            return index;
        }

        public static int SelectCard(List<IPlayer> list)//cambios Kpiro
        {
            int index = int.MaxValue;
            while(index >= list.Count || index<0)
            {
                try
                {
                    System.Console.Write("Seleccione un elemento: ");                    
                    index = int.Parse(Console.ReadLine());
                    
                }
                catch (System.FormatException ex)
                {
                    System.Console.WriteLine("Debe digitar un numero");
                }
            }
            
            return index;
        }
    }
