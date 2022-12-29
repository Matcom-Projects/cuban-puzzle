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

    public class CrashGem : BankCard , IActionable
    {
        public bool[] Actions {get; }
        public CrashGem() : base ("CrashGem",new string[] {"Purple"},1,5)
        {
            this.Actions = new bool[] {false, false, false, true, false, false};
        }
        
        public void GiveActions (){}
        public void SaveCards (int index, IPlayer a){}
        public void Draw (IPlayer a){}
        public void Attack (int index,IPlayer a)
        {
            List<BankCard> list = GameEngine.bank.GetCant(0, GameEngine.Turns.Current.Table.GemPile[index].Money);
            
            foreach(var l in list)
            {
                a.Table.GemPile.Add(l);
            }
            GameEngine.Turns.Current.Table.GemPile.RemoveAt(index);
        }
        public void Trash (IPlayer a){}
        public void GainCard (IPlayer a){}

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            return $"[{this.Name}]";
        }
    }

    public class DobleCrashGem : BankCard ,IActionable
    {
        public bool[] Actions {get; }
        public DobleCrashGem() : base ("Doble CrashGem",new string[]{"Purple"},2,9)
        {
            this.Actions = new bool[] {false, false, false, true, false, false};
        }
        
        public void GiveActions (){}
        public void SaveCards (int index, IPlayer a){}
        public void Draw (IPlayer a){}
        public void Attack (int index,IPlayer a)
        {
            int gem = GameEngine.Turns.Current.SelectGem();
            Auxiliar(index, a);
            Auxiliar(gem, a);
        }
        public void Auxiliar(int index,IPlayer a)
        {
            int x = GameEngine.Turns.Current.Table.GemPile[index].Money;
            List<BankCard> list = GameEngine.bank.GetCant(0, x);
            foreach(var l in list)
            {
                a.Table.GemPile.Add(l);
            }
        }
        public void Trash (IPlayer a){}
        public void GainCard (IPlayer a){}

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            return $"[{this.Name}]";
        }
    }

    public class Combine : BankCard , IActionable 
    {
        public bool[] Actions {get; }
        public Combine() : base("Combine",new string[]{"Purple"},-1,4) 
        {
            this.Actions = new bool[] {false, false, false, false, true, false};
        }
        
        public void GiveActions(){}
        public void SaveCards(int index, IPlayer a){}
        public void Draw(IPlayer a){}
        public void Attack(int index,IPlayer a){}
        public void Trash(IPlayer a)
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
        public void GainCard(IPlayer a){}
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
