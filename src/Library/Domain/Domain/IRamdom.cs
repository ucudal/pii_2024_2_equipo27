namespace ClassLibrary;

/// <summary>
/// Define una interfaz para generar números, que puede ser aleatorio o constante.
/// </summary>
public interface IRandom
{
    /// <summary>
    /// Genera un número según la implementación.
    /// </summary>
    /// <returns>Un número generado.</returns>
    int Generate();
}

/// <summary>
/// Implementación de IRandom que genera números aleatorios.
/// </summary>
public class RandomGenerator : IRandom
{
    private static readonly Random _random = new Random();

    public int Generate()
    {
        return _random.Next();
    }
}