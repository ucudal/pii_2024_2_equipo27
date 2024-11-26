namespace ClassLibrary;

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