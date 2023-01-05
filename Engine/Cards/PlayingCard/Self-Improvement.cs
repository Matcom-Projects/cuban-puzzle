namespace engine_cuban_puzzle;

public class SelfImprovement : ActionBankCard
    {
        public SelfImprovement() : base("Self-Improvement", new string[]{"blue"}, 0,4)
        {
            
        }

        public override void Action(IPlayer a)
        {
            GameActions.Draw(3,a);
            GameActions.Trash(a.SelectCardHand(), a.Table.HandCards);
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            return $"[{this.Name}]";
        }

        /*Informacion de la carta:
        1. Coge tres cartas del deck
        2. Trashea una carta de su mano
        */
    }
