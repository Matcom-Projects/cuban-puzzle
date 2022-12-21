using engine_cuban_puzzle;
namespace console_cuban_puzzle;
// class Game
// {
//     public static Bank bank {get; private set;}
//     public static List<Player> Players{get;private set;}
//     public static void NewGame()
//     {
//         List<PlayingCard> choosecards = new List<PlayingCard>(); //Lista de cartas a escoger

//         choosecards.Add(new PlayingCard(5,"yellow","Axe Kick",1,0,2,0,0,new bool[] {true,false,true,false}));
//         choosecards.Add(new PlayingCard(2,"yellow","Bang then Fizzle",2,0,2,0,0,new bool[] {true,false,true,false}));
//         choosecards.Add(new PlayingCard(3,"yellow","Button Machine",2,0,0,0,0,new bool[] {true,false,false,false}));
//         choosecards.Add(new PlayingCard(3,"yellow","Draw Three",0,0,3,0,0,new bool[] {false,false,true,false}));
//         choosecards.Add(new PlayingCard(5,"yellow","One of each",1,1,1,0,1,new bool[] {true,true,true,false}));
//         choosecards.Add(new PlayingCard(6,"yellow","Punch, Punch, Kick",2,0,1,0,0,new bool[] {true,false,true,false}));
//         choosecards.Add(new PlayingCard(1,"yellow","Safe Keeping",1,1,0,0,0,new bool[] {true,true,false,false}));
//         choosecards.Add(new PlayingCard(2,"yellow","Sales Price",0,0,0,0,2,new bool[] {false,false,false,false}));
//         choosecards.Add(new PlayingCard(6,"yellow","Lucky",1,1,3,0,0,new bool[] {true,true,true,false}));
//         choosecards.Add(new PlayingCard(7,"yellow","Boss",2,0,3,0,3,new bool[] {true,false,true,false}));

//         bank = new Bank(choosecards);

//         List<Card> InitialDeck = new List<Card>();
//         InitialDeck.Add(new CrashGem());

//         for(int i = 0 ; i < 6 ; i++)
//         {
//             InitialDeck.Add(new Gem (1,1));
//         }

//         Players= new List<Player>();
//         Players.Add(new Player("Manolo",new HeroCards("jose","yellow",1,0,1,0),InitialDeck));
//         Players.Add( new Player("Juanito",new HeroCards("pedro","yellow",0,1,0,2),InitialDeck));
                
//         foreach(Player a in Players)
//         {
//             a.Draw(5);
//         }
        
//         bool gameOver = false;
//         while(!gameOver)
//         {
//             foreach(Player a in Players)
//             {
//                 Console.Clear();
//                 a.GemPile.Add(new Gem(1,1));
                
//                 Turn(a);

                
//                 gameOver = GameOver(a.GemPile.Count);
//                 if(gameOver) 
//                 {
//                     Console.Clear();
//                     Console.WriteLine($"Has perdido {a}. Suerte para la próxima mi pana");
//                     Console.WriteLine("Presione [Enter] para volver al menú"); Console.ReadLine();break;
//                 }
//             }
//         }
        
//     }

//     static void PrintTable(Player a)
//     {
//         Console.WriteLine($"     Jugador {a}:");
//         Console.Write("Hand: ");
//         for(int i=0;i < a.Hand.Count ;i++)
//         {        
//             Console.Write($" [{i}]-[{a.Hand[i].Name}] ");
//         }
//         Console.WriteLine("\n");

//         Console.Write("Gem Pile: ");
//         for(int i = 0; i<a.GemPile.Count;i++)
//         {
//             Console.Write($" [{i}]-{a.GemPile[i]} ");
//         }
//         Console.WriteLine("\n");

//         Console.Write("Ongoing:");
//         for(int i =0 ; i<a.Ongoing.Count; i++)
//         {
//             Console.Write($" [{i}]-[{a.Ongoing[i].Name}] ");
//         }
//         Console.WriteLine("\n");
//     }

//     static void Turn(Player a)
//     {
//         PhaseActions(a);
//         PhaseBuy(a);
//         PhaseCleanUp(a);
//     }

