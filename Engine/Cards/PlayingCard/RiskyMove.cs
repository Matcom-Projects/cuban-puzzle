namespace engine_cuban_puzzle;

// public class RiskyMove : BankCard, IActionable
// {
//     public bool[] Actions {get; set;}
//     public RiskyMove() : base("Risky Move", new string[]{"yellow"}, 0,1)
//     {
//         this.Actions = new bool[] {false, false, false, false, false, true};
//     }

//     public void GiveActions(){}
//     public void SaveCards(int index, IPlayer a){}
//     public void Draw(IPlayer a){}
//     public void Attack(int index,IPlayer a){}
//     public void Trash(IPlayer a){}
//     public void GainCard(IPlayer a)
//     {
//         for(int i=0; i<a.Table.HandCards.Count; i++)
//         {
//             if(a.Table.HandCards[i] is Gem1)
//             {
//                 GameUtils.Move(a.Table.HandCards, a.Table.GemPile, i);
//                 a.Table.DiscardPile.Add(GameEngine.bank.Get(new Gem2()));
//                 GameEngine.CantMoneyPerTurn += 3;
//                 return;
//             }
//         }
//     }

//     /*Informacion de la carta:
//     1. Pon una gem1 de tu mano en tu gema de pila, entonces ganas una gem2 y 3$ para la fase de compra
//     */
// }
