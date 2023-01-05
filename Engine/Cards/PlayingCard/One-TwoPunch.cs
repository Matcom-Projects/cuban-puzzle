namespace engine_cuban_puzzle;

public class OneTwoPunch : ActionBankCard
    {
        public OneTwoPunch() : base("One-Two Punch", new string[]{"yellow"}, 0,4)
        {
            
        }

        public override void Action(IPlayer a)
        {
            GameEngine.CantActionsPerTurn += 2;
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return $"[{this.Name}]";
        }

        /*Informacion de la carta:
        1. Da dos acciones mas
        */
    }
