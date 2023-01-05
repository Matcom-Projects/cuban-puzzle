namespace engine_cuban_puzzle;

public class GemEssence : ActionBankCard
    {
        public GemEssence() : base("Gem Essence", new string[]{"yellow"}, 0,3)
        {

        }

        public override void Action(IPlayer a)
        {
            if(a.Table.HandCards.Contains(GameEngine.bank.keys[0]))
            {
                int i = a.Table.HandCards.IndexOf(GameEngine.bank.keys[0]);
                GameActions.Trash(i,a.Table.HandCards);
                GameActions.GiveActions();
            }
        }
        
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return $"[{this.Name}]";
        }

        /*Informacion de la carta:
        1. Trashea una gema de 1 y tienes una accion mas
        */
    }