//     static void PhaseActions(Player a)
//     {
//         while(a.NumberActions > 0)
//         {
//             Console.Clear();
//             System.Console.WriteLine("Fase de accion");
//             System.Console.WriteLine("Acciones: "+a.NumberActions);
//             PrintTable(a);
//             System.Console.WriteLine("[M] Mover una carta de la mano al OnGoing");
//             System.Console.WriteLine("[A] Jugar una accion de una carta del OnGoing");
//             System.Console.WriteLine("[F] Finalizar fase de accion");
//             ConsoleKey key = Console.ReadKey(true).Key;

//             switch (key)
//             {
//                 case ConsoleKey.M :
//                 {
//                     ToOnGoing(a);
//                     break;
//                 }
//                 case ConsoleKey.A :
//                 {
//                     ExecuteAction(a);
//                     break;
//                 }
//                 case ConsoleKey.F :
//                 {
//                     return;
//                 } 
//             }
//         }
//     }

//     static void ExecuteAction(Player a)
//     {
//         int opc;
//         Console.Clear();
//         PrintTable(a);
//         Console.WriteLine("Elija una carta del OnGoing"); 
//         opc = int.Parse(Console.ReadLine());
        
//         if(opc < a.Ongoing.Count && opc >= 0)
//         {
//             Console.Clear();
//             PrintTable(a);
//             Console.WriteLine("Que accion quiere realizar: ");
//             if(((PlayingCard)a.Ongoing[opc]).GameStateActions[0]) Console.WriteLine("[D] Dar acciones");
//             if(((PlayingCard)a.Ongoing[opc]).GameStateActions[1]) Console.WriteLine("[S] Guardar una carta para el proximo turno");
//             if(((PlayingCard)a.Ongoing[opc]).GameStateActions[2]) Console.WriteLine("[R] Coger cartas del deck");
//             if(((PlayingCard)a.Ongoing[opc]).GameStateActions[3]) Console.WriteLine("[F] Meterle un toque a alguien");
//             ConsoleKey key = Console.ReadKey(true).Key;

//             switch (key)
//             {
//                 case ConsoleKey.D :
//                 {
//                     a.Actions(((PlayingCard)a.Ongoing[opc]).Actions);
//                     ((PlayingCard)a.Ongoing[opc]).GameStateActions[0] = false;
//                     break;
//                 }
//                 case ConsoleKey.S :
//                 {
//                     opc=-1;
//                     while(true)
//                     {
//                         Console.Clear();
//                         PrintTable(a);
//                         Console.WriteLine("Elija que carta de su mano quiere guardar para el proximo turno"); 
//                         opc = int.Parse(Console.ReadLine());
//                         if(opc < a.Hand.Count && opc >= 0)
//                         {
//                             a.SaveCard(a.Hand[opc]);
//                             a.Hand.RemoveAt(opc);
//                             ((PlayingCard)a.Ongoing[opc]).GameStateActions[1] = false;
//                             break;
//                         }
//                     }
//                     break;
//                 } 
//                 case ConsoleKey.R :
//                 {
//                     a.Draw(((PlayingCard)a.Ongoing[opc]).DeckRobbery);
//                     ((PlayingCard)a.Ongoing[opc]).GameStateActions[2] = false;
//                     break;
//                 }
//                 case ConsoleKey.F :
//                 {
//                     a.Attack(SelectGem(a),SelectPlayer(a));
//                     ((PlayingCard)a.Ongoing[opc]).GameStateActions[3] = false;
//                     break;
//                 }
//             }

//             a.NumberActions--;
//         }
//     }
//     static Player SelectPlayer(Player a)
//     {
//         Console.Clear();
//         for(int i = 0;i<Players.Count;i++)
//         {   
//             if(Players[i]==a) continue;
//             Console.WriteLine(i+"-"+Players[i].Name);
//         }
//         System.Console.WriteLine();

//         int opc = -1;
//         while(!(opc < Players.Count) || !(opc >= 0))
//         {
//             Console.WriteLine("Elija el jugador que vas a meterle un toque"); 
//             opc = int.Parse(Console.ReadLine());
//         }

//         return Players[opc];
//     }

//     static List<Gem> SelectGem(Player a)
//     {
//         List<Gem> result = new List<Gem>();
//         int opc = -1;

//         while(!(opc < a.GemPile.Count) || !(opc >= 0))
//         {
//             Console.Clear();
//             PrintTable(a);
//             Console.WriteLine("Elija una Gema"); 
//             opc = int.Parse(Console.ReadLine());
//         }

