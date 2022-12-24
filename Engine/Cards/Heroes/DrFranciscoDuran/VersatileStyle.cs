namespace engine_cuban_puzzle
{
    public class VersatileStyle : Card, IActionable
    {
        public bool[] Actions {get; set;}
        public VersatileStyle() : base("Versatile Style", new string[]{"yellow"}, 2)
        {
            this.Actions = new bool[] {true, true, true, false, false, false};
        }
        public void GiveActions()
        {
            GameEngine.CantActionsPerTurn ++;
        }

        public void SaveCards(int index, IPlayer a)
        {
            a.Table.HandToSaveCards(index);
        }
        public void Draw(IPlayer a)
        {
            a.Table.DrawDeck(2);
        }
        public void Attack(int index,IPlayer a){}
        public void Trash(IPlayer a){}
        public void GainCard(IPlayer a){}

        /*Informacion de la carta:
        1. Da una accion mas y 2 pesos mas para la fase de compra
        2. Guarda una carta para el proximo turno
        3. Coge dos cartas del deck
         */
    }
}