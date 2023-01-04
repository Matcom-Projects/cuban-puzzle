using System.Text.RegularExpressions;
namespace engine_cuban_puzzle;

public class Utils
{
    public static string SaveText()
    {
        string[] directions = Directory.GetFiles("../Content","*.txt");
        StreamReader fileReader = new StreamReader(directions[0]);
        string text = fileReader.ReadToEnd();

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
