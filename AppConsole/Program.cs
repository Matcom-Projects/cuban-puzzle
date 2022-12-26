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

            while( n > 0 )
            {
                Console.Clear();
                System.Console.WriteLine("\tSeleccione las cartas del juego:");
                GamePrint.PrintList(ActionsCards);
                foreach( IPlayer pla in players) 
                {
                    if(n <= 0) return result;
                    result.Add ( ActionsCards [ GamePrint.SelectCard(ActionsCards) ] ) ;//optimizar bien este metodo
                    n--;
                }
            } 

            return result;
        }

        static List<IPlayer> ChooseHeroCards(List<IPlayer> players,List<Card> initialdeck)
        {
            int index;

            foreach(IPlayer a in players)
            {
                Console.Clear();
                System.Console.WriteLine("\tSeleccione su Heroe: ");
                for(int i=0; i<CreateCards.AllHeroCards.Count; i++)
                {
                    System.Console.WriteLine($"[{i/3}][{CreateCards.AllHeroCards[i].Name}]");
                }
                System.Console.WriteLine($"-{a.Name}-");
                index = GamePrint.SelectCard(CreateCards.AllHeroCards);//implementar bien este metodo
                index = index*3;

                List<Card> DeckPLayer = new List<Card>();
                DeckPLayer.Add( CreateCards.AllHeroCards[index] );
                DeckPLayer.Add(CreateCards.AllHeroCards[index++]);
                DeckPLayer.Add(CreateCards.AllHeroCards[index++]);
                DeckPLayer.AddRange(initialdeck);

                a.Table.CreateDeck(DeckPLayer);
                a.Table.MixDeck();
                a.Table.DrawDeck(5);
            }

            return players;
        }

        static void NewGame()
        {
            List<IPlayer> players = AddPlayers();
            players = GameUtils.MixPlayers(players);

            List<BankCard> ChoosingCards = ChooseCards(players,CreateCards.AllActionsCard);
            Bank bank = new Bank(ChoosingCards);

            List<Card> initialdeck = new List<Card>();
            initialdeck.AddRange(bank.GetCant(0,6));
            initialdeck.Add((Card)bank.Get(4));

            players = ChooseHeroCards(players,initialdeck);

            IPlayer WinPlayer = GameEngine.PlayGame(players,bank);
            Console.WriteLine($"Ha ganado {WinPlayer.Name}. Presione cualquier boton para continuar.");
            Console.ReadLine();
        }
        static void Main()
        {
            CreateCards.AllActionsCard = new List<BankCard>();
            CreateCards.AllActionsCard.Add(new CombosAreHard());
            CreateCards.AllActionsCard.Add(new DrawThree());
            CreateCards.AllActionsCard.Add(new GemEssence());
            CreateCards.AllActionsCard.Add(new Knockdown());
            CreateCards.AllActionsCard.Add(new OneTwoPunch());
            CreateCards.AllActionsCard.Add(new OneOfEach());
            CreateCards.AllActionsCard.Add(new SalesPrice());
            CreateCards.AllActionsCard.Add(new SalesPrice());
            CreateCards.AllActionsCard.Add(new SelfImprovement());
            CreateCards.AllActionsCard.Add(new SneackAttack());
            CreateCards.AllHeroCards = new List<Card>();
            CreateCards.AllHeroCards.Add(new MartialMastery());
            CreateCards.AllHeroCards.Add(new Reversal());
            CreateCards.AllHeroCards.Add(new VersatileStyle());
            CreateCards.AllHeroCards.Add(new BurningVigor());
            CreateCards.AllHeroCards.Add(new PlayingWithFire());
            CreateCards.AllHeroCards.Add(new UnstablePower());

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
