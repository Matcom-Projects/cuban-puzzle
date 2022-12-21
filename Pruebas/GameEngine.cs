using System.Collections.Generic;

namespace AppConsole
{
    public class GameEngine
    {
        public static List<Card> CreateDeck(Card heroe)
        {
            List<Card> deck = ChoosePlayingCard();

            deck.Add(heroe);
            deck.Add(new CrashGem());
            for(int i=0 ; i<6 ; i++)
            {
                deck.Add(new Gem1());
            }

            return deck;
        }

        private static List<Card> ChoosePlayingCard()
        {
            Random r = new Random();
            List<Card> list = new List<Card>();

            for(int i=0 ; i<5 ; i++)
            {
                list.Add(Program.actionCardsChoosed[r.Next(0,Program.actionCardsChoosed.Count-1)]);
            }

            return list;
        }
    }
}
