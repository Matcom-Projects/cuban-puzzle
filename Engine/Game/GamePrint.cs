namespace engine_cuban_puzzle;

public class GamePrint
{
    public static void PrintTable(List<IPlayer> Players)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Turno: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        System.Console.WriteLine(GameEngine.Turns.Current.Name);
        System.Console.WriteLine();

        foreach(IPlayer player in Players)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
            PrintGemPile(player.Table.GemPile);
            PrintOnGoing(player.Table.OnGoing);
            PrintHand(player.Table.HandCards);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
        }
    }

    static void PrintGemPile( List <BankCard> GemPile )
    {
        System.Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"GemPile: ");
        for(int i = 0; i < GemPile.Count; i++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{i+1}]");
            Console.Write(GemPile[i]);
        }
        System.Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void PrintOnGoing(List<Card> OnGoing)
    {
        System.Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        System.Console.Write("On-Going: ");
        for(int i = 0; i < OnGoing.Count; i++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{i+1}]");
            Console.Write(OnGoing[i]);
        }
        System.Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void PrintHand(List<Card> HandCards)
    {
        System.Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        System.Console.Write("Hand-Cards: ");
        for(int i = 0; i < HandCards.Count; i++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{i+1}]");
            Console.Write(HandCards[i]);
        }
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
}