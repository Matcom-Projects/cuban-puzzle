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

    public int SelectActionCard(List<BankCard> ActionsCards)
    {
        return int.Parse(Console.ReadLine());
    }

    public int SelectHero(List<Card> HeroCards)
    {
        Console.Clear();
        for(int i =0;i<CreateCards.AllHeroCards.Count;i++)
        {
            System.Console.WriteLine($"[{i/3}][{CreateCards.AllHeroCards[i].Name}]");
        }
        return int.Parse(Console.ReadLine());
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

    public int SelectCardHand()
    {
        Console.Clear();
        Console.WriteLine("HandCards:");
        for(int i=0; i<Table.HandCards.Count; i++)
        {
            Console.WriteLine($"[{i}].{Table.HandCards[i].Name}");
        }
        Console.WriteLine("Escoja una carta: ");
        int opc = int.Parse(Console.ReadLine());

        return opc;
    }

    public Card SelectCardOnGoing()
    {
        Console.Clear();
        Console.WriteLine("OnGoing:");
        for(int i=0; i < Table.OnGoing.Count; i++)
        {
            Console.WriteLine($"[{i}].{Table.OnGoing[i].Name}");
        }
        Console.WriteLine("Escoja una carta: ");
        int opc = int.Parse(Console.ReadLine());

        return Table.OnGoing[opc];
    }

    public bool SelectField()
    {
        Console.Clear();
        Console.WriteLine("[E].Escoger una carta de la mano");
        Console.WriteLine("[A].Activar una carta del OnGoing");
        ConsoleKey key = Console.ReadKey(true).Key;

        if( key == ConsoleKey.A ) return true;

        return false;
    }

    public int SelectGem()
    {
        Console.WriteLine("GemPile:");
        for( int i = 0 ; i < Table.GemPile.Count ; i++ )
        {
            Console.WriteLine($"[{i}].{Table.GemPile[i]}");
        }
        Console.WriteLine("Escoja una gema: ");
        int opc = int.Parse(Console.ReadLine());

        return opc;
    }

    public IPlayer SelectPlayer(IPlayer a)
    {
        Console.WriteLine("Jugadores:");
        for(int i=0; i<GameEngine.Turns.Players.Count; i++)
        {
            if(GameEngine.Turns.Players[i]==a) continue;
            Console.WriteLine($"[{i}].{GameEngine.Turns.Players[i].Name}");
        }
        Console.WriteLine("Escoja un jugador: ");
        int opc = int.Parse(Console.ReadLine());

        return GameEngine.Turns.Players[opc];
    }

    public void ChooseActionRealize(IActionable card)
    {
        Console.Clear();
        Console.WriteLine("Acciones:");
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
                int index = SelectCardHand();
                card.SaveCards(index,GameEngine.Turns.Current);
                break;
            }
            case ConsoleKey.R :
            {
                card.Draw(GameEngine.Turns.Current);
                break;
            }
            case ConsoleKey.M :
            {
                int index = SelectGem();
                card.Attack(index,SelectPlayer(this));
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

    public bool Exit()
    {
        Console.Clear();
        Console.WriteLine("[J].Jugar fase de accion");
        Console.WriteLine("[E].Continuar");
        ConsoleKey key = Console.ReadKey(true).Key;

        if(key==ConsoleKey.E) return true;

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
