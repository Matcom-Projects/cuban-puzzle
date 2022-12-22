using System.Collections.Generic;

namespace AppConsole
{
    public class GameUtils
    {
        public static void Move ( List<Card> a , List<Card> b , int index )
        {
            b.Add(a[index]);
            a.RemoveAt(index);
        }
        public static List<IPlayer> Mezclar(List<IPlayer> a)
        {
            List<IPlayer> result = new List<IPlayer>();    
            int index;

            while(a.Count != 0)
            {
                index = GetRandom(0,a.Count);//aqui creo que es a.Count-1 pq si el count==4, no se puede indexar en ese valor pq se va de los limites del array 
                result.Add(a[index]);
                a.RemoveAt(index);
            }

            return result;
        }

        public static int GetRandom(int min,int max)
        {
            Random e = new Random();
            return e.Next(min,max);
        }
        public static string CreateId ()//para cuando se haga la ast
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string result = "";
            Random e = new Random();

            for( int i = 0 ; i < 8 ; i++ )
            {
                result += letters [ e.Next(0,letters.Length) ];//mismo comentario que linea 20, pero en este caso Length-1
            }

            return result;
        }

    }

    public class GameActions
    {
        public static void GiveActions()
       {
           GameEngine.CantActionsPerTurn ++;
       }

       public static void SaveCards(int index) //index de la carta a salvar para el proximo turno
       {
           GameUtils.Move(TablePlayer.HandCards, TablePlayer.SavedCards, index);
       }

       public static void GetDeck(List<int> indexs)
       {
           while(indexs.Count>0)
           {
                GameUtils.Move(TablePlayer.Deck, TablePlayer.DiscardPile, indexs[indexs.Count-1]);
                indexs.RemoveAt(indexs.Count-1);
           }
       }
        public static void Attack(int index,IPlayer attack)
        {
            GameUtils.Move(TablePlayer.GemPile, attack.TablePlayer.GemPile, index);
        }

        public static void Trash(Bank bank, Card card, List<Card> list)
        {
            bank.Add(card);
            list.Remove(card);
        }

        public static void GainCard(Bank bank, IPlayer a, Card card)
        {
            a.TablePlayer.DiscardPile.Add(bank.Get(card));
        }
    }

    public class GameEngine
    {
        string Historial = "";
        public int CantActionsPerTurn = 1;
        int CantMoneyPerTurn = 0;
        GameTurns? Turns ;
        public void PlayGame(List<IPlayer> players,Bank bank)
        {
            Turns = new GameTurns(players);
            while(true)
            {
                Turns.MoveNext();
                ActionPhase(Turns.Current,bank);
                BuyPhase(Turns.Current);
                CleanUpPhase(Turns.Current);
            }
        }

        public void ActionPhase(IPlayer a,Bank bank)
        {
            int index = a.SelectCardHand();
            a.TablePlayer.HandCards.RemoveAt(index);
            GameUtils.Move(TablePlayer.HandCards, TablePlayer.OnGoing, index);
            Card card = a.SelectCardOnGoing();
            a.ChooseActionRealize(card,bank);
        }

        public void BuyPhase(IPlayer a)
        {

        }

        public void CleanUpPhase(IPlayer a)
        {

        }
    }
}
