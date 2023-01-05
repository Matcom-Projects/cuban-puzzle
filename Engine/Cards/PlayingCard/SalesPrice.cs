namespace engine_cuban_puzzle;

public class SalesPrice : ActionBankCard
    {
        public SalesPrice() : base("Sales Price", new string[]{"yellow"}, 3,2)
        {
            
        }

        public override void Action(IPlayer a)
        {
            GameActions.GainCard(a, GameEngine.bank.keys[0]);
            GameEngine.CantMoneyPerTurn += 3;
        }
        
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return $"[{this.Name}]";
        }

        /*Informacion de la carta:
        1. Gana un gem1 y 3$ para la fase de compra
        */
    }
