# Cuban-Puzzle

> Proyecto de Programación. Facultad de Matemática y Computación. Universidad de La Habana.
>
> Dario Rodríguez Llosa, C112.
>
> Ricardo Antonio Cápiro Colomar, C112.

## Introducción

Cuban-Puzzle es un juego de estrategia bastante dinámico, donde usted debe idear un buen plan para poder ganar. En este juego por cada turno se envía una gema para la `GemPile` del jugador en cuestión y a la vez que uno de los jugadores tenga 10 gemas en su `GemPile` se acaba el juego. Solo gana el jugador que posea menos gemas en su `GemPile`; en caso de existir más de un jugador con la menor cantidad de gemas, entonces se prosigue el juego hasta que exista UN solo ganador. Su tarea se basa en atacar a sus adversarios para conseguir deshacerse de sus gemas y aumentar las gemas de sus oponentes. Comienza el juego con un pequeño deck de cartas y en cada fase de compra podrá comprar las cartas que desee (siempre que su dinero lo permita), de esa manera irá personalizando su mazo e ideará su estrategia. Cuban-Puzzle tiene varios modos de juego: 2 jugadores, 3 jugadores o 4 jugadores, donde si lo desea puede añadir entre los mismos un jugador virtual que no será tan sencillo de vencerle. 

## ¿Cómo se juega?

Primeramente, entre todos los jugadores eligen las 10 cartas de acciones con las cuales se jugarán en la partida y autoseguido cada jugador eligirá sus tres héroes para su partida. Cada jugador, para comenzar la partida, tendrá en su deck: sus 3 héroes, 6 `Gem1` y 1 `CrashGem`.

Cuban-Puzzle cuenta con 4 fases de juego:

- `Ante Phase`: Como se mencionó anteriormente al empezar su turno se agrega una gema para su `GemPile`.
- `Action Phase`: En esta fase usted debe selecionar una carta de su mano para activar su acción. Cada carta tiene una acción diferente y usted debe eligir cuál es la más apropiada al momento del juego donde se encuentra. Si no posee en su mano ninguna carta de acción (dígase cualquier carta excepto las gemas), entonces debe pasar a la siguiente fase de juego. Usted es libre de eligir si jugar su Fase de Acción o no, Cuban-Puzzle es respetuoso.
- `Buy Phase`: En esta fase usted puede comprar del `Bank` las cartas que desee y automáticamente son enviadas a su `DiscardPile`. El dinero disponible en su Fase de Compra estará dado por las gemas que tiene en su mano y el dinero que brindan las cartas jugadas en la Fase de Acción. Cada carta tiene una propiedad llamada `Money` que indica la cantidad de dinero que brinda en la Fase de Compra. En el caso del `Combine`, le resta $1 en su Fase de Compra. Las gemas de `GemPile` no cuentan como dinero. 
No tiene que gastar todo su dinero en cada turno, pero no obtiene ningún beneficio si no lo hace, pues todo su dinero (gastado o no gastado) irá a su `DiscardPile` al finalizar su turno. Por ejemplo, si tuviera $6 para gastar en su turno, podría comprar cualquier carta que cueste hasta $6 o podría comprar dos cartas que cuesten $3. Incluso podría comprar una carta que cueste $1 y dejar sus otros $5 que quedan sin usar.
Las cartas `Cup` son notables porque son las únicas cartas que cuestan $0. Su función es..., bueno no tienen ninguna, simplemente existen para limitar su estrategia de juego. Con ellas no se puede hacer absolutamente nada. Si posee menos de $1 en su Fase de Compra, se le agregarán tantas cartas `Cup` hasta que su saldo esté en postivo. En ese turno no podrá jugar su Fase de Compra.
- `Clean Up Phase`: En esta fase todas las cartas que se encuentran en el `OnGoing` (campo donde se encuentran las cartas jugadas en la Fase de Acción) y las cartas de su mano pasarán hacia a su `DiscardPile`. Y se renueva su mano con cartas del deck.

