namespace engine_cuban_puzzle
{
    public class Result
    {
        public static string Name{get; set;}
        public static string Color{get; set;}
        public static int Cost{get; set;}
        public static int Money{get; set;}
        public static int Draw{get; set;}
        public static int GiveAction{get; set;}
        public static int SaveCard{get; set;}
        public static bool[] MapActions = new bool[6];
    }
}