//         for(int i =0 ;i < a.GemPile[opc].Count ;i++)
//         {
//             result.Add(bank.gem1);
//         }

//         a.GemPile.RemoveAt(opc);

//         return result;
//     }

//     static void ToOnGoing(Player a)
//     {
//         int opc;
        
//         while(true)
//         {
//             Console.Clear();
//             PrintTable(a);
//             Console.WriteLine("Elija una carta de su mano"); 
//             opc = int.Parse(Console.ReadLine());
            
//             if(opc < a.Hand.Count && opc >= 0 && (a.Hand[opc] is PlayingCard ))
//             {
//                 a.CantMoney += ((PlayingCard)a.Hand[opc]).Money;
//                 a.Ongoing.Add(a.Hand[opc]);
//                 a.Hand.RemoveAt(opc);
//                 break;
//             }
//         }
//     }
//     static void PhaseBuy(Player a)
//     {
//         Console.Clear();
//         foreach(Card l in a.Hand)
//         {
//             if(l is Gem)
//             {
//                 a.CantMoney += ((Gem)l).Count;
//             }
//         }

//         if(a.CantMoney <= 0)
//         {
//             while(a.CantMoney<=0)
//             {
//                 a.Ongoing.Add(bank.wound);
//                 a.CantMoney++;
//             }
//         }
//         else
//         {
//             while(a.CantMoney > 0)
//             {
//                 Console.Clear();
//                 Console.WriteLine("Fase de Compra");
//                 Console.WriteLine("Jugador: " + a.Name);
//                 Console.WriteLine("Dinero: "+ a.CantMoney+" $");
//                 Console.WriteLine("[D] Comprar Dinero");
//                 Console.WriteLine("[C] Comprar CrashGem");
//                 Console.WriteLine("[A] Comprar cartas");
//                 Console.WriteLine("[F] Finalizar fase de compra");
//                 ConsoleKey key = Console.ReadKey(true).Key;

//                 switch (key)
//                 {
//                     case ConsoleKey.D :
//                     {
//                         BuyGems(a);
//                         break;
//                     }
//                     case ConsoleKey.C :
//                     {
//                         if(a.CantMoney-bank.crashgem.Cost >= 0) 
//                         {
//                             a.Ongoing.Add(bank.crashgem) ;
//                             a.CantMoney = a.CantMoney-bank.crashgem.Cost;
//                         }
//                         break;
//                     }
//                     case ConsoleKey.A :
//                     {
//                         BuyCarts(a);
//                         break;
//                     } 
//                     case ConsoleKey.F :
//                     {
//                         return;
//                     }
//                 }
//             }
//         }
//     }

//     static void BuyCarts(Player a)
//     {
//         int opc;
//         while(true)
//         {
//             Console.Clear();
//             PrintBankCartPhaseBuy();
//             opc = int.Parse(Console.ReadLine());

//             if(opc >=0 && opc < bank.bank.Count)
//             {
//                 if(a.CantMoney - bank.bank.ElementAt(opc).Key.Cost >=0 && bank.bank.ElementAt(opc).Value > 0 )
//                 {
//                     a.Ongoing.Add(bank.bank.ElementAt(opc).Key);
//                     bank.bank[bank.bank.ElementAt(opc).Key]--;
//                     a.CantMoney = a.CantMoney - bank.bank.ElementAt(opc).Key.Cost;
//                 }
//                 break;
//             }
//         }
//     }

//     static void BuyGems(Player a)
//     {
//         Console.Clear();
//         Console.WriteLine($"[A]-{bank.gem1}: {bank.gem1.Cost} $");
//         Console.WriteLine($"[B]-{bank.gem2}: {bank.gem2.Cost} $");
//         Console.WriteLine($"[C]-{bank.gem3}: {bank.gem3.Cost} $");
//         Console.WriteLine($"[D]-{bank.gem4}: {bank.gem4.Cost} $");

//         ConsoleKey key = Console.ReadKey(true).Key;

