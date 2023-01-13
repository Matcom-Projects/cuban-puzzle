namespace engine_cuban_puzzle;

public class Interpreter
{
    public Parse Parser;
    public Compound_Node PrincipalNode;
    public Dictionary<string,Expression_Node> Global_Scope;

    public Interpreter(Parse parser)
    {
        this.Parser = parser;
        this.PrincipalNode = Parser.Parsing();
        this.Global_Scope = new Dictionary<string,Expression_Node>();
    }

    public void Interpret()
    {
        Visit_Compound(PrincipalNode);
    }

    public void Visit_Compound(Compound_Node node)
    {
        foreach(AST_Node child in node.Children )
        {
            if ( child is ASSIGN_Node ) Visit_Assignment((ASSIGN_Node) child);
            else if ( child is For_Node ) Visit_For((For_Node) child);
            else if ( child is Conditional_Node ) Visit_Conditional((Conditional_Node) child);
            else if ( child is Function_Node ) Visit_VoidFunction((Function_Node) child);
            else if (child is NoOp_Node) continue;
            else throw new Exception("algo va mal con la ejecucion de esta carta");
        }
    }

    public void Visit_Assignment(ASSIGN_Node node)
    {
        if(node.Variable.Type == Type.Int)
        {
            if(Global_Scope.ContainsKey(node.Variable.Value))
            {
                Global_Scope[node.Variable.Value]=new Expression_Node(Type.Int,new Num_Node(Visit_NumericExpression(node.Value)));
            }
            else Global_Scope.Add(node.Variable.Value,new Expression_Node(Type.Int,new Num_Node(Visit_NumericExpression(node.Value))));
        }
        else if (node.Variable.Type == Type.Boolean)
        {
            if(Global_Scope.ContainsKey(node.Variable.Value))
            {
                Global_Scope[node.Variable.Value]=new Expression_Node(Type.Boolean,new Bool_Node(Visit_BooleanExpression(node.Value)));
            }
            else Global_Scope.Add(node.Variable.Value,new Expression_Node(Type.Boolean,new Bool_Node(Visit_BooleanExpression(node.Value))));
        }
        else if (node.Variable.Type == Type.iPlayer)
        {
            if(Global_Scope.ContainsKey(node.Variable.Value))
            {
                Global_Scope[node.Variable.Value]=new Expression_Node(Type.iPlayer,new Player_Node(Visit_IPlayerExpression(node.Value)));
            }
            else Global_Scope.Add(node.Variable.Value,new Expression_Node(Type.iPlayer,new Player_Node(Visit_IPlayerExpression(node.Value))));
        }
        else if (node.Variable.Type == Type.BCard)
        {
            if(Global_Scope.ContainsKey(node.Variable.Value))
            {
                Global_Scope[node.Variable.Value]=new Expression_Node(Type.BCard,new BankCard_Node(Visit_BankCardExpression(node.Value)));
            }
            else Global_Scope.Add(node.Variable.Value,new Expression_Node(Type.BCard,new BankCard_Node(Visit_BankCardExpression(node.Value))));
        }
        else throw new Exception("asignaste algo q no es valido");
    }

    public void Visit_For(For_Node node)
    {
        int n = Visit_NumericExpression(node.Times);

        for(int i = 0; i < n; i++ )
        {
            Visit_Compound(node.Execute);
        }
    }

    public void Visit_Conditional(Conditional_Node node)
    {
        bool condition = Visit_BooleanExpression(node.Condition);

        if(condition)
        {
            Visit_Compound(node.WhenTrue);
        }
        else
        {
            Visit_Compound(node.WhenFalse);
        }
    }

