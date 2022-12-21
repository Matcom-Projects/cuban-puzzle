// namespace AppConsole
// {
//     public class MartialMastery : Card, IActionable, IMove
//     {
//         public void GiveActions(int actions)
//         {
//             actions++;
//         }

//         public static void Move(Table a , Table b , int IndexCard , Player a1, Player b2, ICostable cardT, ICostable cardG)
//         {
//             if(cardT.Color.Contains("purple"))
//             {
//                 throw new ArgumentException("La carta a trashear no puede ser morada");
//             }
//             else{
//                 Bank.Add(cardT);
//                 a.HandCards.RemoveAt(cardT);
//             }

//             if(cardG < cardT.Cost+2)
//             {
//                 throw new ArgumentException("La carta ganada tiene que tener un costo mayor o igual que 2, al de la carta trasheada");
//             }
//             else{
//                 b.DiscardPile.Add(Bank.Get(cardG));
//             }
//         }
//     }
// }
