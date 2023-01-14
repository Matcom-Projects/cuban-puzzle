namespace engine_cuban_puzzle;
using System.Collections.Generic;

public abstract class Card
{
    public string Name { get; private set; }
    public string Color { get; private set; }
    public int Money { get; set; }
    public string Information {get; private set;}
    public Card ( string name,string color,int money,string information)
    {
        this.Name = name;
        this.Color = color;
        this.Money = money;
        this.Information =information;
    }
}