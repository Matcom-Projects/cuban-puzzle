using System.Text.RegularExpressions;
namespace engine_cuban_puzzle
{
    public class Utils
    {
        public static string SaveText()
        {
            string path = @"..\Content\Cree su carta aqui.txt";
            string text = File.ReadAllText(path);

            return text;
        }

        public static List<string> SplitText(string texto)
        {
            return texto.Split().ToList();
        }

        public static string RemoveWhiteSpaces(string text)
        {
            return Regex.Replace(text, @"\s+", " ");
        }
    }
}