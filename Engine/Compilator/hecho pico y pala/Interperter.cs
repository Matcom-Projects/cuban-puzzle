namespace engine_cuban_puzzle;

public class Interperter
{
    public static bool ExistError = false;
    public static void Execute()
    {
        string text = Utils.RemoveWhiteSpaces(Utils.SaveText().TrimEnd());
        List<string> tokens = Utils.SplitText(text);
        
        LexicalAnalyzerStructure(tokens);
        LexicalAnalyzerField();
        LexicalAnalyzerPropertiesCards(tokens);
        
        if(!ExistError)
        {
            if(Result.Cost == -1)
            {
                CreateCards.ListHeroeByUser.Add(new HeroeByUser());
                return;
            }
            else if(Result.MapActions.Contains(true))
            {
                CreateCards.ListActionCardByUser.Add(new ActionCardByUser());
                return;
            }
            else{
                CreateCards.ListBankCardByUser.Add(new BankCardByUser());
                return;
            }
        }
    }
    public static void LexicalAnalyzerStructure(List<string> tokens)
    {
        int contOpenKey = 0 ; int contCloseKey = 0;
        for(int i=0; i<tokens.Count; i++)
        {
            //System.Console.WriteLine(tokens[i]);
            if(tokens[i] == "{")
            {
                contOpenKey ++;
                if(i==0) Errors.Structure();
                else{
                    Tokens.Field.Add(tokens[i-1]);
                }
            }
            else if(Syntax.Properties.Contains(tokens[i].ToLower()))
            {
                if(i==tokens.Count-1) Errors.Structure();
                else{
                    Tokens.PropertiesCards.Add(tokens[i+1]);
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

    public static void LexicalAnalyzerField()
    {
        Result.Name = Tokens.Field[0];
        if((Tokens.Field.Count > 1) && (Tokens.Field[1].ToLower() != "action")) Errors.Field();
        

    }

    public static void LexicalAnalyzerPropertiesCards(List<string> list)
    {
        List<string> tokens = new List<string>();
        tokens.AddRange(list);
        
        for(int i=0; i<Tokens.PropertiesCards.Count; i++)
        {
            int index = tokens.IndexOf(Tokens.PropertiesCards[i]);
            if(tokens.IndexOf("color") == index - 1)
            {
                if(Syntax.Color.Contains(Tokens.PropertiesCards[i].ToLower())) Result.Color = Tokens.PropertiesCards[i].ToLower();
                else{
                    Errors.PropertiesCards();
                }
                tokens[index] = "~~~~";
            }
            else if(tokens.IndexOf("cost") == index - 1)
            {
                if(Tokens.PropertiesCards[i] == "-1") Result.Cost = -1;
                int n = VerificationProperty(Tokens.PropertiesCards[i], 0, 12);
                if(n==50) continue;
                else{
                    Result.Cost = n;
                }
                tokens[index] = "~~~~";
            }
            else if(tokens.IndexOf("money") == index - 1)
            {
                int n = VerificationProperty(Tokens.PropertiesCards[i], -5, 10);
                if(n==50) continue;
                else{
                    Result.Money = n;
                }
                tokens[index] = "~~~~";
            }
            else if(tokens.IndexOf("draw") == index - 1)
            {
                if(Tokens.PropertiesCards[i] == "-1") Result.Draw = -1;
                int n = VerificationProperty(Tokens.PropertiesCards[i], 0, 3);
                if(n==50) continue;
                else{
                    Result.Draw = n;
                    Result.MapActions[2] = true;
                }
                tokens[index] = "~~~~";
            }
            else if(tokens.IndexOf("giveaction") == index - 1)
            {
                if(Tokens.PropertiesCards[i] == "-1") Result.GiveAction = -1;
                int n = VerificationProperty(Tokens.PropertiesCards[i], 0, 4);
                if(n==50) continue;
                else{
                    Result.GiveAction = n;
                    Result.MapActions[0] = true;
                }
                tokens[index] = "~~~~";
            }
            else if(tokens.IndexOf("savecard") == index - 1)
            {
                if(Tokens.PropertiesCards[i] == "-1") Result.SaveCard = -1;
                int n = VerificationProperty(Tokens.PropertiesCards[i], 0, 1);
                if(n==50) continue;
                else{
                    Result.SaveCard = n;
                    Result.MapActions[1] = true;
                }
                tokens[index] = "~~~~";
            }
            else{
                Errors.PropertiesCards();
                continue;
            }
        }
    }

    private static int VerificationProperty(string token, int min, int max)
    {
        int n = 0;
        try
        {
            n = int.Parse(token);
            if( n < min || n > max )
            {
                Errors.Range(min,max);
                return 50;
            }
            
            return n;
        }
        catch (System.FormatException ex)
        {
            Errors.Format();
        }

        return 50;
    }
}
