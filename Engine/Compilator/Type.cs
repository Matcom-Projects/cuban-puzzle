namespace engine_cuban_puzzle;

public enum Type
{
    Int,Boolean,BCard,iPlayer,True,False,Void,Var,list,//types

    EqualEqual,MinorEqual,GreaterEqual,Greater,Minor,Different,// == | <= | >= | > | < | !=

    LBrace,RBrace,LParen,RParen,LBracket,RBracket,//{}()[]

    DOT,Semi,Comma,//.;,

    Assign, //=

    ID, // nombre da las variable

    Mult,Div,Rest,Sum, //operaciones 

    For, //ciclo

    If,Else,//condicionales

    Me, //player de turno

    deck,hand,discardpile,ongoing,gempile, //listas

    gem1,gem2,gem3,gem4,cup,crashgem,doblecrashgem,combine,//basic bankcard

    selectplayer,selectcard,selectcardongoing,selectcardhand,selectcarddeck,selectcarddiscardpile,selectcardbank,selectgem,
    round,cantgem,move,giveactions,givemoney,draw,savecards,trash,attack,gaincard,sacrifice,revive,overtaking,getrandomplayer,
    getrandomcard,selectbcard, // metodos

    EOF,//fin
}