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

        Ids.Add("true",new Token(Type.True,"true"));
        Ids.Add("false",new Token(Type.False,"false"));
        Ids.Add("for",new Token(Type.For,"for"));
        Ids.Add("if",new Token(Type.If,"if"));
        Ids.Add("else",new Token(Type.Else,"else"));
        Ids.Add("Me",new Token(Type.Me,"me"));
        Ids.Add("DeckList",new Token(Type.deck,"DeckList"));
        Ids.Add("HandList",new Token(Type.hand,"HandList"));
        Ids.Add("OnGoingList",new Token(Type.ongoing,"OnGoingList"));
        Ids.Add("DiscardPileList",new Token(Type.discardpile,"DiscardPileList"));
        Ids.Add("GemPileList",new Token(Type.gempile,"GemPileList"));
        Ids.Add("Gem1",new Token(Type.gem1,"Gem1"));
        Ids.Add("Gem2",new Token(Type.gem2,"Gem2"));
        Ids.Add("Gem3",new Token(Type.gem3,"Gem3"));
        Ids.Add("Gem4",new Token(Type.gem4,"Gem4"));
        Ids.Add("Cup",new Token(Type.cup,"Cup"));
        Ids.Add("CrashGem",new Token(Type.crashgem,"CrashGem"));
        Ids.Add("DobleCrashGem",new Token(Type.doblecrashgem,"DobleCrashGem"));
        Ids.Add("Combine",new Token(Type.combine,"Combine"));
        Ids.Add("SelectPlayer",new Token(Type.selectplayer,"SelectPlayer"));
        Ids.Add("SelectCardOnGoing",new Token(Type.selectcardongoing,"SelectCardOnGoing"));
        Ids.Add("SelectCardHand",new Token(Type.selectcardhand,"SelectCardHand"));
        Ids.Add("SelectCardDeck",new Token(Type.selectcarddeck,"SelectCardDeck"));
        Ids.Add("SelectCardDiscardPile",new Token(Type.selectcarddiscardpile,"SelectCardDiscardPile"));
        Ids.Add("SelectCardBank",new Token(Type.selectcardbank,"SelectCardBank"));
        Ids.Add("SelectGem",new Token(Type.selectgem,"SelectGem"));
        Ids.Add("Round",new Token(Type.round,"Round"));
        Ids.Add("CantGem",new Token(Type.cantgem,"CantGem"));
        Ids.Add("SelectCard",new Token(Type.selectcard,"SelectCard"));
        Ids.Add("SelectBCard",new Token(Type.selectbcard,"SelectBCard"));
        Ids.Add("Move",new Token(Type.move,"move"));
        Ids.Add("GiveActions",new Token(Type.giveactions,"GiveActions"));
        Ids.Add("GiveMoney",new Token(Type.givemoney,"GiveMoney"));
        Ids.Add("Draw",new Token(Type.draw,"Draw"));
        Ids.Add("SaveCards",new Token(Type.savecards,"SaveCards"));
        Ids.Add("Trash",new Token(Type.trash,"Trash"));
        Ids.Add("Attack",new Token(Type.attack,"Attack"));
        Ids.Add("GainCard",new Token(Type.gaincard,"GainCard"));
        Ids.Add("Sacrifice",new Token(Type.sacrifice,"Sacrifice"));
        Ids.Add("Revive",new Token(Type.revive,"Revive"));
        Ids.Add("OverTaking",new Token(Type.overtaking,"OverTaking"));
    }
    private bool IsInt()
    {
        return (Current >= 48 && Current <= 57);
    }
    private bool IsLetter()
    {
        return ( ( Current >= 97 && Current <= 122 ) || ( Current >= 65 && Current <= 90 ) );
    }

    private bool IsAlfaNumeric()
    {
        return (IsLetter()|| IsInt());
    }
    private bool IsSpace()
    {
        return Current == ' '||Current == '\n';
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
                Advance();
                return new Token(Type.Comma,",");
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