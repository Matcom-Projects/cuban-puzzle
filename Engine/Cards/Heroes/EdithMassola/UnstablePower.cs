namespace engine_cuban_puzzle;

public class UnstablePower : ActionCard
    {
        public UnstablePower() : base("Unstable Power", new string[]{"purple"}, 0)
        {
            
        }

        public override void Action(IPlayer a)
        {
            GameActions.GainCard(a, GameEngine.bank.keys[5]);
            GameActions.GainCard(a, GameEngine.bank.keys[7]);
            GameActions.GainCard(a, GameEngine.bank.keys[7]);
        }
        

        /*Informacion de la carta:
        1. Gana un doble crash gem, pero tambien dos CUP 
        */
    }
