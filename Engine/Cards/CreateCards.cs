namespace engine_cuban_puzzle;

public class CreateCards
{
    public static List<BankCard>? AllActionsCards;
    public static List<Card>? AllHeroCards;

    public static void ReadCards()
    {
        AllActionsCards = new List<BankCard>();
        AllHeroCards = new List<Card>();

        string[] DirectionsActionsCards = Directory.GetFiles(@"../ActionCards","*.txt");
        string[] DirectionsHeroCards = Directory.GetFiles(@"../HeroCards","*.txt");

        for(int i =0;i < DirectionsActionsCards.Length;i++){
                
            StreamReader fileReader = new StreamReader(@DirectionsActionsCards[i]);
            string text = fileReader.ReadToEnd();
            System.Console.WriteLine("Parseando "+Path.GetFileNameWithoutExtension(DirectionsActionsCards[i]));
            ActionBankCard card = new ActionCardByUser(Path.GetFileNameWithoutExtension(DirectionsActionsCards[i]),new ActionCard_Node(text));
            AllActionsCards.Add(card);
        }
        for(int i =0;i < DirectionsHeroCards.Length;i++){
                
            StreamReader fileReader = new StreamReader(@DirectionsHeroCards[i]);
            string text = fileReader.ReadToEnd();
            System.Console.WriteLine("Parseando "+Path.GetFileNameWithoutExtension(DirectionsHeroCards[i]));
            ActionCard card = new HeroCardByUser(Path.GetFileNameWithoutExtension(DirectionsHeroCards[i]),new HeroCard_Node(text));
            AllHeroCards.Add(card);
        }
    }
}