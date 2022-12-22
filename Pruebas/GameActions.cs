namespace AppConsole//cambios
{
    public class GameActions 
    /*Todavia no estoy seguro si trabajar mejor con la interface IActionable o con la clase GameActions, creo que le sabremos mejor
    cuando implementemos las cartas
    */
    {
        public static void GiveActions()
       {
           GameEngine.CantActionsPerTurn ++;
       }

       public static void SaveCards(int index) //index de la carta a salvar para el proximo turno
       {
           GameUtils.Move(TablePlayer.HandCards, TablePlayer.SavedCards, index);
       }

       public static void ExecuteGetDeck(List<int> indexs)
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

        public static void GainCard (Bank bank, IPlayer a, Card card)
        {
            a.TablePlayer.DiscardPile.Add(bank.Get(card));
        }
    }
}
