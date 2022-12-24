namespace engine_cuban_puzzle;

public class Gem1 : Card , ICostable
{
    public int Cost {get; }
    public Gem1() : base ("Gem 1",new string[]{"Green"},1)
    {
        this.Cost = 1;
    }
}

public class Gem2 : Card , ICostable
{
    public int Cost {get; }
    public Gem2() : base ("Gem 2",new string[]{"Green"},2)
    {
        this.Cost = 3;
    }
}

public class Gem3 : Card , ICostable
{
    public int Cost {get; }
    public Gem3() : base ("Gem 3",new string[]{"Green"},3)
    {
        this.Cost = 5 ;
    }
}

public class Gem4 : Card , ICostable
{
    public int Cost {get; }
    public Gem4() : base ("Gem 4",new string[]{"Green"},4)
    {
        this.Cost = 7;
    }
}

public class CrashGem : Card , ICostable, IActionable
{
    public int Cost {get; }
    public bool[] Actions {get; }
    public string Id{ get; private set; }
    public CrashGem() : base ("CrashGem",new string[] {"Purple"},1)
    {
        this.Cost = 5;
        this.Actions = new bool[] {false, false, false, true, false, false};
        this.Id = GameUtils.CreateId();
    }
    
        private void GiveActions ();
        private void SaveCards (int index, IPlayer a);
        private void ExecuteGetDeck (IPlayer a);
        public void Attack (int index,IPlayer a)
        {
            int x = GamEngine.Turns.Current.Table.GemPile[index].Money;
            List<ICostable> list = GameEngine.bank.GetCant(GamEngine.Turns.Current.Table.GemPile[index], x);
            foreach(var l in list)
            {
                a.Table.GemPile.Add(l);
            }
        }
        private void Trash (IPlayer a);
        private void GainCard (IPlayer a);

}

public class DobleCrashGem : Card , ICostable 
{
    public int Cost {get; }
    public bool[] Actions {get; }
    public string Id{ get; private set; }
    public DobleCrashGem() : base ("CrashGem",new string[]{"Purple"},2)
    {
        this.Cost = 9;
        this.Actions = new bool[] {false, false, false, true, false, false};
        this.Id = GameUtils.CreateId();
    }
    
        private void GiveActions ();
        private void SaveCards (int index, IPlayer a);
        private void ExecuteGetDeck (IPlayer a);
        public void Attack (int index,IPlayer a)
        {
            Auxiliar(index, a);
            int gem = GamEngine.Turns.Current.SelectGem();
            Auxiliar(gem, a);
        }
        private void Auxiliar(int index,IPlayer a)
        {
            int x = GamEngine.Turns.Current.Table.GemPile[index].Money;
            List<ICostable> list = GameEngine.bank.GetCant(GamEngine.Turns.Current.Table.GemPile[index], x);
            foreach(var l in list)
            {
                a.Table.GemPile.Add(l);
            }
        }
        private void Trash (IPlayer a);
        private void GainCard (IPlayer a);

}

public class Combine : Card , ICostable, IActionable 
{
    public int Cost {get; }
    public bool[] Actions {get; }
    public string Id{ get; private set; }
    public Combine() : base("Combine",new string[]{"Purple"},-1) 
    {
        this.Cost = 4;
        this.Actions = new bool[] {false, false, false, false, true, false};
        this.Id = GameUtils.CreateId();
    }
    
        private void GiveActions();
        private void SaveCards(int index, IPlayer a);
        private void ExecuteGetDeck(IPlayer a);
        private void Attack(int index,IPlayer a);
        public void Trash(IPlayer a)
        {
            do{
                Card x = a.Table.GemPile[a.SelectGem()];
                Card y = a.Table.GemPile[a.SelectGem()];
            }while(x.Money+y.Money > 4);
            
            if(x is Gem1 && y is Gem1) 
                a.Table.GemPile.Add(GameEngine.bank.Get(new Gem2()));
            if((x is Gem1 && y is Gem2) || (x is Gem2 && y is Gem1)) 
                a.Table.GemPile.Add(GameEngine.bank.Get(new Gem3()));
            if((x is Gem1 && y is Gem3) || (x is Gem2 && y is Gem2) || (x is Gem3 && y is Gem1)) 
                a.Table.GemPile.Add(GameEngine.bank.Get(new Gem4()));
            GameEngine.bank.Add(x); a.Table.GemPile.Remove(x);
            GameEngine.bank.Add(y); a.Table.GemPile.Remove(y);
            GameEngine.CantActionPerTurn ++;
        }
        private void GainCard(IPlayer a);

}

public class Cup : Card , ICostable
{
    public int Cost {get; }
    public Cup() : base("Cup",new string[]{"gray"},0)
    {
        this.Cost = 0;
    }
}
