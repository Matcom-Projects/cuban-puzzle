using cuban_puzzle_engine;
namespace cuban_puzzle;

class Program
{
    static void PrintMenu()
    {
        System.Console.WriteLine("Presione [N] para un nuevo juego.");
        System.Console.WriteLine("Presione [E] para salir.");
        System.Console.WriteLine("Presione [I] para saber la informacion de una carta.");
    }

    static void NewGame()
    {
        List<PlayingCard> choosecards = new List<PlayingCard>(); //Lista de cartas a escoger

        choosecards.Add(new PlayingCard(5,"yellow","Axe Kick",1,0,2,0,0));
        choosecards.Add(new PlayingCard(2,"yellow","Bang then Fizzle",2,0,2,0,0));
        choosecards.Add(new PlayingCard(3,"yellow","Button Machine",2,0,0,0,0));
        choosecards.Add(new PlayingCard(3,"yellow","Draw Three",0,0,3,0,0));
        choosecards.Add(new PlayingCard(5,"yellow","One of each",1,1,1,1,0));
        choosecards.Add(new PlayingCard(6,"yellow","Punch, Punch, Kick",2,0,1,0,0));
        choosecards.Add(new PlayingCard(1,"yellow","Safe Keeping",1,1,0,0,0));
        choosecards.Add(new PlayingCard(2,"yellow","Sales Price",0,0,0,2,0));
        choosecards.Add(new PlayingCard(6,"yellow","Lucky",1,1,3,0,0));
        choosecards.Add(new PlayingCard(7,"yellow","Boss",2,0,3,3,0));

        Bank bank = new Bank(choosecards);

        List<Card> InitialDeck = new List<Card>();
        InitialDeck.Add(new PlayingCard(5,"purple","crash gem",0,0,0,1,1));

        for(int i = 0 ; i < 6 ; i++)
        {
            InitialDeck.Add(new Gem (1,1));
        }

        List<Player> Players= new List<Player>();
        Players.Add(new Player("Manolo",new HeroCards("jose","yellow",1,0,1,0),InitialDeck));
        Players.Add( new Player("Juanito",new HeroCards("pedro","yellow",0,1,0,2),InitialDeck));
        
        // while(true)
        // {
            foreach(Player a in Players)
            {
                Console.Clear();
                a.GemPile.Add(new Gem(1,1));
                PrintTable(a);
                Console.ReadLine();//Esto se borra
            }
        // }
    }

    static void PrintTable(Player a)
    {
        List<Card> tableChoose = new List<Card>();
        int i = 0;
        Console.WriteLine("Ongoing:");
        foreach(Card l in a.Ongoing)
        {
            Console.WriteLine(i+"-"+l.Name);
            tableChoose.Add(l);
            i++;
        }
        Console.WriteLine("\n");


        int totalGem = 0;
        foreach(Gem l in a.GemPile)
        {
            totalGem += l.Count;
        }
        Console.WriteLine($"Gem Pile: {totalGem}\n");


        Console.WriteLine("Discard Pile:");
        foreach(Card l in a.DiscardPile)
        {
            Console.WriteLine(i+"-"+l.Name);
            tableChoose.Add(l);
            i++;
        }
        Console.WriteLine("\n");


        Console.WriteLine("Hand:");
        foreach(Card l in a.Hand)
        {
            Console.WriteLine(i+"-"+l.Name);
            tableChoose.Add(l);
            i++;
        }
        Console.WriteLine("\n");
    }

    static void Main()
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
                    NewGame();
                    break;
                }
                case ConsoleKey.E :
                {
                    return;
                } 
            }
        }
    }
}

// public class Phases
// {
//     public int actions = 1;
//     public int saveCard = 0;
//     public int deckRobbery = 0;
//     public int money = 0;

//     //En esta fase se roba una gema del banco hacia la pila de gemas       
//     public static void Ante()
//     {
//         Fields.GemPile.Add(new Gem(1,1)); 
//         Bank[Gem(1,1)] --;
//     }
    
//     //En esta fase se decide la accion que va a realizar a partir de las cartas que va a jugar 
//     public static void Action()
//     {
//         List<int> list = Actions.Choose(Fields.Hand);//Escoger una carta de mi mano (se puede hacer en el Main)
//         Card card = Fields.Hand[list[0]];
//         Fields.Ongoing.Add(card);//mandarla hacia Ongoing
//         Fields.Hand.Remove(card);
//         //Luego activar esta carta a partir de la funcionalidad que realiza
//         actions += card.Actions;
//         saveCard += card.SaveCard;
//         deckRobbery += card.DeckRobbery;
//         money += card.Money;
//     }
    
//     //En esta fase se decide la compra que va a realizar en funcion del dinero que tienes en la mano 
//     public static void Buy()
//     {
//         if(money <= 0)
//         {
//             while(money <= 0)
//             {
//                 Fields.DiscardPile.Add(new Wound());
//                 money++;
//             }
//         }
//         else
//         {
//             foreach(Gem a in Fields.Hand)
//             {
//                 money += a.Count;
//             }
//         }
//     }
    
//     //En esta fase todas las cartas que se quedaron en la mano y todas aquellas que se jugaron y no fueron
//     //trashadas se envian directamente hacia la pila de descartes         
//     public static void CleanUp()
//     {
//         int amountGem = Player.GemPile.Count;
//         if(amountGem<=2) Actions.Draw(5);
//         if(amountGem>=3 && amountGem<=5) Actions.Draw(6);
//         if(amountGem>=6 && amountGem<=8) Actions.Draw(7);
//         if(amountGem==9) Actions.Draw(8);
//         if(amountGem>=10) GameOver();
//     }
// }

// public class Actions
// {
//     public static List<int> Choose(List<Card> list)
//     {
//         for(int i=0; i<list.Count; i++)
//         {
//             Console.WriteLine((i+1)+list[i]);
//         }
//         List<int> pos = new List<int>();
//         do{
//             Console.WriteLine("Elija una opcion(#)/ NO hacerlo(-1): ");
//             int opc = Console.ReadLine();
//             if(p!=-1) pos.Add(opc-1);
//         }while(p!=-1);

//         return pos;
//     }

//     public static int SumElementsList(List<int> list)
//     {
//         int sum = 0;
//         foreach(var l in list)
//         {
//             sum += l;
//         }

//         return sum;
//     }

//     public static void Execute(Card card)
//     {

//     }
// }