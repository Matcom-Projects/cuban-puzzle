namespace engine_cuban_puzzle;

public class RiskyMove : ActionBankCard
    {
        public RiskyMove() : base("Risky Move", new string[]{"yellow"}, 0,1)
        {
            
        }

        public override void Action(IPlayer a)
        {
            GameActions.GainCard(a, GameEngine.bank.keys[1]);
            GameEngine.CantMoneyPerTurn += 3;
        }


        /*Informacion de la carta:
        1. Ganas una gem2 y 3$ para la fase de compra
        */
    }
