namespace engine_cuban_puzzle;

public class Reversal : ActionCard
    {
        public Reversal() : base("Reversal", new string[]{"purple"}, 0)
        {
            
        }
        public override void Action(IPlayer a)
        {
            GameActions.Draw(2,a);
        }


        /*Informacion de la carta:
        1. Coge dos cartas del deck
        */
    }
