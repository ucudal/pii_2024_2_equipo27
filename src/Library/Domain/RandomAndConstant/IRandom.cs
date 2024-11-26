namespace ClassLibrary;

/// <summary>
/// Define una interfaz para generar números, que puede ser aleatorio o constante. La interfaz `IRandom` y sus
/// implementaciones (`RandomGenerator` y `ConstantGenerator`) siguen el patrón Strategy para definir una estrategia flexible
/// de generación de valores, utilizando Adapter para integrar `System.Random` y respetando el principio DIP
/// al depender de abstracciones, facilitando pruebas y desacoplamiento.
/// </summary>
public interface IRandom
{
    /// <summary>
    /// Genera un número según la implementación.
    /// </summary>
    /// <returns>Un número generado.</returns>
    int Generate();
}

