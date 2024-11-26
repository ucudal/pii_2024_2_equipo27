using ClassLibrary;

/// <summary>
/// Implementación de IRandom que genera números constantes. La interfaz `IRandom` y sus
/// implementaciones (`RandomGenerator` y `ConstantGenerator`) siguen el patrón Strategy para definir una estrategia flexible
/// de generación de valores, utilizando Adapter para integrar `System.Random` y respetando el principio DIP
/// al depender de abstracciones, facilitando pruebas y desacoplamiento.
/// </summary>
public class ConstantGenerator : IRandom
{
    private readonly int _constantValue;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ConstantGenerator"/> con un valor constante específico.
    /// </summary>
    /// <param name="value">El valor constante que será generado.</param>
    public ConstantGenerator(int value) 
    {
        _constantValue = value;
    }

    /// <summary>
    /// Genera un número entero constante previamente definido.
    /// </summary>
    /// <returns>El valor constante especificado en la inicialización.</returns>
    public int Generate()
    {
        return _constantValue;
    }
}