## Arquitectura básica del proyecto

El juego está dividido en dos componentes fundamentales:

- `AppConsole` es donde se ejecuta el juego. 
- `Engine` es una biblioteca de clases donde está implementado casi todo el código necesario para nuestro juego. En ella se encuentran varios componentes importantes como son: `Bank`, `Cards`, `Compilator`, `Game`, `Players`, `Interface`.

A continuación se explica con detalle cada uno de ellos.

## AppConsole

## Class Program

Aquí se ejecuta el código necesario para que se observe en la Consola lo que está ocurriendo en nuestro juego. La Consola es nuestra interfaz gráfica, se puede decir que sencilla, pero creemos que eficiente.

### **_Main()_** 

Aquí se encuentra nuestro Menú Principal, donde puede dar comienzo a su partida o simplemente salir del juego. 

### **_AddPlayers()_**

Este método devuelve una lista con todos los jugadores que se enfrentarán en la partida. Aquí puede elegir jugar con un jugador virtual que como se mencionó anteriormente, no es tan fácil de vencerle.  

### **_ChooseCards()_**

Este método devuelve una lista de `BankCard` con las cartas de acciones escogidas por los jugadores. Aquí se eligen 10 cartas que serán guardadas en el banco y usted podrá comprarlas en su turno. 

### **_ChooseHeroCards()_**

En este método se escogen los héroes de cada jugador en la partida. El mismo devuelve una lista con todos los jugadores que se enfrentarán en la partida, con la especificidad que a cada uno, dentro de este método, se le crea su deck inicial.

### **_NewGame()_**

En este método se prepara el escenario necesario para iniciar su partida. Aquí se llaman a los métodos explicados anteriormente: `AddPlayers()`, `ChooseCards()` y `ChooseHeroCards`. Después de ejecutados estos métodos, se ejecuta el método `PlayGame()` de la clase `GameEngine`, que será explicado posteriormente. 

## Engine

## Class Bank

Esta clase contiene en su constructor un `Dictionary<BankCard,int>` `GameBank` donde están guardadas todas las `BankCard` del juego y el parámetro `int` indica la cantidad de cada una de esas cartas en el banco. Además se encuentra `List<BankCard>` `keys` que es una lista de solamente las `BankCard` del juego. En dicho constructor también se añaden las cartas de acciones ecogidas a las instancias `GameBank` y `keys`.

### **_Get(int index) y Get(BankCard card)_**

Ambos métodos brindan de `Bank` una carta del tipo que se indica. El primero hace referencia con el parámetro `index` a la posición de una carta de la lista `keys`, mientras que el segundo hace referencia con el parámetro `card` a una carta del diccionario `GameBank`. 

### **_GetCant(int index,int n) y GetCant(BankCard card,int n)_**

Estos métodos tienen la misma funcionalidad que los dos anteriores con el único cambio que estos brindan más de una carta de ese tipo.

### **_Add() y AddCant()_**

Estos métodos adicionan cartas al banco. El primero agrega una carta de ese tipo al banco, mientras que el segundo agrega más de una carta de ese tipo al banco.

## Cards

En este componente se encuentran todas las cartas imprescindibles del juego encapsuladas como clases.
`Gem1` , `Gem2`, `Gem3` y `Gem4` son los distintos tipos de gemas que funcionan de manera diferente cuando están en su mano y cuando están en su `GemPile`. Las gemas de la mano funcionan como dinero en la Fase de Compra, mientras que las gemas del `GemPile` funcionan como cartas de ataque en la Fase de Acción al activar las cartas `CrashGem` y `DobleCrashGem`.
`CrashGem` es una carta de ataque que envía gemas de su `GemPile` hacia sus oponentes. Atacar con gemas más grande es mucho mejor, pues estas se dividen en `Gem1` y todas ellas son enviadas a la vez. Por ejemplo, si ataca con una `Gem3`, se divide en tres `Gem1` y todas ellas van a la `GemPile` del oponente elegido. Esta carta brinda $1 extra para la Fase de Compra.
`DobleCrashGem` funciona igual que el `CrashGem`, excepto que puedes enviar dos gemas en lugar de una y gana +$2 extra en la Fase de Compra en vez de +$1.
`Combine` combina gemas en su `GemPile` en una sola gema si el total es 4 o menos. Por ejemplo, puede combinar un `Gem1` y un `Gem2` en una `Gem3`. Esta carta disminuye $1 en su Fase de Compra y además brinda una acción más para su Fase de Acción.
`Cup` como fue explicado anteriormente, es una carta inútil que obstruye su deck. Si no puedes comprar una carta en su Fase de Compra entonces se envían tantos `Cup` hasta que su saldo esté en positivo.

