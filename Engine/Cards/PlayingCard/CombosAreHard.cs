namespace engine_cuban_puzzle;

public class CombosAreHard : ActionBankCard
    {
        public CombosAreHard() : base("Combos Are Hard", new string[]{"yellow"}, 0,6)
        {
    
        }

        public override void Action(IPlayer a)
        {
            GameActions.GainCard(a,GameEngine.bank.keys[3]);
            GameActions.GainCard(a,GameEngine.bank.keys[3]);
            int index = a.Table.OnGoing.IndexOf(this);
            GameActions.Trash(index, a.Table.OnGoing);
        }
        
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return $"[{this.Name}]";
        }

        /*Informacion de la carta:
        1. Gana dos Gem4 y despues trashea esta carta 
        */
    }
