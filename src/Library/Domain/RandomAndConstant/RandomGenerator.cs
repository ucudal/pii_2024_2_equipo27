namespace ClassLibrary;

/// <summary>
/// Implementación de IRandom que genera números aleatorios. La interfaz `IRandom` y sus
/// implementaciones (`RandomGenerator` y `ConstantGenerator`) siguen el patrón Strategy para definir una estrategia flexible
/// de generación de valores, utilizando Adapter para integrar `System.Random` y respetando el principio DIP
/// al depender de abstracciones, facilitando pruebas y desacoplamiento.
/// </summary>
public class RandomGenerator : IRandom
{
    private static readonly Random _random = new Random();

    private readonly int _minRandomValue;
    
    private readonly int _maxRandomValue;


    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="RandomGenerator"/> con un valor random en un rango específico.
    /// </summary>
    /// <param name="value">El valor constante que será generado.</param>
    public RandomGenerator(int minValue, int maxValue)
    {
        _minRandomValue = minValue;
        _maxRandomValue = maxValue;
    }

    protected RandomGenerator()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Genera un número entero en base al numero random previamente definido.
    /// </summary>
    /// <returns>El valor constante especificado en la inicialización.</returns>
    public int Generate()
    {
        return _random.Next(_minRandomValue, _maxRandomValue);
    }
}