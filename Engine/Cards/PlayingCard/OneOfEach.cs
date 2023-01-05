namespace engine_cuban_puzzle;

public class OneOfEach : ActionBankCard
    {
        public OneOfEach() : base("One Of Each", new string[]{"yellow"}, 1,5)
        {
            
        }

        public override void Action(IPlayer a)
        {
            GameActions.GiveActions();
            GameActions.SaveCards(a.SelectCardHand(), a);
            GameActions.Draw(1,a);
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return $"[{this.Name}]";
        }

        /*Informacion de la carta:
        1. Da una accion mas y 1$ para la fase de compra
        2. Guarda una carta para el proximo turno
        3. Coge una carta del deck
        */
    }