    public void Visit_VoidFunction(Function_Node node)
    {
        if (node.Function == Type.move)
        {
            List<Card> a = Visit_ListExpression(node.Pass[0]);
            List<Card> b = Visit_ListExpression(node.Pass[1]);
            int index = Visit_NumericExpression(node.Pass[2]);

            GameActions.Move(a,b,index);
        }
        else if(node.Function == Type.giveactions)
        {
            int cantactions = Visit_NumericExpression(node.Pass[0]);
            GameActions.GiveActions(cantactions);
        }
        else if(node.Function == Type.givemoney)
        {
            int cantamoney = Visit_NumericExpression(node.Pass[0]);
            GameActions.GiveMoney(cantamoney);
        }
        else if(node.Function == Type.draw)
        {
            int cantdraw = Visit_NumericExpression(node.Pass[0]);
            GameActions.Draw(cantdraw);
        }
        else if(node.Function == Type.savecards)
        {
            int index = Visit_NumericExpression(node.Pass[0]);
            GameActions.SaveCards(index);
        }
        else if(node.Function == Type.trash)
        {
            int index = Visit_NumericExpression(node.Pass[0]);
            List<Card> a = Visit_ListExpression(node.Pass[1]);
            GameActions.Trash(index,a);
        }
        else if(node.Function == Type.attack)
        {
            IPlayer player = Visit_IPlayerExpression(node.Pass[0]);
            int cantgem = Visit_NumericExpression(node.Pass[1]);
            GameActions.Attack(player,cantgem);
        }
        else if(node.Function == Type.gaincard)
        {
            IPlayer player = Visit_IPlayerExpression(node.Pass[0]);
            BankCard card = Visit_BankCardExpression(node.Pass[1]);
            GameActions.GainCard(player,card);
        }
        else if(node.Function == Type.sacrifice)
        {
            IPlayer player = Visit_IPlayerExpression(node.Pass[0]);
            int index = Visit_NumericExpression(node.Pass[1]);
            GameActions.Sacrifice(player,index);
        }
        else if(node.Function == Type.revive)
        {
            IPlayer player = Visit_IPlayerExpression(node.Pass[0]);
            int index = Visit_NumericExpression(node.Pass[1]);
            GameActions.Revive(player,index);
        }
        else if(node.Function == Type.overtaking)
        {
            IPlayer player = Visit_IPlayerExpression(node.Pass[0]);
            int index = Visit_NumericExpression(node.Pass[1]);
            GameActions.OverTaking(player,index);
        }
        else throw new Exception("aqui deberia haber una funcion void");
    }

    public int Visit_NumericExpression(Expression_Node node)
    {
        if(node.Expression is Num_Node) return ((Num_Node)node.Expression).Value;
        else if (node.Expression is Function_Node)
        {
            Function_Node function = (Function_Node)node.Expression;

            if(function.Function == Type.selectcardongoing)
            {
                return GameEngine.Turns.Current.SelectCardOnGoing();
            }
            if(function.Function == Type.selectcardhand)
            {
                return GameEngine.Turns.Current.SelectCardHand();
            }
            if(function.Function == Type.selectcarddeck)
            {
                return GameEngine.Turns.Current.SelectCardDeck();
            }
            if(function.Function == Type.selectcarddiscardpile)
            {
                return GameEngine.Turns.Current.SelectCardDiscardPile();
            }
            if(function.Function == Type.selectgem)
            {
                return GameEngine.Turns.Current.SelectGem();
            }
            if(function.Function == Type.round)
            {
                return GameEngine.Turns.GameRound();
            }
            if(function.Function == Type.selectbcard)
            {
                return GameEngine.Turns.Current.SelectBCard(Visit_ListExpression(function.Pass[0]));
            }
            if(function.Function == Type.selectcard)
            {
                return GameEngine.Turns.Current.SelectCard(Visit_ListExpression(function.Pass[0]));
            }
        }
        else if (node.Expression is DotReference_Node)
        {
            IPlayer player = Visit_IPlayerExpression(((DotReference_Node)node.Expression).User);
            DotReference_Node auxnode = (DotReference_Node)node.Expression;

            if(auxnode.Reference.Expression is Function_Node )
            {
                if(((Function_Node)auxnode.Reference.Expression).Function == Type.cantgem)
                {
                    return player.Table.CantGem();
                }
            }
        }
        else if (node.Expression is Var_Node)
        {
            return Visit_NumericExpression(Global_Scope[((Var_Node)node.Expression).Value]);
        }
        else if (node.Expression is BinaryOperation_Node)
        {
            BinaryOperation_Node auxnode = (BinaryOperation_Node)node.Expression;

            if(auxnode.Operation == Type.Sum)
            {
                return Visit_NumericExpression(auxnode.Left) + Visit_NumericExpression(auxnode.Right);
            }
            else if(auxnode.Operation == Type.Rest)
            {
                return Visit_NumericExpression(auxnode.Left) - Visit_NumericExpression(auxnode.Right);
            }
            else if(auxnode.Operation == Type.Mult)
            {
                return Visit_NumericExpression(auxnode.Left) * Visit_NumericExpression(auxnode.Right);
            }
            else if(auxnode.Operation == Type.Div)
            {
                return Visit_NumericExpression(auxnode.Left) / Visit_NumericExpression(auxnode.Right);
            }
        }
        else if (node.Expression is UnaryOperation_Node)
        {
            UnaryOperation_Node auxnode = (UnaryOperation_Node)node.Expression;

            if(auxnode.Operation.Type == Type.Sum)
            {
                return +Visit_NumericExpression(auxnode.Node);
            }
            else if(auxnode.Operation.Type == Type.Rest)
            {
                return -Visit_NumericExpression(auxnode.Node);
            }
        }
        throw new Exception("se esperaba una expresion numerica aqui");
    }

