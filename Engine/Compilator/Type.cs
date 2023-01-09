namespace engine_cuban_puzzle;

public enum Type
{
    ACard,ABCard,Int,Boolean,iPlayer,True,False,Void,

    EqualEqual,MinorEqual,GreaterEqual,Greater,Minor,Different,

    LBrace,RBrace,LParen,RParen,

    DOT,Semi,Colon,

    Assign,

    ID,

    Mult,Div,Rest,Sum,

    For,

    If,Else,

    Me,

    deck,hand,discardpile,ongoing,gempile,save,bankcards,gem1,gem2,gem3,gem4,cup,crashgem,doblecrashgem,combine,

    selectplayer,selectcard,selectcardongoing,selectcardhand,selectcarddeck,selectcarddiscardpile,selectcardbank,selectgem,
    round,cantgem,move,giveactions,givemoney,draw,savecards,trash,attack,gaincard,sacrifice,revive,overtaking,

    EOF,
}