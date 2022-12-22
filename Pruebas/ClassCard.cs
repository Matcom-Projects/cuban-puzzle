namespace AppConsole //cambios
{

    public abstract class Card
    {
        public string Id{ get; private set; }
        public string Name{get;private set;}
        public string[] Color{get;private set;}
        public int Money{get;private set;}
        public Card(string name,string[] color,int money)
        {
            this.Id = GameUtils.CreateId();
            this.Name = name;
            this.Color = color;
            this.Money = money;
        }
    }

    public class CreateCards
    {
        public List<Card> AllActionsCard{ get; }
        public List<Card> AllHeroCards{ get; }

        public CreateCards(List<Card> Actions,List<Card> Hero)
        {
            this.AllActionsCard = Actions;
            this.AllHeroCards = Hero;
        }
    }
}