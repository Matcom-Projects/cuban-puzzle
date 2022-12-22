using System.Collections.Generic;

namespace AppConsole//cambios
{
    public class GameEngine
    {
        public static string Historial = "";
        public static int CantActionsPerTurn = 1;
        public static int CantMoneyPerTurn = 0;
        public static GameTurns Turns ;
        public static Bank bank;
        public static IPlayer PlayGame(List<IPlayer> players,Bank b)
        {
            Turns = new GameTurns(players);
            bank = b;
            while(true)
            {
                Turns.MoveNext();
                ActionPhase(Turns.Current,bank);
                BuyPhase(Turns.Current);
                CantActionsPerTurn = 1;
                CantMoneyPerTurn = 0;

                if( CleanUpPhase(Turns.Current) >= 10 )
                {
                    int cantmingems = int.MaxValue;
                    int cantgems;
                    List<IPlayer> winplayers=new List<IPlayer>();

                    foreach(IPlayer a in players)
                    {
                        cantgems = a.Table.CantGem();

                        if(cantgems<cantmingems)
                        {
                            cantmingems = cantgems;
                            winplayers.Clear();
                            winplayers.Add(a);
                        }
                        else if(cantgems == cantmingems) winplayers.Add(a);
                    }
                    if(winplayers.Count == 1)
                    {
                        return winplayers[0];
                    }

                    return PlayGame(winplayers,bank);
                }
            }
        }

        public void ActionPhase(IPlayer a, Bank bank)
        {
            while(CantActionsPerTurn>0)
            {
                if(a.Table.OnGoing.Count!=0 && a.SelectField())
                {
                    Card card = a.SelectCardOnGoing();//seleccionando carta del ongoing
                    a.ChooseActionRealize(card,bank);//escogiendo y ejecutando accion de la carta
                }
                else{
                    a.SelectCardHand();//seleccionar una carta de la mano
                    Card card = a.SelectCardOnGoing();//seleccionando carta del ongoing
                    a.ChooseActionRealize(card,bank);//escogiendo y ejecutando accion de la carta
                }
                
                CantActionsPerTurn--;
            }
        }

        public static void BuyPhase(IPlayer a)
        {
            if ( CantMoneyPerTurn <= 0 )
            {
                a.Table.ToDiscardPile((IEnumerable<Card>)bank.GetCant(new Cup(),1-CantActionsPerTurn));     
            }
            else
            {
                while( CantActionsPerTurn > 0 )
                {
                    ICostable BuyCard = a.PlayBuyPhase();

                    if(BuyCard == null)
                    {
                        break;
                    }

                    if(CantMoneyPerTurn-BuyCard.Cost>=0)
                    {
                        BuyCard = bank.Get(BuyCard);
                        if(BuyCard != null)
                        {
                            a.Table.ToOnGoing((Card) BuyCard);
                            CantMoneyPerTurn -= BuyCard.Cost;
                        }
                    }
                }
            }
        }

        public static int CleanUpPhase(IPlayer a)
        {
            a.Table.CleanUp();
            return a.Table.CantGem();
        }
    }
}
