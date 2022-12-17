namespace engine_cuban_puzzle;

public class Gem1 : Card,ICostable
{
    public int Cost {get; }
    public Gem1() : base ("Gem 1",new string[]{"Green"},1)
    {
        this.Cost = 1;
    }
}

public class Gem2 : Card, ICostable
{
    public int Cost {get; }
    public Gem2() : base ("Gem 2",new string[]{"Green"},2)
    {
        this.Cost = 3;
    }
}

public class Gem3 : Card, ICostable
{
    public int Cost {get; }
    public Gem3() : base ("Gem 3",new string[]{"Green"},3)
    {
        this.Cost = 5 ;
    }
}

public class Gem4 : Card, ICostable
{
    public int Cost {get; }
    public Gem4() : base ("Gem 4",new string[]{"Green"},4)
    {
        this.Cost = 7;
    }
}

public class CrashGem : Card, ICostable,IAttackable,IReactionable
{
    public int Cost {get; }
    public CrashGem() : base ("CrashGem",new string[] {"Purple"},1)
    {
        this.Cost = 5;
    }

    public void Attack()
    {
        throw new NotImplementedException();
    }

    public void Reaction()
    {
        throw new NotImplementedException();
    }
}

public class DobleCrashGem : Card, ICostable,IAttackable
{
    public int Cost {get; }
    public DobleCrashGem() : base ("CrashGem",new string[]{"Purple"},2)
    {
        this.Cost = 9;
    }

    public void Attack()
    {
        throw new NotImplementedException();
    }
}

public class Combine : Card, ICostable , ICombinable
{
    public int Cost {get; }
    public Combine() : base("Combine",new string[]{"Purple"},-1) 
    {
        this.Cost = 4;
    }

    public void Combiner()
    {
        throw new NotImplementedException();
    }
}

public class Cup : Card, ICostable
{
    public int Cost {get; }
    public Cup() : base("Cup",new string[]{"gray"},0)
    {
        this.Cost = 0;
    }
}
