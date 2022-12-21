namespace engine_cuban_puzzle;
//hola mundo git
public interface IMove
{
    public void Move ( Table a , Table b , int IndexCard , Player a1 , Player b2 );
}

public interface IDrawable
{
    public void Draw()
    {

    }
}
public interface ISaveable
{
    public void Save();
}
public interface IActionable
{
    public void GiveActions();
}

public interface IAttackable
{
    public void Attack();
}

public interface ICombinable
{
    public void Combiner();
}
public interface IReactionable
{
    public void Reaction();
}

public interface ICostable
{
    public int Cost{ get; }
}