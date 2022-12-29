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
        public bool ExistIActionable()
        {
            for(int i=0; i<Table.HandCards.Count; i++)
            {
                if(Table.HandCards[i] is IActionable) return true;
            }

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

            return 0;//esta dando bateo esto cada vez q llega aqui indexa en menos 1 y da error, lo cambie a 0 para q pare
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
            System.Console.WriteLine($"Seleccionó del OnGoing {((Card)card).Name}");
            Console.ReadLine();
            
            if(card is Combine)
            {
                card.Trash(this);
                return;
            }
            if(card.Actions[3])
            {
                int x = SelectGem();
                IPlayer player = SelectPlayer();
                System.Console.WriteLine($"Atacó a {player.Name} con {Table.GemPile[x].Money} gemas");
                card.Attack(x, player);
                Console.ReadLine();
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
                index = list[GameUtils.GetRandom(0,list.Count)];
            } while (index==3);
            switch (index)
            {
                case 0:
                {
                    card.GiveActions();
                    System.Console.WriteLine("Tiene una accion mas");
                    Console.ReadLine();
                    break;
                }
                case 1:
                {
                    int pos = SelectCardHand();
                    Card hand = Table.HandCards[pos];
                    card.SaveCards(pos,this);
                    System.Console.WriteLine($"Guardo {hand.Name} para el proximo turno");
                    Console.ReadLine();
                    break;
                }
                case 2:
                {
                    card.Draw(this);
                    System.Console.WriteLine("Robo una carta del deck");
                    Console.ReadLine();
                    break;
                }
                case 4:
                {
                    card.Trash(this);
                    System.Console.WriteLine("Trasheo una carta");
                    Console.ReadLine();
                    break;
                }
                case 5:
                {
                    card.GainCard(this);
                    System.Console.WriteLine("Gano una carta");
                    Console.ReadLine();
                    break;
                }
                default : break;
            }
            
        }
        public int SelectGem()
        {            
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
            if(money >= 9)
            {
                System.Console.WriteLine("Compro un Double CrashGem");
                Console.ReadLine();
                return GameEngine.bank.keys[5];
            }
            if(money >= 7)
            {
                System.Console.WriteLine("Compro un Gem 4");
                Console.ReadLine();
                return GameEngine.bank.keys[3];
            }
            if(money >= 5)
            {
                System.Console.WriteLine("Compro un CrashGem");
                Console.ReadLine();
                return GameEngine.bank.keys[4];
            }
            if(money >= 4)
            {
                System.Console.WriteLine("Compro un Combine");
                Console.ReadLine();
                return GameEngine.bank.keys[6];
            }
            if(money >= 3) 
            {
                System.Console.WriteLine("Compro un Gem 2");
                Console.ReadLine();
                return GameEngine.bank.keys[1];
            }
            if(money >= 1) 
            {
                System.Console.WriteLine("Compro un Gem 1");
                Console.ReadLine();
                return GameEngine.bank.keys[0];
            }
            if(money == 0)
            {
                for(int i=0; i<GameEngine.bank.keys.Count; i++)
                {
                    if(GameEngine.bank.keys[i].Cost==0 && GameEngine.bank.keys[i] !is Cup)
                    {
                        System.Console.WriteLine($"Compro un {GameEngine.bank.keys[i].Name}");
                        Console.ReadLine();
                        return GameEngine.bank.keys[i];
                    }
                }
            } 

            System.Console.WriteLine("Compro un Cup");
            Console.ReadLine();
            return GameEngine.bank.keys[7];
        }
        public bool PlayNextBuyPhases()
        {
            Console.ReadLine();
            
            int money = GameEngine.CantMoneyPerTurn;
            if(money <= 0) 
            {
                System.Console.WriteLine("Termino su fase de compra");
                Console.ReadLine();
                return true;
            }

            System.Console.WriteLine("Sigue su fase de compra");
            Console.ReadLine();
            return false;
        }
        public int SelectCardDeck(){return 0;}
    }
}
