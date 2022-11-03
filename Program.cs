namespace Implementations
{
    public class Fields
    {
        public static List<Cards> Deck = new List<Cards>();
        public static List<Cards> Hand = new List<Cards>();
        public static List<Cards> DiscardPile = new List<Cards>();
        public static List<Gem> GemPile = new List<Gem>();
        public static List<Cards> Ongoing = new List<Cards>();
        public static Dictionary<BankCards,int> Bank = new Dictionary<BankCards,int>();
    }

        
    public class Phases
    {
        public int actions = 1;
        public int saveCard = 0;
        public int deckRobbery = 0;
        public int money = 0;

        /*En esta fase se roba una gema del banco hacia la pila de gemas */        
        public static void Ante()
        {
            Fields.GemPile.Add(new Gem(1,1)); 
            Bank[Gem(1,1)] --;
        }
        
        /*En esta fase se decide la accion que va a realizar a partir de las cartas que va a jugar */
        public static void Action()
        {
            List<int> list = Actions.Choose(Fields.Hand);//Escoger una carta de mi mano (se puede hacer en el Main)
            Cards card = Fields.Hand[list[0]];
            Fields.Ongoing.Add(card);//mandarla hacia Ongoing
            Fields.Hand.Remove(card);
            //Luego activar esta carta a partir de la funcionalidad que realiza
            actions += card.Actions;
            saveCard += card.SaveCard;
            deckRobbery += card.DeckRobbery;
            money += card.Money;
        }
        
        /*En esta fase se decide la compra que va a realizar en funcion del dinero que tienes en la mano */
        public static void Buy()
        {
            if(money<=0)
            {
                while(money<=0)
                {
                    Fields.DiscardPile.Add(new Wound());
                    money++;
                }
            }
            else{
                foreach(Gem a in Fields.Hand)
                {
                    money += a.Count;
                }

                
            }
            
            

        }
        
        /*En esta fase todas las cartas que se quedaron en la mano y todas aquellas que se jugaron y no fueron
        trashadas se envian directamente hacia la pila de descartes */        
        public static void CleanUp()
        {
            int amountGem = Fields.GemPile.Count;
            if(amountGem<=2) Actions.Draw(5);
            if(amountGem>=3 && amountGem<=5) Actions.Draw(6);
            if(amountGem>=6 && amountGem<=8) Actions.Draw(7);
            if(amountGem==9) Actions.Draw(8);
            if(amountGem>=10) GameOver();
        }
    }
    
    public class Actions
    {
        public static void Draw(int number)
        {
            for(int i=0; i<number; i++)
            {
                Fields.Hand.Add(deck[0]);
                Fields.Deck.Remove(deck[0]);
            }
        }

        public static List<int> Choose(List<Cards> list)
        {
            for(int i=0; i<list.Count; i++)
            {
                Console.WriteLine((i+1)+list[i]);
            }
            List<int> pos = new List<int>();
            do{
                Console.WriteLine("Elija una opcion(#)/ NO hacerlo(-1): ");
                int opc = Console.ReadLine();
                if(p!=-1) pos.Add(opc-1);
            }while(p!=-1);

            return pos;
        }

        public static int SumElementsList(List<int> list)
        {
            int sum = 0;
            foreach(var l in list)
            {
                sum += l;
            }

            return sum;
        }

        public static void Execute(Cards card)
        {

        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            
        }
    }

    
}