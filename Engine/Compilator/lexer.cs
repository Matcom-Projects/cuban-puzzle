namespace engine_cuban_puzzle;

public class Lexer
{
    public string Text;
    private int Pos ;
    public char Current ;
    public Dictionary<string,Token> Ids;
    public Lexer(string text)
    {
        this.Text = text;
        this.Pos = 0;
        this.Current = Text[0];
        this.Ids = new Dictionary<string, Token>();
        Ids.Add("{",new Token(Type.LBrace,"{"));
        Ids.Add("}",new Token(Type.RBrace,"}"));
        Ids.Add("int",new Token(Type.Int,"int"));
        Ids.Add("bool",new Token(Type.Boolean,"bool"));
        Ids.Add("player",new Token(Type.iPlayer,"player"));
        Ids.Add("acard",new Token(Type.ACard,"acard"));
        Ids.Add("abcard",new Token(Type.ABCard,"abcard"));
        Ids.Add("true",new Token(Type.True,"true"));
        Ids.Add("false",new Token(Type.False,"false"));
        Ids.Add("for",new Token(Type.For,"for"));
        Ids.Add("if",new Token(Type.If,"if"));
        Ids.Add("else",new Token(Type.Else,"else"));
        Ids.Add("me",new Token(Type.Me,"me"));
        Ids.Add("deck",new Token(Type.deck,"deck"));
        Ids.Add("hand",new Token(Type.hand,"hand"));
        Ids.Add("ongoing",new Token(Type.ongoing,"ongoing"));
        Ids.Add("discardpile",new Token(Type.discardpile,"discardpile"));
        Ids.Add("savecard",new Token(Type.savecard,"savecard"));
        Ids.Add("bankcards",new Token(Type.bankcards,"bankcards"));
    }
    private bool IsInt()
    {
        return (Current >= 48 && Current <= 57);
    }
    private bool IsLetter()
    {
        return (Current >= 97 && Current <= 122);
    }
    private bool IsSpace()
    {
        return Current == ' ';
    }

    public void Advance()
    {
        Pos++;

        if( Pos >= Text.Length ) Current = '#';
        else Current = Text[Pos];
    }

    public void SkipWhiteSpace()
    {
        while(Current!='#' && IsSpace())
        {
            Advance();
        } 
    }

    public char Peek()
    {
        int peek_pos = Pos + 1;

        if(peek_pos >= Text.Length) throw new Exception("se fue de talla");

        return Text[peek_pos];
    }

    public string Interger()
    {
        string result = "";

        while(Current!='#' && IsInt())
        {
            result += Current;
            Advance();
        }

        return result;
    }

    private Token _id()
    {
        string result = "";

        while(Current!='#'&& IsLetter())
        {
            result += Current;
            Advance();
        }
        if(Ids.ContainsKey(result)) return Ids[result];

        Ids.Add(result,new Token(Type.ID,result));

        return Ids[result];
    }

    public Token Get_Next_Token()
    {
        while(Current!='#')
        {
            if(IsSpace())
            {
                SkipWhiteSpace();
                continue;
            }
            if(IsInt())
            {
                return new Token(Type.Int,Interger());
            }
            if(Current == '+')
            {
                Advance();
                return new Token(Type.Sum,"+");
            }
            if(Current == '-')
            {
                Advance();
                return new Token(Type.Rest,"-");
            }
            if(Current == '*')
            {
                Advance();
                return new Token(Type.Mult,"*");
            }
            if(Current == '/')
            {
                Advance();
                return new Token(Type.Div,"/");
            }
            if(Current == '(')
            {
                Advance();
                return new Token(Type.LParen,"(");
            }
            if(Current == ')')
            {
                Advance();
                return new Token(Type.RParen,")");
            }
            if(IsLetter())
            {
                return _id();
            }
            if(Current=='{')
            {
                Advance();
                return new Token(Type.LBrace,"{");
            }
            if(Current=='}')
            {
                Advance();
                return new Token(Type.RBrace,"}");
            }
            if(Current == '=' && Peek() == '=')
            {
                Advance();
                Advance();
                return new Token(Type.EqualEqual,"==");
            }
            if(Current == '<' && Peek() == '=')
            {
                Advance();
                Advance();
                return new Token(Type.MinorEqual,"<=");
            }
            if(Current == '>' && Peek() == '=')
            {
                Advance();
                Advance();
                return new Token(Type.GreaterEqual,">=");
            }
            if(Current == '!' && Peek() == '=')
            {
                Advance();
                Advance();
                return new Token(Type.Different,"!=");
            }
            if(Current == '=')
            {
                Advance();
                return new Token(Type.Assign,"=");
            }
            if(Current == '<')
            {
                Advance();
                return new Token(Type.Minor,"<");
            }
            if(Current == '>')
            {
                Advance();
                return new Token(Type.Greater,">");
            }
            if(Current == ';')
            {
                Advance();
                return new Token(Type.Semi,";");
            }
            if(Current == '.')
            {
                Advance();
                return new Token(Type.DOT,".");
            }
            throw new Exception("Elemento no valido");
        }

        return new Token(Type.EOF,"#");
    }
}