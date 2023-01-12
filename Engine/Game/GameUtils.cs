namespace engine_cuban_puzzle;

public class GameUtils
{
    public static void Move ( List<Card> a , List<Card> b , int index )
    {
        b.Add(a[index]);
        a.RemoveAt(index);
    }
    public static List<IPlayer> MixPlayers(List<IPlayer> a)
    {
        List<IPlayer> result = new List<IPlayer>();    
        int index;

        while(a.Count != 0)
        {
            index = GetRandom(0,a.Count);
            result.Add(a[index]);
            a.RemoveAt(index);
        }

        return result;
    }

    public static int GetRandom(int min,int max)
    {
        Random e = new Random();
        return e.Next(min,max);
    }
    public static string CreateId ()//para cuando se haga la ast
    {
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        string result = "";
        Random e = new Random();

        for( int i = 0 ; i < 8 ; i++ )
        {
            result += letters [ e.Next(0,letters.Length) ];
        }

        return result;
    }
    
    public static void InformationCard()
    {
        Console.WriteLine("Informacion de las cartas");
        ConsoleKey key = GamePrint.Read();
        do{
            Console.Clear();
            Console.WriteLine("[B].BankCards");
            Console.WriteLine("[H].HeroCards");

            switch(key)
            {
                case ConsoleKey.B: 
                {
                    Console.Clear();
                    System.Console.WriteLine("BankCards:");
                    for(int i=0; i<GameEngine.bank.keys.Count; i++)
                    {
                        System.Console.WriteLine($"[{i}].{GameEngine.bank.keys[i].Name}  ");
                    }
                    int index = GamePrint.SelectCard(GameEngine.bank.keys);

                    Console.Clear();
                    System.Console.WriteLine($"{GameEngine.bank.keys[index].Name}:");
                    System.Console.WriteLine($"{GameEngine.bank.keys[index].Information}:");
                    return;
                }
                case ConsoleKey.H:
                {
                    Console.Clear();
                    System.Console.WriteLine("HeroCards:");
                    for(int j = 0; j < CreateCards.AllHeroCards.Count; j++)
                    {
                        System.Console.WriteLine($"[{j}].{CreateCards.AllHeroCards[j].Name}  ");
                    }
                    int pos = GamePrint.SelectCard(CreateCards.AllHeroCards);

                    Console.Clear();
                    System.Console.WriteLine($"{CreateCards.AllHeroCards[pos].Name}:");
                    System.Console.WriteLine($"{CreateCards.AllHeroCards[pos].Information}:");
                    return;
                } 
            }

        }while(key!=ConsoleKey.B && key!=ConsoleKey.H);

    }

    public static void CombineFunction(int gems)
    {
        IPlayer a = GameEngine.Turns.Current;
        int money = 0;
        List<int> indexs = new List<int>();
        do{
            money = 0;
            indexs.Clear();
            for(int i=0; i<gems; i++)
            {
                Card x;
                do{
                    x = a.Table.GemPile[a.SelectGem()];
                }while(x is Gem4);
                money += x.Money;
                indexs.Add(a.Table.GemPile.IndexOf(x));
            }
            System.Console.WriteLine();
        }while(money>4);

        if(money == 2) a.Table.GemPile.Add(GameEngine.bank.Get(GameEngine.bank.keys[1]));
        if(money == 3) a.Table.GemPile.Add(GameEngine.bank.Get(GameEngine.bank.keys[2]));
        if(money == 4) a.Table.GemPile.Add(GameEngine.bank.Get(GameEngine.bank.keys[3]));

        indexs.Sort();
        for(int j = indexs.Count-1; j >= 0; j--)
        {
            GameEngine.bank.Add((BankCard)a.Table.GemPile[j]);
            a.Table.GemPile.RemoveAt(j);
        }
    }
}
