namespace engine_cuban_puzzle;

public class GameActions
    {
        public static void Move ( List<Card> a , List<Card> b , int index )
        {
            b.Add(a[index]);
            a.RemoveAt(index);
        }

        public static void GiveActions()
        {
            GameEngine.CantActionsPerTurn ++;
        }

        public static void Draw(int n,IPlayer Player)
        {
            Player.Table.DrawDeck(n);
        }

        public static void SaveCards(int index,IPlayer Player)
        {
            Player.Table.HandToSaveCards(index);
        }
        public static void Trash(int index, List<Card> list)
        {
            GameEngine.bank.Add( (BankCard)list[index]);
            list.RemoveAt(index);
        }

        public static void Attack(IPlayer Player,IPlayer Victim,int cantgem)
        {
            List<BankCard> result = new List<BankCard>();
            List<int> indexs = new List<int>();
            for(int i = 0 ; i < cantgem ; i++ )
            {
                int index = Player.SelectGem();
                result.AddRange(GameEngine.bank.GetCant(0,Player.Table.GemPile[index].Money));
                indexs.Add(index);
            }
            Victim.Table.ToGemPile(result);

            indexs.Sort();
            for(int j = indexs.Count-1; j >= 0; j--)
            {
                Player.Table.GemPile.RemoveAt(j);
            }
        }

        public static void GainCard ( IPlayer Player, BankCard card )
        {
            Player.Table.ToDiscardPile( GameEngine.bank.Get(card));
        }

        public static void Sacrifice(IPlayer Player, int index)
        {
            Move(Player.Table.HandCards,Player.Table.DiscardPile,index);
        }

        public static void Revive(IPlayer Player, int index)
        {
            Move(Player.Table.DiscardPile,Player.Table.HandCards,index);
        }
    }
