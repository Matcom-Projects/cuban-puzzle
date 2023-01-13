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

### Main() 

Aquí se encuentra nuestro Menú Principal, donde puede dar comienzo a su partida o simplemente salir del juego. 

### **_AddPlayers()_**

Este método devuelve una lista con todos los jugadores que se enfrentarán en la partida. Aquí puede elegir jugar con un jugador virtual que como se mencionó anteriormente, no es tan fácil de vencerle.  

### ChooseCards()

Este método devuelve una lista de `BankCard` con las cartas de acciones escogidas por los jugadores. Aquí se eligen 10 cartas que serán guardadas en el banco y usted podrá comprarlas en su turno. 

### ChooseHeroCards()

Este método devuelve una lista con todos los jugadores que se enfrentarán en la partida, con la especificidad que a cada uno, dentro de este método, se le crea su deck inicial.

### NewGame()

En este método se prepara el escenario necesario para iniciar su partida. Aquí se llaman a los métodos explicados anteriormente: `AddPlayers()`, `ChooseCards()` y `ChooseHeroCards`. Después de ejecutados estos métodos, se ejecuta el método `PlayGame()` de la clase `GameEngine`, que será explicado posteriormente. 

## Engine

## Class Bank

Esta clase contiene en su constructor un `Dictionary<BankCard,int>` `GameBank` donde están guardadas todas las `BankCard` del juego y el parámetro `int` indica la cantidad de cada una de esas cartas en el banco. Además se encuentra `List<BankCard>` `keys` que es una lista de solamente las `BankCard` del juego. En dicho constructor también se añaden las cartas de acciones ecogidas a las instancias `GameBank` y `keys`.

### Get(int index) y Get(BankCard card)

Ambos métodos brindan de `Bank` una carta del tipo que se indica. El primero hace referencia con el parámetro `index` a la posición de una carta de la lista `keys`, mientras que el segundo hace referencia con el parámetro `card` a una carta del diccionario `GameBank`. 

### GetCant(int index,int n) y GetCant(BankCard card,int n)

Estos métodos tienen la misma funcionalidad que los dos anteriores con el único cambio que estos brindan más de una carta de ese tipo.

### Add(BankCard a) y AddCant(List<BankCard> a)

Estos métodos adicionan cartas al banco. El primero agrega una carta de ese tipo al banco, mientras que el segundo agrega más de una carta de ese tipo al banco.
