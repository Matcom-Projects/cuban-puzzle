using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System;
namespace Compilador
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = Utils.RemoveWhiteSpaces(Utils.SaveText().TrimEnd());
            List<string> tokens = Utils.SplitText(text);
            
            Interpreter.LexicalAnalyzerStructure(tokens);
        }

    }

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

    public class Interpreter
    {
        public static void LexicalAnalyzerStructure(List<string> tokens)
        {
            int contOpenKey = 0 ; int contCloseKey = 0;
            for(int i=0; i<tokens.Count; i++)
            {
                System.Console.WriteLine(tokens[i]);
                if(tokens[i] == "{")
                {
                    contOpenKey ++;
                    if(i==0) Errors.Structure();
                    else{
                        Tokens.Field.Add(tokens[i-1]);
                    }
                }
                else if(tokens[i].ToLower() == "color")
                {
                    if(i==tokens.Count-1) Errors.Structure();
                    else{
                        Tokens.PropertiesCards.Add(tokens[i+1]);
                    }
                }
                else if(Sintaxis.Properties.Contains(tokens[i].ToLower()))
                {
                    if(i==tokens.Count-1) Errors.Structure();
                    else{
                        VerificationProperty(tokens[i+1]);
                    }
                }
                else if(tokens[i].ToLower() == "if")
                {
                    if(i==tokens.Count-1) Errors.Structure();
                    else{
                        Tokens.Conditionals.Add(tokens[i]);
                    }
                }
                else if(tokens[i] == "}")
                {
                    contCloseKey ++;
                    if(i==0) Errors.Structure();
                }
                else{
                    if(i==tokens.Count-1) Errors.Structure();
                    else if(tokens[i+1] == "{" || Tokens.PropertiesCards.Contains(tokens[i])){
                        continue;
                    }
                    else{
                        Tokens.Field.Add(tokens[i]);
                    }
                }
            }

            if(contOpenKey != contCloseKey) Errors.Structure();
        }

        private static void VerificationProperty(string token)
        {
            int n = 0;
            try
            {
                n = int.Parse(token);
                if(n<0 || n>12) System.Console.WriteLine("Digite un valor en el rango (0,12)");
                else{
                    Tokens.PropertiesCards.Add(token);
                }
            }
            catch (System.FormatException ex)
            {
                Errors.Format();
            }
        }
    }

    public class Tokens
    {
        public static List<string> Field = new List<string>();
        public static List<string> PropertiesCards = new List<string>();
        public static List<string> Conditionals = new List<string>();

    }

    public class Errors
    {
        public static void Structure()
        {
            System.Console.WriteLine("Error: La estructura de creacion de la carta no es correcta");
        }
        public static void Format()
        {
            System.Console.WriteLine("Error: El valor de sus propiedades no es correcto");
        }
        public static void InvalidExpression()
        {
            System.Console.WriteLine("Error: El valor de la expresion NO es valido");
        }
    }

    public class Sintaxis
    {
        public static string[] Properties = {"cost","money","draw","giveaction","savecard"};
        
    }
}