## ClassCard

En este componente se encuentra la jerarquía de clases y la estructura de cada una de las cartas.
`Card` es la clase padre de nuestra estructura jerárquica; está implementada de la siguiente manera:

```cs
public abstract class Card
{
   public string Name { get; private set; }
    public string Color { get; private set; }
    public int Money { get; set; }
    public string Information {get; private set;}
    public Card ( string name,string color,int money,string information)
    {
        this.Name = name;
        this.Color = color;
        this.Money = money;
        this.Information = information;
    }
}
```

En el árbol jerárquico le sigue `BankCard`, clase que hereda de `Card`, que identifica a todas las cartas de banco:

```cs
public abstract class BankCard : Card
{
    public int Cost{ get; private set; }
    
    public BankCard ( string name,string color,int money ,int cost,string information): base (name,color,money,information)
    {
        this.Cost = cost;
    }
}
```


Además se encuentran otras clases que engloban conceptos importantes como héroe o cartas de acción, estas son `ActionCard` y `ActionBankCard`:

```cs
public abstract class ActionCard : Card,IActionable
{
    public ActionCard(string name, string color, int money,string information): base( name , color , money ,information){}
    public abstract void Action();
}

public abstract class ActionBankCard : BankCard,IActionable
{
    public ActionBankCard(string name, string color, int money,int cost,string information) : base( name , color , money , cost ,information){}

    public abstract void Action();
}
```

Asimismo, se encuentran otras clases que representan el mismo nivel jerárquico que las `ActionCard` y `ActionBankCard`, estas son `HeroCardByUser` y `ActionCardByUser` que heredan respectivamente de las clases anteriores. Estas clases representan plantillas para las cartas creadas por el usuario:

```cs
public class HeroCardByUser : ActionCard
{
    public HeroCard_Node Node;
    public HeroCardByUser(string name,HeroCard_Node node) : base(name,node.Color,node.Money,node.Information)
    {
        this.Node = node;
    }
    public override void Action()
    {
        Node.Action.Interpret();
    }
}

public class ActionCardByUser : ActionBankCard
{
    public ActionCard_Node Node;
    public ActionCardByUser(string name,ActionCard_Node node) : base(name,node.Color,node.Money,node.Cost,node.Information)
    {
        this.Node = node;
    }
    public override void Action()
    {
        Node.Action.Interpret();
    }
}
```

## Game

En este componente se encuentra el código relacionado a la lógica del juego. Las clases `GameActions`, `GamePrint`, `GameTurn`, `GameUtils` y `GameEngine` llevan a cabo esta tarea.

## Class GameActions

En esta clase están implementadas las acciones del juego en métodos, estan son:

### **_Move()_**

Este método recibe dos listas de `Card` y un `index` y ejecuta la abstracción más interesante del juego. Mueve una carta de una lista a otra, teniendo en cuenta el `index` de la misma, en la lista que le corresponde. Pues sí, así sin más, se pueden ejecutar casi todas las acciones de nuestro juego. 

### **_GiveActions()_**

Brinda más acciones para la Fase de Acción, según la cantidad que recibe `cant` es la cantidad de acciones de más que da.

### **_GiveMoney()_**

Brinda más dinero para la Fase de Compra, según la cantidad que recibe `cant` es la cantidad de dinero que tiene de más para comprar.

