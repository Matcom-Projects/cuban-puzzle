namespace engine_cuban_puzzle;

public class Bank 
{
    public Dictionary <ICostable,int> GameBank { get; private set; } 
    public List<ICostable> keys { get; private set; }
    public Bank ( List<ICostable> choosingcards )
    {
        this.GameBank = new Dictionary<ICostable, int>();
        this.keys = new List<ICostable>();
        keys.Add(new Gem1());
        keys.Add(new Gem2());
        keys.Add(new Gem3());
        keys.Add(new Gem4());
        keys.Add(new CrashGem());
        keys.Add(new DobleCrashGem());
        keys.Add(new Combine());
        keys.Add(new Cup());

        foreach(ICostable a in keys)
        {
            GameBank.Add(a,int.MaxValue);
        }

        foreach(ICostable a in choosingcards)
        {
            keys.Add(a);
            GameBank.Add(a,5);
        }
    }

    public ICostable Get(int index)
    {
        if( GameBank[keys[index]] != 0 )
        {
            GameBank[keys[index]] --;
            return keys[index];
        }

        return null;
    }

    public ICostable Get(ICostable card)
    {
        if( GameBank[card] != 0 )
        {
            GameBank[card] --;
            return card;
        }

        return null;
    }

    public List<ICostable> GetCant(int index,int n)
    {
        List<ICostable> result = new List<ICostable>();
        GameBank[keys[index]] -= n;

        for(int i =0;i < n;i++)
        {
            result.Add(keys[index]);
        }

        return result;
    }

    public List<ICostable> GetCant(ICostable card,int n)
    {
        List<ICostable> result = new List<ICostable>();
        GameBank[card] -= n;

        for(int i =0;i < n;i++)
        {
            result.Add(card);
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