namespace engine_cuban_puzzle;

public class Gem1 : BankCard 
{
    public Gem1() : base ("Gem 1","Green",1,1)
    {

    }
    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        return $"[{this.Name}]";
    }
}

public class Gem2 : BankCard 
{
    public Gem2() : base ("Gem 2","Green",2,3)
    {

    }
    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        return $"[{this.Name}]";
    }
}

public class Gem3 : BankCard 
{
    public Gem3() : base ("Gem 3","Green",3,5)
    {

    }
    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        return $"[{this.Name}]";
    }
}

public class Gem4 : BankCard 
{
    public Gem4() : base ("Gem 4","Green",4,7)
    {

    }
    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        return $"[{this.Name}]";
    }
}

public class CrashGem : ActionBankCard
{
    public CrashGem() : base ("CrashGem","Purple",1,5)
    {
        
    }

    public override void Action()
    {
        IPlayer Victim = GameEngine.Turns.Current.SelectPlayer();
        if(GameEngine.Turns.Current is VirtualPlayer){
            System.Console.WriteLine($"El jugador atacó a {Victim.Name}"); 
            Console.ReadLine();
        }
        GameActions.Attack(Victim, 1);
    }

    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        return $"[{this.Name}]";
    }
}

public class DobleCrashGem : ActionBankCard  
{
    public DobleCrashGem() : base ("Doble CrashGem","Purple",2,9)
    {
        
    }

    public override void Action()
    {
        IPlayer Victim = GameEngine.Turns.Current.SelectPlayer();
        if(GameEngine.Turns.Current is VirtualPlayer){
            System.Console.WriteLine($"El jugador atacó a {Victim.Name}"); 
            Console.ReadLine();
        }
        GameActions.Attack(Victim, 2);
    }

    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        return $"[{this.Name}]";
    }
}

public class Combine : ActionBankCard 
{
    public Combine() : base("Combine","Purple",-1,4) 
    {
        
    }
    
    public override void Action()
    {
        GameUtils.CombineFunction();
        GameActions.GiveActions(1);
    }
    
    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        return $"[{this.Name}]";
    }
}

public class Cup : BankCard 
{
    public Cup() : base("Cup","gray",0,0)
    {

    }
    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        return $"[{this.Name}]";
    }
}