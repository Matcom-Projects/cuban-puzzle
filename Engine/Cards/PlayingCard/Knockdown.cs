namespace engine_cuban_puzzle;

public class Knockdown : ActionBankCard
    {
        public Knockdown() : base("Knockdown", new string[]{"red"}, 0,2)
        {
            
        }

        public override void Action(IPlayer a)
        {
            GameActions.GiveActions();
            IPlayer b = a.SelectPlayer();
            foreach (Card card in b.Table.HandCards)
            {
                if(card.Color.Contains("purple"))
                {
                    int index = a.Table.HandCards.IndexOf(card);
                    GameActions.Trash(index, a.Table.HandCards);
                    return;
                }
            }
        }
    
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return $"[{this.Name}]";
        }

        /*Informacion de la carta:
        1. Da una accion mas
        2. Trashea una carta morada de la mano de un oponente seleccionado
        */
    }
