namespace engine_cuban_puzzle;

public class Gem1 : BankCard 
    {
        public Gem1() : base ("Gem 1",new string[]{"Green"},1,1)
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
        public Gem2() : base ("Gem 2",new string[]{"Green"},2,3)
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
        public Gem3() : base ("Gem 3",new string[]{"Green"},3,5)
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
        public Gem4() : base ("Gem 4",new string[]{"Green"},4,7)
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
        public CrashGem() : base ("CrashGem",new string[] {"Purple"},1,5)
        {
            
        }

        public override void Action(IPlayer a)
        {
            IPlayer Victim = a.SelectPlayer();
            if(a is VirtualPlayer){
                System.Console.WriteLine($"El jugador atacó a {Victim.Name}"); 
                Console.ReadLine();
            }
            GameActions.Attack(a, Victim, 1);
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            return $"[{this.Name}]";
        }
    }

    public class DobleCrashGem : ActionBankCard  
    {
        public DobleCrashGem() : base ("Doble CrashGem",new string[]{"Purple"},2,9)
        {
            
        }

        public override void Action(IPlayer a)
        {
            IPlayer Victim = a.SelectPlayer();
            if(a is VirtualPlayer){
                System.Console.WriteLine($"El jugador atacó a {Victim.Name}"); 
                Console.ReadLine();
            }
            GameActions.Attack(a, Victim, 2);
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            return $"[{this.Name}]";
        }
    }

    public class Combine : ActionBankCard 
    {
        public Combine() : base("Combine",new string[]{"Purple"},-1,4) 
        {
            
        }
        
        public override void Action(IPlayer a)
        {
            Aux1(a);
            BankCard x;
            BankCard y;
            do{
                x = a.Table.GemPile[a.SelectGem()];
                int aux = x.Money;
                x.Money = 0;

                y = a.Table.GemPile[a.SelectGem()];

                x.Money = aux;
            }while(x.Money+y.Money > 4);
            
            if(x is Gem1 && y is Gem1) 
                a.Table.GemPile.Add(GameEngine.bank.Get(GameEngine.bank.keys[1]));
            if((x is Gem1 && y is Gem2) || (x is Gem2 && y is Gem1)) 
                a.Table.GemPile.Add(GameEngine.bank.Get(GameEngine.bank.keys[2]));
            if((x is Gem1 && y is Gem3) || (x is Gem2 && y is Gem2) || (x is Gem3 && y is Gem1)) 
                a.Table.GemPile.Add(GameEngine.bank.Get(GameEngine.bank.keys[3]));
            GameEngine.bank.Add(x); a.Table.GemPile.Remove(x);
            GameEngine.bank.Add(y); a.Table.GemPile.Remove(y);
            GameEngine.CantActionsPerTurn++ ;
            Aux2(a);
        }
        private void Aux1(IPlayer a)
        {
            foreach(var l in a.Table.GemPile)
            {
                if(l is Gem4) l.Money = 0;
            }
        }
        private void Aux2(IPlayer a)
        {
            foreach(var l in a.Table.GemPile)
            {
                if(l is Gem4) l.Money = 4;
            }
        }
        
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            return $"[{this.Name}]";
        }
    }

    public class Cup : BankCard 
    {
        public Cup() : base("Cup",new string[]{"gray"},0,0)
        {

        }
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            return $"[{this.Name}]";
        }
    }
