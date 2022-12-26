using System.Linq;
using System.Collections.Generic;
using System.Collections;
namespace engine_cuban_puzzle
{
    public class VirtualPlayer : IPlayer
    {
        public string Name { get; }
        public TablePlayer Table { get; set; }
        public VirtualPlayer(string name)
        {
            this.Name = name;
            this.Table = new TablePlayer();
        }
        
        public bool Exit()
        {
            return false;
        }
        public int SelectCardHand()
        {
            Console.ReadLine();
            
            if(Table.HandCards.Contains(GameEngine.bank.keys[5])) return Table.HandCards.IndexOf(GameEngine.bank.keys[5]);
            if(Table.HandCards.Contains(GameEngine.bank.keys[4])) return Table.HandCards.IndexOf(GameEngine.bank.keys[4]);
            if(Table.HandCards.Contains(GameEngine.bank.keys[6])) return Table.HandCards.IndexOf(GameEngine.bank.keys[6]);
            
            for(int i=0; i<Table.HandCards.Count; i++)
            {
                if(Table.HandCards[i] is IActionable)
                    return i;
            }

            return -1;
        }
        public Card SelectCardOnGoing()
        {
            Console.ReadLine();
            
            if(Table.OnGoing.Count == 0) return null;
            return Table.OnGoing[Table.OnGoing.Count-1];
        }
        public bool SelectField()
        {   
            return false;
        }
        public void ChooseActionRealize(IActionable card)
        {
            System.Console.WriteLine($"Seleccionó del OnGoing {card.Name}");
            Console.ReadLine();
            
            if(card is Combine)
            {
                card.Trash(this);
                return;
            }
            if(card.Actions[3])
            {
                card.Attack(SelectGem(), SelectPlayer());
                return;
            }
            
            List<int> list = new List<int>();
            for(int i=0; i<card.Actions.Length; i++)
            {
                if(card.Actions[i]) list.Add(i);
            }

            int index = 0;
            do
            {
                index = GameUtils.GetRandom(0,list.Count);
            } while (index==3);
            switch (index)
            {
                case 0:
                {
                    card.GiveActions();
                    break;
                }
                case 1:
                {
                    card.SaveCards(SelectCardHand(),this);
                    break;
                }
                case 2:
                {
                    card.Draw(this);
                    break;
                }
                case 4:
                {
                    card.Trash(this);
                    break;
                }
                case 5:
                {
                    card.GainCard(this);
                    break;
                }
                default : break;
            }
            
        }
        public int SelectGem()
        {
            Console.ReadLine();
            
            int max = int.MinValue;
            int index = 0;
            for(int i=0; i<Table.GemPile.Count; i++)
            {
                if(Table.GemPile[i].Money > max)
                {
                    max = Table.GemPile[i].Money;
                    index = i;
                }
            }
            return index;
        }
        public IPlayer SelectPlayer()
        {
            Console.ReadLine();
            
            int max = int.MinValue;
            int index = 0;
            for(int i=0; i<GameEngine.Turns.Players.Count; i++)
            {
                if((GameEngine.Turns.Players[i]!=this) && (GameEngine.Turns.Players[i].Table.GemPile.Count > max))
                {
                    max = GameEngine.Turns.Players[i].Table.GemPile.Count;
                    index = i;
                }
            }
            return GameEngine.Turns.Players[index];
        }

        public BankCard PlayBuyPhase()
        {
            Console.ReadLine();
            
            int money = GameEngine.CantMoneyPerTurn;
            if(money >= 9) return GameEngine.bank.keys[5];
            if(money >= 7) return GameEngine.bank.keys[3];
            if(money >= 5) return GameEngine.bank.keys[4];
            if(money >= 4) return GameEngine.bank.keys[6];
            if(money >= 3) return GameEngine.bank.keys[1];
            if(money >= 1) return GameEngine.bank.keys[0];
            if(money == 0)
            {
                for(int i=0; i<GameEngine.bank.keys.Count; i++)
                {
                    if(GameEngine.bank.keys[i].Cost==0 && GameEngine.bank.keys[i] !is Cup) return GameEngine.bank.keys[i];
                }
            } 

            return GameEngine.bank.keys[7];
        }
        public bool PlayNextBuyPhases()
        {
            Console.ReadLine();
            
            int money = GameEngine.CantMoneyPerTurn;
            if(money <= 0) return true;
            return false;
        }
        public BankCard SelectCardBank(List<BankCard> list){return list[0];}
        public int SelectCardDeck(){return 0;}
         

    }
}
