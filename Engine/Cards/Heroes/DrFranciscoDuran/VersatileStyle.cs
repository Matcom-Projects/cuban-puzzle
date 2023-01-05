namespace engine_cuban_puzzle;

public class VersatileStyle : ActionCard
    {
        public VersatileStyle() : base("Versatile Style", new string[]{"yellow"}, 2)
        {
            
        }
        public override void Action(IPlayer a)
        {
            GameActions.GiveActions();
            GameActions.SaveCards(a.SelectCardHand(),a);
            GameActions.Draw(2,a);
        }

        /*Informacion de la carta:
        1. Da una accion mas y 2 pesos mas para la fase de compra
        2. Guarda una carta para el proximo turno
        3. Coge dos cartas del deck
            */
    }
