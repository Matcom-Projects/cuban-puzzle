namespace engine_cuban_puzzle;

public class PlayingWithFire : ActionCard
    {
        public PlayingWithFire() : base("Playing With Fire", new string[]{"yellow"}, 0)
        {

        }

        public override void Action(IPlayer a)
        {
            GameEngine.CantActionsPerTurn += 2;
            GameActions.Draw(1,a);
        }
        

        /*Informacion de la carta:
        1. Da dos acciones mas
        2. Coge una carta del deck 
        */
    }
