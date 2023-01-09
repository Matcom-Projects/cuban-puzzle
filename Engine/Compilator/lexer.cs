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

        Ids.Add("int",new Token(Type.Int,"int"));
        Ids.Add("bool",new Token(Type.Boolean,"bool"));
        Ids.Add("player",new Token(Type.iPlayer,"player"));
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
        Ids.Add("save",new Token(Type.save,"save"));
        Ids.Add("bankcards",new Token(Type.bankcards,"bankcards"));
        Ids.Add("gempile",new Token(Type.gempile,"gempile"));
        Ids.Add("gem1",new Token(Type.gem1,"gem1"));
        Ids.Add("gem2",new Token(Type.gem2,"gem2"));
        Ids.Add("gem3",new Token(Type.gem3,"gem3"));
        Ids.Add("gem4",new Token(Type.gem4,"gem4"));
        Ids.Add("cup",new Token(Type.cup,"cup"));
        Ids.Add("crashgem",new Token(Type.crashgem,"crashgem"));
        Ids.Add("doblecrashgem",new Token(Type.doblecrashgem,"doblecrashgem"));
        Ids.Add("combine",new Token(Type.combine,"combine"));
        Ids.Add("selectplayer",new Token(Type.selectplayer,"selecplayer"));
        Ids.Add("selectcardongoing",new Token(Type.selectcardongoing,"selectcardongoing"));
        Ids.Add("selectcardhand",new Token(Type.selectcardhand,"selectcardhand"));
        Ids.Add("selectcarddeck",new Token(Type.selectcarddeck,"selectcarddeck"));
        Ids.Add("selectcarddiscardpile",new Token(Type.selectcarddiscardpile,"selectcarddiscardpile"));
        Ids.Add("selectcardbank",new Token(Type.selectcardbank,"selectcardbank"));
        Ids.Add("selectgem",new Token(Type.selectgem,"selectgem"));
        Ids.Add("round",new Token(Type.round,"round"));
        Ids.Add("cantgem",new Token(Type.cantgem,"cantgem"));
        Ids.Add("selectcard",new Token(Type.selectcard,"selectcard"));
        Ids.Add("move",new Token(Type.move,"move"));
        Ids.Add("giveactions",new Token(Type.giveactions,"giveactions"));
        Ids.Add("givemoney",new Token(Type.givemoney,"givemoney"));
        Ids.Add("draw",new Token(Type.draw,"draw"));
        Ids.Add("savecards",new Token(Type.savecards,"savecards"));
        Ids.Add("trash",new Token(Type.trash,"trash"));
        Ids.Add("attack",new Token(Type.attack,"attack"));
        Ids.Add("gaincard",new Token(Type.gaincard,"gaincard"));
        Ids.Add("sacrifice",new Token(Type.sacrifice,"sacrifice"));
        Ids.Add("revive",new Token(Type.revive,"revive"));
        Ids.Add("overtaking",new Token(Type.overtaking,"overtaking"));
    }
    private bool IsInt()
    {
        return (Current >= 48 && Current <= 57);
    }
    private bool IsLetter()
    {
        return (Current >= 97 && Current <= 122);
    }

    private bool IsAlfaNumeric()
    {
        return (IsLetter()|| IsInt());
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

        while(Current != '#' && IsAlfaNumeric())
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
            if(Current == '[')
            {
                Advance();
                return new Token(Type.LBracket,"[");
            }
            if(Current == ']')
            {
                Advance();
                return new Token(Type.RBracket,"]");
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
            if(Current == ',')
            {
                return new Token(Type.Colon,",");
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