    public bool Visit_BooleanExpression(Expression_Node node)
    {
        if(node.Expression is Bool_Node) return ((Bool_Node)node.Expression).Value;
        else if (node.Expression is Var_Node)
        {
            return Visit_BooleanExpression(Global_Scope[((Var_Node)node.Expression).Value]);
        }
        else if(node.Expression is BinaryOperation_Node)
        {
            BinaryOperation_Node auxnode = (BinaryOperation_Node)node.Expression;

            if(auxnode.Operation == Type.And)
            {
                return ( Visit_BooleanExpression(auxnode.Left) && Visit_BooleanExpression(auxnode.Right) );
            }
            if(auxnode.Operation == Type.Or)
            {
                return ( Visit_BooleanExpression(auxnode.Left) || Visit_BooleanExpression(auxnode.Right) );
            }
            if(auxnode.Operation == Type.GreaterEqual)
            {
                return ( Visit_NumericExpression(auxnode.Left) >= Visit_NumericExpression(auxnode.Right) );
            }
            if(auxnode.Operation == Type.MinorEqual)
            {
                return ( Visit_NumericExpression(auxnode.Left) <= Visit_NumericExpression(auxnode.Right) );
            }
            if(auxnode.Operation == Type.Greater)
            {
                return ( Visit_NumericExpression(auxnode.Left) > Visit_NumericExpression(auxnode.Right) );
            }
            if(auxnode.Operation == Type.Minor)
            {
                return ( Visit_NumericExpression(auxnode.Left) < Visit_NumericExpression(auxnode.Right) );
            }
            if(auxnode.Operation == Type.EqualEqual)
            {
                Type typeresult = auxnode.Left.TypeReturn;
                if(typeresult == Type.Int)
                {
                    return (Visit_NumericExpression(auxnode.Left) == Visit_NumericExpression(auxnode.Right));
                }
                if(typeresult == Type.Boolean)
                {
                    return (Visit_BooleanExpression(auxnode.Left) == Visit_BooleanExpression(auxnode.Right));
                }
                if(typeresult == Type.iPlayer)
                {
                    return (Visit_IPlayerExpression(auxnode.Left) == Visit_IPlayerExpression(auxnode.Right));
                }
                if(typeresult == Type.BCard)
                {
                    return (Visit_BankCardExpression(auxnode.Left) == Visit_BankCardExpression(auxnode.Right));
                }
                if(typeresult == Type.list)
                {
                    return (Visit_ListExpression(auxnode.Left) == Visit_ListExpression(auxnode.Right));
                }
            }
            if(auxnode.Operation == Type.Different)
            {
                Type typeresult = auxnode.Left.TypeReturn;
                if(typeresult == Type.Int)
                {
                    return (Visit_NumericExpression(auxnode.Left) != Visit_NumericExpression(auxnode.Right));
                }
                if(typeresult == Type.Boolean)
                {
                    return (Visit_BooleanExpression(auxnode.Left) != Visit_BooleanExpression(auxnode.Right));
                }
                if(typeresult == Type.iPlayer)
                {
                    return (Visit_IPlayerExpression(auxnode.Left) != Visit_IPlayerExpression(auxnode.Right));
                }
                if(typeresult == Type.BCard)
                {
                    return (Visit_BankCardExpression(auxnode.Left) != Visit_BankCardExpression(auxnode.Right));
                }
                if(typeresult == Type.list)
                {
                    return (Visit_ListExpression(auxnode.Left) != Visit_ListExpression(auxnode.Right));
                }
            }
        }
        throw new Exception("aqui deberia haber una expresion boolean");
    }

