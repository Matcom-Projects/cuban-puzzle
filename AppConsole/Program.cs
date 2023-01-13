using engine_cuban_puzzle;
using System.Collections.Generic;
namespace console_cuban_puzzle;

    class Program
    {
        static List<IPlayer> AddPlayers()
        {
            List<IPlayer> result = new List<IPlayer>();
            int n = 0;

            while( n < 4 )
            {
                Console.Clear();
                System.Console.WriteLine("\tInicio de sesión:");//
                System.Console.WriteLine("[J]-Añadir jugador manual");//
                System.Console.WriteLine("[V]-Añadir jugador virtual");//
                System.Console.WriteLine("[E]-Continuar");//

                switch (GamePrint.Read())
                {
                    case ConsoleKey.J :
                    {
                        Console.Clear();
                        System.Console.WriteLine("Escriba su nombre");
                        result.Add(new ManualPlayer(Console.ReadLine()));
                        n++;
                        break;
                    }
                    case ConsoleKey.V ://
                    {
                        Console.Clear();
                        System.Console.WriteLine("Escriba el nombre del jugador virtual: ");
                        result.Add(new VirtualPlayer(Console.ReadLine()));
                        n++;
                        break;
                    }
                    case ConsoleKey.E :
                    {
                        if( n>1 )//
                        {
                            return result;
                        }
                        else{
                            System.Console.WriteLine("Debe añadir más jugadores");
                            System.Console.WriteLine("[Enter]-Para continuar"); Console.ReadLine();
                        }
                        break;
                    } 
                }
            }

            return result;
        }

        static List<BankCard> ChooseCards(List<IPlayer> players,List<BankCard> ActionsCards)
        {
            if(ActionsCards.Count <= 10) return ActionsCards;

            List<BankCard> result = new List<BankCard>();
            int n = 10;

            List<BankCard> list = new List<BankCard>();
            foreach(var l in ActionsCards)
            {
                list.Add(l);
            }

            while( n > 0 )
            {
                foreach( IPlayer pla in players) 
                {    
                    Console.Clear();
                    System.Console.WriteLine("\tSeleccione las cartas del juego:");
                    for(int i=0; i<list.Count; i++)
                    {
                        System.Console.WriteLine($"[{i}].{list[i].Name}  ");
                    }
                
                    if(n <= 0) return result;
                    System.Console.WriteLine($"-{pla.Name}-");
                    BankCard bankCard = list [ GamePrint.SelectCard(list) ];
                    result.Add ( bankCard ) ;
                    list.Remove(bankCard);
                    n--;
                }
            } 

            return result;
        }

        static List<IPlayer> ChooseHeroCards(List<IPlayer> players,List<Card> initialdeck,List<Card>HeroCards)
        {
            bool[] selechero = new bool[HeroCards.Count];
            int index= -1;

            foreach(IPlayer a in players)
            {
                Console.Clear();
                List<Card> DeckPLayer = new List<Card>();
                if(HeroCards.Count/3 >= players.Count)
                {
                    System.Console.WriteLine("\tSeleccione su Heroe: ");
                    for(int i=0; i<HeroCards.Count; i++)
                    {
                        System.Console.WriteLine($"[{i}][{HeroCards[i].Name}]");
                    }
                    System.Console.WriteLine($"-{a.Name}-");
                    
                    for(int i = 0 ; i < 3 ; i++)
                    {
                        index = GamePrint.SelectCard(HeroCards);
                        while(selechero[index])
                        {
                            index = GamePrint.SelectCard(HeroCards);
                        }
                        DeckPLayer.Add ( HeroCards[index] );
                        selechero[index]=true;
                    }
                    DeckPLayer.AddRange(initialdeck);
                }

                a.Table.CreateDeck(DeckPLayer);
                a.Table.MixDeck();
                a.Table.DrawDeck(5);
            }

            return players;
        }

        static void NewGame()
        {
            CreateCards.ReadCards();
            List<IPlayer> players = AddPlayers();
            players = GameUtils.MixPlayers(players);

            List<BankCard> ChoosingCards = ChooseCards(players,CreateCards.AllActionsCards);
            Bank bank= new Bank(ChoosingCards);

            List<Card> initialdeck = new List<Card>();
            initialdeck.AddRange(bank.GetCant(0,6));
            initialdeck.Add((Card)bank.Get(4));

            players = ChooseHeroCards(players,initialdeck,CreateCards.AllHeroCards);

            IPlayer WinPlayer = GameEngine.PlayGame(players,bank);
            Console.Clear();
            Console.WriteLine($"Ha ganado {WinPlayer.Name}. Presione cualquier boton para continuar.");
            Console.ReadLine();
        }
        static void Main()
        {
            while(true)
            {
                Console.Clear();
                GamePrint.PrintMenu();
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
