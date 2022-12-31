namespace engine_cuban_puzzle;

public class Errors
{
    public static void Structure()
    {
        System.Console.WriteLine("Error: La estructura de creacion de la carta no es correcta");
        Interperter.ExistError = true;
    }
    public static void Format()
    {
        System.Console.WriteLine("Error: El valor de sus propiedades no es correcto");
        Interperter.ExistError = true;
    }
    public static void InvalidExpression()
    {
        System.Console.WriteLine("Error: El valor de la expresion NO es valido");
        Interperter.ExistError = true;
    }
    public static void Field()
    {
        System.Console.WriteLine("Error: El nombre del campo iniciado NO es valido");
        Interperter.ExistError = true;
    }
    public static void PropertiesCards()
    {
        System.Console.WriteLine("Error: La propiedad de la carta NO es correcta");
        Interperter.ExistError = true;
    }
    public static void Range(int min, int max)
    {
        System.Console.WriteLine($"Error: El rango de la propiedad es [{min},{max}]");
        Interperter.ExistError = true;
    }
}
