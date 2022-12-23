using engine_cuban_puzzle;
using System.Collections.Generic;
namespace console_cuban_puzzle;

class Program
{
    static void PrintMenu()
    {
        System.Console.WriteLine("Presione [N] para un nuevo juego.");
        System.Console.WriteLine("Presione [E] para salir.");
    }

    static List<IPlayer> AddPlayers()
    {
        List<IPlayer> result = new List<IPlayer>();
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

    static List<ICostable> ChooseCards(List<IPlayer> players,List<ICostable> ActionsCards)
    {
        if(ActionsCards.Count <= 10) return ActionsCards;

        List<ICostable> result = new List<ICostable>();
        int n = 10;

        while( n > 0 )
        {
            foreach( IPlayer pla in players) 
            {
                if(n <= 0) return result;
                result.Add ( ActionsCards [ pla.SelectActionCard(ActionsCards) ] ) ;//optimizar bien este metodo
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
            index = a.SelectHero(CreateCards.AllHeroCards);//implementar bien este metodo
            index = index*3;

            List<Card> DeckPLayer = new List<Card>();
            DeckPLayer.Add( CreateCards.AllHeroCards[index] );
            DeckPLayer.Add(CreateCards.AllHeroCards[index++]);
            DeckPLayer.Add(CreateCards.AllHeroCards[index++]);
            DeckPLayer.AddRange(initialdeck);

            a.Table.CreateDeck(DeckPLayer);
        }

        return players;
    }

    static void NewGame()
    {
        List<IPlayer> players = AddPlayers();
        players = GameUtils.MixPlayers(players);

        List<ICostable> ChoosingCards = ChooseCards(players,CreateCards.AllActionsCard);
        Bank bank = new Bank(ChoosingCards);

        List<Card> initialdeck = new List<Card>();
        initialdeck.AddRange((IEnumerable<Card>)bank.GetCant(new Gem1(),6));
        initialdeck.Add((Card)bank.Get(new CrashGem()));

        players = ChooseHeroCards(players,initialdeck);

        IPlayer WinPlayer = GameEngine.PlayGame(players,bank);
        Console.WriteLine($"Ha ganado {WinPlayer.Name}. Presione cualquier boton para continuar.");
        Console.ReadLine();
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