    public IPlayer Visit_IPlayerExpression(Expression_Node node)
    {
        if(node.Expression is Player_Node) return ((Player_Node)node.Expression).Player;
        else if (node.Expression is Var_Node)
        {
            foreach (string a in Global_Scope.Keys)
            {
                System.Console.WriteLine(a);
            }
            System.Console.WriteLine(((Var_Node)node.Expression).Value);
            return Visit_IPlayerExpression(Global_Scope[((Var_Node)node.Expression).Value]);
        }
        else if (node.Expression is Function_Node)
        {
            if(((Function_Node)node.Expression).Function == Type.selectplayer)
            {
                return GameEngine.Turns.Current.SelectPlayer();
            }
            if(((Function_Node)node.Expression).Function == Type.Me)
            {
                return GameEngine.Turns.Current;
            }
        }
        throw new Exception("aqui deberia haber una expresion IPlayer");
    }

    public BankCard Visit_BankCardExpression(Expression_Node node)
    {
        if(node.Expression is BankCard_Node) return ((BankCard_Node)node.Expression).Card;
        else if (node.Expression is Var_Node)
        {
            return Visit_BankCardExpression(Global_Scope[((Var_Node)node.Expression).Value]);
        }
        else if (node.Expression is Function_Node)
        {
            if(((Function_Node)node.Expression).Function == Type.selectcardbank)
            {
                return GameEngine.Turns.Current.SelectCardBank();
            }
            if(((Function_Node)node.Expression).Function == Type.gem1)
            {
                return GameEngine.bank.keys[0];
            }
            if(((Function_Node)node.Expression).Function == Type.gem2)
            {
                return GameEngine.bank.keys[1];
            }
            if(((Function_Node)node.Expression).Function == Type.gem3)
            {
                return GameEngine.bank.keys[2];
            }
            if(((Function_Node)node.Expression).Function == Type.gem4)
            {
                return GameEngine.bank.keys[3];
            }
            if(((Function_Node)node.Expression).Function == Type.crashgem)
            {
                return GameEngine.bank.keys[4];
            }
            if(((Function_Node)node.Expression).Function == Type.doblecrashgem)
            {
                return GameEngine.bank.keys[5];
            }
            if(((Function_Node)node.Expression).Function == Type.combine)
            {
                return GameEngine.bank.keys[6];
            }
            if(((Function_Node)node.Expression).Function == Type.cup)
            {
                return GameEngine.bank.keys[7];
            }
        }
        throw new Exception("aqui deberia haber una expresion BankCard");
    }

    public List<Card> Visit_ListExpression(Expression_Node node)
    {
        if (node.Expression is DotReference_Node)
        {
            DotReference_Node auxnode = (DotReference_Node)node.Expression;
            if(auxnode.Reference.Expression is List_Node)
            {
                List_Node list = (List_Node)auxnode.Reference.Expression;
                
                if(list.List == Type.deck)
                {
                    return Visit_IPlayerExpression(auxnode.User).Table.Deck;
                }
                if(list.List == Type.hand)
                {
                    return Visit_IPlayerExpression(auxnode.User).Table.HandCards;
                }
                if(list.List == Type.discardpile)
                {
                    return Visit_IPlayerExpression(auxnode.User).Table.DiscardPile;
                }
                if(list.List == Type.ongoing)
                {
                    return Visit_IPlayerExpression(auxnode.User).Table.OnGoing;
                }
                if(list.List == Type.gempile)
                {
                    return Visit_IPlayerExpression(auxnode.User).Table.GemPile;
                }
            }
        }
        throw new Exception("aqui deberia haber una expresion list");
    }
}