//         switch(key)
//         {
//             case ConsoleKey.A:
//             {
//                 if(a.CantMoney-bank.gem1.Cost >= 0) 
//                 {
//                     a.DiscardPile.Add(bank.gem1) ;
//                     a.CantMoney = a.CantMoney-bank.gem1.Cost;
//                 }
//                 return;
//             }
//             case ConsoleKey.B:
//             {
//                 if(a.CantMoney-bank.gem2.Cost >= 0) 
//                 {
//                     a.DiscardPile.Add(bank.gem2) ;
//                     a.CantMoney = a.CantMoney-bank.gem2.Cost;
//                 }
//                 return;
//             }
//             case ConsoleKey.C:
//             {
//                 if(a.CantMoney-bank.gem3.Cost >= 0) 
//                 {
//                     a.DiscardPile.Add(bank.gem3) ;
//                     a.CantMoney = a.CantMoney-bank.gem3.Cost;
//                 }
//                 return;
//             }
//             case ConsoleKey.D:
//             {
//                 if(a.CantMoney-bank.gem4.Cost >= 0) 
//                 {   
//                     a.DiscardPile.Add(bank.gem4) ;
//                     a.CantMoney = a.CantMoney-bank.gem4.Cost;
//                 }
//                 return;
//             }
//         }
//     }
//     static void PrintBankCartPhaseBuy()
//     {
//         int i = 0;
//         foreach(BankCards l in bank.bank.Keys)
//         {
//             Console.WriteLine($"[{i}]-[{l.Name}]: {l.Cost} $");
//             i++;
//         }
//     }

//     static void InformationCard(Player a)
//     {
//         // Console.Clear();
//         // PrintTable(a);
//         // Console.WriteLine("Elija una carta"); int opc = int.Parse(Console.ReadLine());
//         // Console.Clear();
//         // Console.WriteLine(tableChoose[opc]);
//         // Console.WriteLine("\nAtras: presione [Enter]"); Console.ReadLine();
//     }

//     static void PhaseCleanUp(Player a)
//     {
//         a.DiscardPile.AddRange(a.Hand);
//         a.Hand.Clear();

//         foreach(Card l in a.Ongoing)
//         {
//             ((PlayingCard)l).Reset();
//         }

//         a.DiscardPile.AddRange(a.Ongoing);
//         a.Ongoing.Clear();

//         int amountGem = 0;
//         foreach(Gem gems in a.GemPile)
//         {
//             amountGem += gems.Count;
//         }
//         int cantsavingcards = a.SavingCards.Count;

//         if (amountGem <= 2) a.Draw(5-cantsavingcards);
//         else if ((amountGem >= 3) && (amountGem <= 5)) a.Draw(6-cantsavingcards);
//         else if (amountGem >= 6 && amountGem <= 8) a.Draw(7-cantsavingcards);
//         if (amountGem == 9) a.Draw(8-cantsavingcards);

//         a.Hand.AddRange(a.SavingCards);
//         a.SavingCards.Clear();
//         a.Reset();
//     }

//     static bool GameOver(int n) // cambiar para mas adelante...
//     {
//         if(n >= 10) return true;

//         return false;
//     }
    
//     static List<Card> ChoosePlayingCard(List<PlayingCard> choosecards, List<Card> InitialDeck)
//     {
//         Random r = new Random();
//         List<Card> list = new List<Card>();

//         foreach(var l in InitialDeck)
//         {
//             list.Add(l);
//         }

//         for(int i = 0 ; i < 5 ; i++)
//         {
//             list.Add(choosecards[r.Next(0,choosecards.Count-1)]);
//         }

//         return list;
//     }
// }
class Program
{
    List<Card>? ChoosingCards;
    static void PrintMenu()
    {
        System.Console.WriteLine("Presione [N] para un nuevo juego.");
        System.Console.WriteLine("Presione [E] para salir.");
    }

    static List<Player> AddPlayers()
    {
        List<Player> result = new List<Player>();
        int n = 0;

        while( n < 4 )
        {
            Console.Clear();
            System.Console.WriteLine("[J]-Para anadir jugador manual");
            System.Console.WriteLine("[E]-Para dejar de anadir jugadores");
            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.J :
                {
                    Console.Clear();
                    System.Console.WriteLine("Escriba su nombre");
                    result.Add(new ManualPlayer(Console.ReadLine()));
                    n++;
                    break;
                }
                case ConsoleKey.E :
                {
                    if( n != 1 && n!= 0)
                    {
                        return result;
                    }
                    break;
                } 
            }
        }

        return result;
    }

    static void NewGame()
    {
        List<Player> players = AddPlayers();
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