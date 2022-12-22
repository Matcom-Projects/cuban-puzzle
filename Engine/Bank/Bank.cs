namespace engine_cuban_puzzle;

public class Bank 
{
    public Dictionary <ICostable,int> GameBank { get; private set; } 
    public Bank ( List<ICostable> choosingcards )
    {
        this.GameBank = new Dictionary<ICostable, int>();

        GameBank.Add(new Gem1(),int.MaxValue);
        GameBank.Add(new Gem2(),int.MaxValue);
        GameBank.Add(new Gem3(),int.MaxValue);
        GameBank.Add(new Gem4(),int.MaxValue);
        GameBank.Add(new CrashGem(),int.MaxValue);
        GameBank.Add(new DobleCrashGem(),int.MaxValue);
        GameBank.Add(new Combine(),int.MaxValue);
        GameBank.Add(new Cup(),int.MaxValue);

        foreach(ICostable a in choosingcards)
        {
            GameBank.Add(a,5);
        }
    }

    public ICostable Get(ICostable a)
    {
        if( GameBank[a] != 0 )
        {
            GameBank[a] --;
            return a;
        }

        return null;
    }

    public List<ICostable> GetCant(ICostable a,int n)
    {
        List<ICostable> result = new List<ICostable>();
        GameBank[a] -= n;

        for(int i =0;i < n;i++)
        {
            result.Add(a);
        }

        return result;
    }

    public void Add(ICostable a)
    {
        GameBank[a]++;
    }

    public void AddCant(List<ICostable> a)
    {
        GameBank[a[0]] += a.Count;
    }
}