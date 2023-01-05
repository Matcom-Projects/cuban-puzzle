namespace engine_cuban_puzzle;

public class MartialMastery : ActionCard
{
        public MartialMastery() : base("Martial Mastery", new string[]{"yellow"}, 0)
        {

        }
        public override void Action(IPlayer a)
        {
            GameActions.GiveActions();
            //trash
            Card card;
            for(int i=0; i<a.Table.HandCards.Count; i++)
            {
                if(a.Table.HandCards[i].Color.Contains("purple"))
                {
                    card = a.Table.HandCards[i];

                    try
                    {
                        GameActions.Trash(i,a.Table.HandCards);
                        break;
                    }
                    catch (System.InvalidCastException ex)
                    {
                        System.Console.WriteLine("No se puede trashear un heroe");
                    }

                }
            }
            //mas money
            GameEngine.CantMoneyPerTurn+= 4;
        }

        /*Informacion de la carta:
        1. Da una accion mas
        2. Trashea una carta de su mano que no sea morada: (Da una accion mas y activa accion 2.1)
            2.1 Gana una carta que tenga costo exactamente 2 mas que la carta trasheada
        */
}
