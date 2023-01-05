namespace engine_cuban_puzzle;

public class SneackAttack : ActionBankCard
    {
        public SneackAttack() : base("Sneack Attack", new string[]{"red"}, 0,3)
        {
            
        }

        public override void Action(IPlayer a)
        {
            GameActions.GiveActions();
            GameActions.GainCard(a, GameEngine.bank.keys[0]);
            foreach(var p in GameEngine.Turns.Players)
            {
                if(p==a) continue;
                p.Table.GemPile.Add(GameEngine.bank.Get(GameEngine.bank.keys[0]));
            }
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return $"[{this.Name}]";
        }

        /*Informacion de la carta:
        1. Da una accion mas
        2. Gana un gem1 y pone un gem1 en las pilas de gemas de los oponentes
        */
    }
