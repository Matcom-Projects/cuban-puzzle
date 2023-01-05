namespace engine_cuban_puzzle;

public class BurningVigor : ActionCard
    {
        public BurningVigor() : base("Burning Vigor", new string[]{"red"}, 0)
        {
            
        }
        
        public override void Action(IPlayer a)
        {
            if(a.Table.HandCards.Contains(GameEngine.bank.keys[7]))
            {
                int i = a.Table.HandCards.IndexOf(GameEngine.bank.keys[7]);
                GameActions.Trash(i,a.Table.HandCards);
                GameActions.GiveActions();
                foreach(var p in GameEngine.Turns.Players)
                {
                    if(p==a) continue;
                    p.Table.GemPile.Add(GameEngine.bank.Get(new Gem1()));
                }
                return;
            }
            else if(a.Table.DiscardPile.Contains(GameEngine.bank.keys[7]))
            {
                int j = a.Table.DiscardPile.IndexOf(GameEngine.bank.keys[7]);
                GameActions.Trash(j,a.Table.DiscardPile);
                GameActions.GiveActions();
                foreach(var p in GameEngine.Turns.Players)
                {
                    if(p==a) continue;
                    p.Table.GemPile.Add(GameEngine.bank.Get(new Gem1()));
                }
                return;
            }
        }
        

        /*Informacion de la carta:
        1. Trashea un CUP de la mano o pila de descartes
            1.1 Da una accion mas y agrega una gem1 a la gema de pila de los oponentes
        */
    }