### **_Draw()_**

Roba una cantidad `n` de cartas del deck para la mano.

### **_SaveCards()_**

Guarda una carta de la mano para el próximo turno.

### **_Trash()_**

Trashear es un término propio del juego, y significa enviar una carta desde cualquier lugar hacia el banco.

### **_Attack()_**

Este método recibe el jugador el cual va a ser atacado, `Victim`, y envía a su `GemPile` la cantidad de gemas digitadas, `cantgem`.

### **_GainCard()_**

El jugador en cuestión obtiene una carta de banco, y es enviada a su `DiscardPile`.

### **_Sacrifice()_**

Selecciona una carta de su mano y la manda para `DiscardPile`.

### **_OverTaking()_**

Este acción es llamada Adelantar. Selecciona una carta del deck y la envía para la mano.

### **_Revive()_**

Envía una carta de `DiscardPile` hacia la mano.

### **_CombineFunction()_**

Realiza la acción especial del `Combine` pues combina varias gemas en una sola en su `GemPile`.

## Class GamePrint

Esta clase es la encargada de imprimir en pantalla la mayor parte de los asuntos del juego.

### **_PrintTable()_**

Imprime el campo de cada jugador y define el jugador que está realizando su turno.

### **_PrintGemPile()_**

Imprime en pantalla la `GemPile`.

### **_PrintOnGoing()_**

Imprime en pantalla la `OnGoing`.

### **_PrintHand()_**

Imprime en pantalla la `HandCards`, la mano del jugador.

### **_PrintMenu()_**

Imprime en pantalla el menú principal.

### **_Read()_**

Lee una tecla del teclado para realizar una accion determinada.

### **_PrintList()_**

Existen dos métodos con el mismo nombre, pero que reciben diferentes parámetros. Ambos métodos imprimen la lista que reciben en pantalla.

### **_SelectCard()_**

El grupo de métodos con ese nombre, selecciona una carta a partir de una lista recibida.

## Class GameTurns

Esta clase hereda de una interfaz `IEnumerator`, por tanto implementa los métodos de dicha interfaz: `MoveNext()` y `Reset()`, además de la propiedad `Current`.
En su constructor posee una lista de `IPlayer` que representa todos los jugadores, y una propiedad `Index` que representa el inicio del `IEnumerator`, pues al ejecutarse el método `MoveNext()` se pasa hacia el próximo jugador, donde al comenzar el juego ese `Index` se convierte en la posición 0, lo cual está correcto.
La propiedad `Current` expresa el jugador que está realizando su turno en ese momento.
El método `GameRound()` indica la ronda de juego por la que van.
El método `Reset()` retorna al `Index` el valor -1.

## Class GameUtils

Esta clase implementa los métodos auxiliares de la lógica del juego.

### **_MixPlayers()_**

Este método riega el orden en que fueron introducidos los jugadores para evitar todo tipo de favoritismo a la hora de escoger las cartas y el orden de los turnos en la partida.

### **_GetRandom()_**

Obtiene un número random en el intervalo recibido.

### **_InformationCard()_**

Brinda la información de la carta seleccionada.

## Class GameEngine

En esta clase se ejecuta la parte más importante de la lógica del juego y está directamente e indirectamente relacionado con todas las clases del proyecto.
`CantActionsPerTurn` es una propiedad que lleva la cantidad de acciones que se pueden jugar por turno.
`CantMoneyPerTurn` es una propiedad que lleva la cantidad de dinero disponible que tiene el jugador para la Fase de Compra.
`Players` es una lista con los jugadores en cuestión.
`Turns` es una instancia de la clase `GameTurns` para poder referirse a los jugadores.
`bank` es una instancia de la clase `Bank`, para crear el banco que va a tener lugar en la partida.

### **_PlayGame()_**

En este método se desarrolla el juego, se ejecuta la Fase de Acción, la Fase de Compra y la Fase de Limpieza. Devuelve un `IPlayer` con el jugador ganador.

