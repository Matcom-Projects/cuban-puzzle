namespace engine_cuban_puzzle;
using System;
public class HeroCard_Node
{
    public string Text;
    public string Color;
    public int Money;
    public string Information;
    private Dictionary<string,string> BasicPropieties{ get; set;}
    public Interpreter Action {get;private set;}

    public HeroCard_Node(string text)
    {
        this.Text = text;
        BasicPropieties = new Dictionary<string, string>();
        ReadPropieties();
        this.Color = BasicPropieties["color"];
        this.Information = BasicPropieties["information"];
        try
        {
            this.Money = int.Parse(BasicPropieties["money"]);
        }
        catch
        {
            throw new System.Exception("Se esperaba un numero en la propiedad money.");
        }
        Lexer lexer = new Lexer(Text);
        Parse parser = new Parse(lexer);
        this.Action = new Interpreter(parser);
    }

    private void ReadPropieties()
    {
        int color = Text.IndexOf("Color");
        if(color == -1) throw new Exception("No esta definida la propiedad color.");
        BasicPropieties.Add("color",ReadAssing(color+5,false));

        int money = Text.IndexOf("Money");
        if(money == -1) throw new Exception("No esta definida la propiedad money.");
        BasicPropieties.Add("money",ReadAssing(money+5,false));

        int information = Text.IndexOf("Information");
        if(information == -1) throw new Exception("No esta definida la informacion de la carta.");
        BasicPropieties.Add("information",ReadAssing(information+11,true));

        int action = Text.IndexOf("Action");
        if(action == -1) throw new Exception("No esta definida la accion");
        Text = Text[(action + 6) .. (CountBrace(action+6))];
    }
    private string ReadAssing(int n,bool IsInformation)
    {
        string result = "";

        n = SkipSpaces(n);

        if(Text[n] != '=') throw new Exception("Se esperaba =.");

        n++;

        n = SkipSpaces(n);
        if(IsInformation)
        {
            while(Text[n]!=';')
            {
                result+=Text[n];
                n++;
            }
        }
        else
        {
            if(!(IsInt(Text[n])|| IsLetter(Text[n]))) throw new Exception("Se espera la entrada de algun valor.");

            while(IsInt(Text[n])|| IsLetter(Text[n]))
            {
                result += Text[n];
                n++;
            }

            n = SkipSpaces(n);
            
            if(Text[n] != ';'){Console.WriteLine(Text[n]); throw new Exception("Se esperaba ;");}
        }
        
        return result;
    }
    private int SkipSpaces(int n)
    {
        while(Text[n] == ' ' || Text[n]=='\n')
        {
            n++;
        }
        return n;
    }
    private bool IsInt(char caracter)
    {
        return (caracter >= 48 && caracter <= 57);
    }
    private bool IsLetter(char caracter)
    {
        return ( ( caracter >= 97 && caracter <= 122 ) || ( caracter >= 65 && caracter <= 90 ) );
    }
    private int CountBrace(int index)
    {
        int cantLbraacket = 1;
        index = SkipSpaces(index);
        if (Text[index] != '{') throw new Exception("aqui deberia haber un {");
        index ++;

        while(cantLbraacket > 0)
        {
            if(Text[index]=='{') cantLbraacket++;
            else if (Text[index] == '}') cantLbraacket--;
            index ++;
        }

        return index;
    }
}