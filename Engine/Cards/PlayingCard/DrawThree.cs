namespace engine_cuban_puzzle;

public class DrawThree : ActionBankCard
    {
        public DrawThree() : base("Draw Three", new string[]{"yellow"}, 0,3)
        {
            
        }

        public override void Action(IPlayer a)
        {
            GameActions.Draw(3,a);
        }
        
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return $"[{this.Name}]";
        }

        /*Informacion de la carta:
        1. Coge tres cartas del deck
        */
    }