### **_ActionPhase()_**

Se ejecuta la Fase de Acción.

### **_BuyPhase()_**

Se ejecuta la Fase de Compra.

### **_CleanUpPhase()_**

Se ejecuta la Fase de Limpieza.

## Players

En este componente se encuentra todo lo relacionado al jugador, su `Table` y los dos tipos de jugadores el `ManualPlayer` y el `VirtualPlayer`.

## Class TablePlayer

En esta clase están encapsulados los distintos campos del jugador en listas: `Deck`, `DiscardPile`, `OnGoing`, `HandCards`, `GemPile` y `SaveCards`.

### **_CreateDeck()_**

Crea su deck.

### **_DrawDeck()_**

Roba una cantidad de cartas determinada del deck a la mano.

### **_MixDeck()_**

Barajea el deck.

### **_HandToOnGoing()_**

Mueve una carta de la mano al OnGoing.

### **_HandToSaveCards()_**

Guarda una carta de su mano.

### **_DeckToHand()_**

Mueve una carta del deck a su mano.

### **_DiscardPileToHand()_**

Mueve una carta de DisCardPile a la mano.

### **_HandToDiscardPile()_**

Mueve una carta de la mano a DiscardPile.

### **_ToOnGoing()_**

Agrega una carta al OnGoing.

### **_ToDiscardPile()_**

Agrega una o varias cartas a DiscardPile, en dependencia de su parámetro.

### **_ToGemPile()_**

Agrega una o varias cartas a GemPile, en dependencia de su parámetro.

### **_GetGemPile()_**

Brinda una lista de gemas de la GemPile.

### **_CantGem()_**

Proporciona la cantidad de gemas en su GemPile.

### **_CleanUp()_**

Activa los métodos CleanSaveCards(), CleanOnGoing(), CleanHand(), y renueva su mano co una canidad de cartas que depende de las cantidad de gemas en su GemPile.

### **_CleanSaveCards()_**

Limpieza de las SaveCards.

### **_CleanOnGoing()_**

Limpieza del OnGoing.

### **_CleanHand()_**

Limpieza de la mano del jugador.

### **_CantMoneyBuyPhases()_**

Calcula la cantidad de dinero disponible para su Fase de Compra.

## Interfaces

En el juego se utilizaron tres interfaces: `IPlayer` que contiene todos los métodos de los jugadores , la interfaz `IActionable` que contiene un método `Action()` que lo ejecutarán todas las cartas de acciones y la interfaz `AST_Node` que la utilizamos para relacionar de una forma todos los nodos del interprete.

## Lenguaje

En el interprete que hemos creado te da la posibilidad de programar tus propias cartas del juego con cierta libertad y creatividad. Para crear una carta lo unico que tienes que hacer es dirigirse hacia la carpeta `HeroCards` en caso de lo que quiera crear sea una carta heroe (carta que eligen los jugadores al principio del juego para empezar en sus decks) o hacia `ActionCards` en caso de querer crear una carta de banco (carta que de ser elegida por algun jugador aparecera en el banco con opcion de comprarla), debe crear un archivo `.txt` que su nombre sera el nombre de la carta y en su interior debe contener ciertas exigencias Ej: de ser carta heroe obligatoriamente debe rellenar los campos de `Money`, `Color` , `Information` y `Action` , en caso de ser carta de banco debe rellenar los campos antes mencionados y ademas rellenar el campo `Cost` , en caso de q no tenga alguno de estos campos rellenados el juego le retornara una excepcion indicandole cual campo es el de la falla. La forma correcta de rellenar estas propiedades es la siguiente:
```
Money = (un numero) ;
Cost =  (un numero) ;
Information = (informacion sobre que hace la carta) ;
Color= (un color)  ;
Action
{
    (Codigo definido en nuestro interprete)
}
```

Las palabras reservadas de nuestro interprete son :

