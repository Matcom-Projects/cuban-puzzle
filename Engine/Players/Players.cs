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

   public bool Exit()
        {
            ConsoleKey key;
            do{
                Console.Clear();
                GamePrint.PrintTable(GameEngine.Turns.Players);
                Console.WriteLine("[J].Jugar fase de accion");
                Console.WriteLine("[E].Continuar");
                Console.WriteLine("[I].Informacion de la carta");

                key = GamePrint.Read();
                if(key==ConsoleKey.E) return true;
                if(key==ConsoleKey.I) GameUtils.InformationCard();
            }while(key!=ConsoleKey.J);

            return false;
        }

    public bool ExistIActionable()
    {
        for(int i=0; i<Table.HandCards.Count; i++)
        {
            if(Table.HandCards[i] is IActionable) return true;
        }

        return false;
    }

    public int SelectCardHand()//commit
    { 
        Console.WriteLine("De HandCards:");

        return GamePrint.SelectCard(Table.HandCards);;
    }

    public int SelectCardOnGoing()
    {
        Console.WriteLine("De OnGoing:");

        return GamePrint.SelectCard(Table.OnGoing);
    }

    public void ExecuteAction(IActionable card)
    {
        card.Action();
    }

    public int SelectGem()
    {
        Console.WriteLine("De GemPile");

        return GamePrint.SelectCard(Table.GemPile);
    }

    public IPlayer SelectPlayer()
    {
        Console.WriteLine("Jugadores:");
        for(int i=0; i<GameEngine.Turns.Players.Count; i++)
        {
            if(GameEngine.Turns.Players[i]==this) continue;
            Console.WriteLine($"[{i}].{GameEngine.Turns.Players[i].Name}");
        }

        int index = 0;
        do{
            index = GamePrint.SelectCard(GameEngine.Turns.Players);
        }while(index == GameEngine.Turns.Players.IndexOf(this));

        return GameEngine.Turns.Players[index];
    }

    public BankCard PlayBuyPhase()
    {
        Console.Clear();
        Console.WriteLine($"Fase de Compra: {this.Name}");
        Console.WriteLine($"Cantidad de dinero: {GameEngine.CantMoneyPerTurn} $");
        for( int i = 0 ; i < GameEngine.bank.keys.Count ; i++ )
        {
            Console.WriteLine($"[{i}][{(GameEngine.bank.keys[i]).Name}] : {GameEngine.bank.keys[i].Cost} $");
        }
        Console.WriteLine();
        Console.WriteLine("Nota: Debe hacer una compra obligatoriamente por turno. En caso de no querer comprar ninguna carta, compre un Cup");
        Console.WriteLine("Para efectuar su compra");

        return GameEngine.bank.keys[GamePrint.SelectCard(GameEngine.bank.keys)];
    }

    public bool PlayNextBuyPhases()
    {
        Console.Clear();
        System.Console.WriteLine("Desea finalizar ya la fase de compra??? [S]i o [N]o");
        ConsoleKey key = Console.ReadKey(true).Key;

        if(key == ConsoleKey.S) return true;
        return false;
    }

    public int SelectCardDeck()
    {
        Console.WriteLine("De Deck");
        GamePrint.PrintList(Table.Deck);

        return GamePrint.SelectCard(Table.Deck);
    }

    public int SelectCardDiscardPile()
    {
        Console.WriteLine("De DiscardPile");
        GamePrint.PrintList(Table.DiscardPile);
        System.Console.WriteLine();

        return GamePrint.SelectCard(Table.DiscardPile);
    }

    public BankCard SelectCardBank()
    {
        return GameEngine.bank.keys[GamePrint.SelectCard(GameEngine.bank.keys)];
    }

    public int[] SelectGem(int cantgem)
    {
        if(!GameUtils.ExistCombination(Table.GemPile)) return new int[]{-1,-1};

        int x = SelectGem();
        int y = SelectGem();
        
        while( x == y || Table.GemPile[x].Money+Table.GemPile[y].Money > 4)
        {
            System.Console.WriteLine("La combinacion entre estas dos gemas no existe.");
            x = SelectGem();
            y = SelectGem();
        }
        return new int[]{x,y};
    }

    public int SelectCard(List<Card> list)
    {
        return GamePrint.SelectCard(list);
    }

    public int SelectBCard(List<Card> cardslist)
    {
        return GamePrint.SelectBCard(cardslist);
    }
}
