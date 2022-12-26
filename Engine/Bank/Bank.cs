namespace engine_cuban_puzzle;

public class Bank 
{
    public Dictionary <BankCard,int> GameBank { get; private set; } 
    public List<BankCard> keys { get; private set; }
    public Bank ( List<BankCard> choosingcards )
    {
        this.GameBank = new Dictionary<BankCard, int>();
        this.keys = new List<BankCard>();
        keys.Add(new Gem1());
        keys.Add(new Gem2());
        keys.Add(new Gem3());
        keys.Add(new Gem4());
        keys.Add(new CrashGem());
        keys.Add(new DobleCrashGem());
        keys.Add(new Combine());
        keys.Add(new Cup());

        foreach(BankCard a in keys)
        {
            GameBank.Add(a,int.MaxValue);
        }

        foreach(BankCard a in choosingcards)
        {
            keys.Add(a);
            GameBank.Add(a,5);
        }
    }

    public BankCard Get(int index)
    {
        if( GameBank[keys[index]] != 0 )
        {
            GameBank[keys[index]] --;
            return keys[index];
        }

        return null;
    }

    public BankCard Get(BankCard card)
    {
        if( GameBank[card] != 0 )
        {
            GameBank[card] --;
            return card;
        }

        return null;
    }

    public List<BankCard> GetCant(int index,int n)
    {
        List<BankCard> result = new List<BankCard>();
        GameBank[keys[index]] -= n;

        for(int i =0;i < n;i++)
        {
            result.Add(keys[index]);
        }

        return result;
    }

    public List<BankCard> GetCant(BankCard card,int n)
    {
        List<BankCard> result = new List<BankCard>();
        GameBank[card] -= n;

        for(int i =0;i < n;i++)
        {
            result.Add(card);
        }

        return result;
    }

    public void Add(BankCard a)
    {
        GameBank[a]++;
    }

    public void AddCant(List<BankCard> a)
    {
        GameBank[a[0]] += a.Count;
    }
}