### **_if else_**
Tenemos condicionales en nuestro interprete que la forma correcta de usarlas son 
```
if ( expresion boolean )
{ 
    (codigo que debe ejecutar en caso de cumplirse la condicion) 
}
else(no obligatoriamente debe ponerla pero siempre que la ponga tiene q venir despues de un if)
{
    (codigo a ejecutar en caso de que no se cumpla)
}
```

### **_For_**
Tenemos un ciclo for al que le debemos pasar una expresion numerica q sera la cantidad de veces que repetira este ciclo:
```
for (expresion numerica)
{
    (codigo a ejecutar en el ciclo)
}
```

### **_true false_**

Son expresiones boolean que como su nombre lo indica `true` es verdadero y `false` falso.

### **_Me_**

Es una expresion q retorna el jugador que esta en turno en ese momento.

### **_Gem1_**

Expresion que retorna la carta de banco `Gem1`

### **_Gem2_**

Expresion que retorna la carta de banco `Gem2`

### **_Gem3_**

Expresion que retorna la carta de banco `Gem3`

### **_Gem4_**

Expresion que retorna la carta de banco `Gem4`

### **_CrashGem_**

Expresion que retorna la carta de banco `CrashGem`

### **_DobleCrashGem_**

Expresion que retorna la carta de banco `DobleCrashGem`

### **_Combine_**

Expresion que retorna la carta de banco `Combine`

### **_Cup_**

Expresion que retorna la carta de banco `Cup`

### **_SelectPlayer_**

Es un metodo que retorna un `Player`, no hay q pasarle ningun parametro por eso no hace falta ponerle () despues de su invocacion

### **_SelectCardOnGoing_**

Es un metodo que retorna una expresion numerica que es el index de la carta seleccionada en el campo `OnGoing` del jugador de turno , no hay q pasarle ningun parametro por eso no hace falta ponerle () despues de su invocacion

### **_SelectCardHand_**

Es un metodo que retorna una expresion numerica que es el index de la carta seleccionada en el campo `Hand` del jugador de turno , no hay q pasarle ningun parametro por eso no hace falta ponerle () despues de su invocacion

### **_SelectCardDeck_**

Es un metodo que retorna una expresion numerica que es el index de la carta seleccionada en el campo `Deck` del jugador de turno , no hay q pasarle ningun parametro por eso no hace falta ponerle () despues de su invocacion

### **_SelectCardDiscardPile_**

Es un metodo que retorna una expresion numerica que es el index de la carta seleccionada en el campo `DiscardPile` del jugador de turno , no hay q pasarle ningun parametro por eso no hace falta ponerle () despues de su invocacion

### **_SelectGem_**

Es un metodo que retorna una expresion numerica que es el index de la carta seleccionada en el campo `GemPile` del jugador de turno , no hay q pasarle ningun parametro por eso no hace falta ponerle () despues de su invocacion

### **_SelectCardBank_**

Es un metodo que retorna una carta de banco del banco del juego , no hay q pasarle ningun parametro por eso no hace falta ponerle () despues de su invocacion

### **_Round_**

Es un metodo que retorna una expresion numerica que es la ronda por la que se encuentra el juego que una ronda se puede definir como un ciclo completo de turnos jugados de todos los jugadore , no hay q pasarle ningun parametro por eso no hace falta ponerle () despues de su invocacion

### **__SelectCard (lista)__**

Es un metodo q recibe una lista de cartas y te retorna el index de una carta seleccionada de esa lista

### **__SelectBCard (lista)__**

Es un metodo q recibe una lista de cartas y te retorna el index de una carta de banco seleccionada de esa lista

### **__Move (lista1 , lista2 , index)__**

Es un metodo q recibe dos lista de cartas y un index y te mueve el index de esa lista1 a la lista2, esta accion esta restringida ya que no puedes realizar este movimiento en la lista de los players `GemPile` por lo tanto si le introduces como lista a esta dara una excepcion

### **__GiveActions (expresion numerica)__**

Es un metodo q recibe una expresion numerica la cual aumentara las acciones del jugador d turno en esta

### **__GiveMoney (expresion numerica)__**

Es un metodo q recibe una expresion numerica la cual aumentara el dinero para la fase de compra del jugador d turno en esta

### **__Draw (expresion numerica)__**

Es un metodo que recibe una expresion numerica la cual hara que el jugador de turno robe de su deck esa cantidad de cartas

### **__SaveCard (index)__**

Es un metodo que recibe un index la cual hara que el jugador de turno salve la carta de su mano correspondiente a ese index y la guarde para el proximo turno

### **__Trash (index, lista)__**

Es un metodo que recibe un index y una lista la cual hace que en caso de q el index en esa lista sea una carta del banco entonces lleva esa carta de vuelta al banco, se recomienda que a la hora de programar esa accion tengan en cuenta que el index que estan llevan es realmente el de una carta de banco porque en caso de que no lo sea van a perder la accion

### **__Attack (Player,Expresion numerica)__**

Este metodo recibe un Player y una expresion numerica, como su nombre lo indica esta accion se basa en atacar a un jugador el cual va a ser el q le pases como Player y le vas a atacar una cantidad de gemas que es la expresion numeica que le estas pasando

### **__GainCard (Player,carta de banco)__**

Este metodo recibe un Player y una carta de banco el cual hace que ese player gane del banco la carta de banco que le paso al metodo 

### **__Sacrifice (Player,index)__**

Este metodo recibe un Player y un index el cual hace que ese player lleve la carta de su `Hand` que ocupa el lugar del index a la `DiscardPile`

### **__Revive (Player,index)__**

Este metodo recibe un Player y un index el cual hace que ese player lleve la carta de su `DiscardPile` que ocupa el lugar del index a la `Hand`

### **__OverTaking (Player,index)__**

Este metodo recibe un Player y un index el cual hace que ese player lleve la carta de su `Deck` que ocupa el lugar del index a la `Hand`

### **__Como asignar variables ?__**

Para asignar variables es bien sencillo solo basta con poner el nombre de la variable seguido el simbolo de `=` y despues la expresion que le quiere asignar a esa variable y por ultimo el `;` , seria algo asi:
```
nombre = ( Expresion ( numerica || boolean || players ||  carta de banco ) ) ;
```
Importante: a las variables no se le pueden asginar listas

### **__Como acceder a las listas del juego ?__**

Bueno primeramente debe conocer cuales son las listas del juego y son las siguientes:
```
DeckList : lista donde se encuentran las cartas antes de llevarlas a la HandList

HandList : lista donde se encuentran las cartas que tiene el jugador para jugar en su turno

OnGoingList : lista donde se encuentran las cartas que el jugador ha jugado en su turno

DiscardPileList : lista donde se encuentran las cartas que el jugador ya ha utilizado o no en sus turnos anteriores y ademas las que ha comprado (estas cartas pasan a ser parte del DekcList cuando al Deck no le queden cartas)

GemPileList : aqui se encuentran las gemas de la GemPile del jugador
```

Ya conocemos como indetificar los campos `Deck` , `Hand` , `OnGoing` , `DiscardPile` y `GemPile` en nuestro lenguaje pero si los invocamos por si solos no tiene sentido porque por ejemplo pongo HandList sabemos q es la lista de cartas que tiene un jugador en su `Hand` pero especificamente de cual jugador ? Por esto principalmente para poder acceder a las listas de los jugadores de su tablero debemos hacerlo de la siguiente forma:
(Player||variable Player||metodo que retorne un Player)`.`(lista) asi llamariamos a la lista de ese jugador en el respectivo campo. Ejemplo:
```
player = SelectPlayer ;
indexcard = SelectCard(player.HandList) ;
Move ( player.HandList , Me.HandList , indexcard ) ;
```
Esto lo pone dentro del Action en el .txt de una carta y lo que haria fuera mover una carta de la mano de otro jugador a la mano del jugador que esta en turno, igual funcionaria si no crearas las variables y pusieras los metodos en el lugar de las variables en el metodo `Move`



