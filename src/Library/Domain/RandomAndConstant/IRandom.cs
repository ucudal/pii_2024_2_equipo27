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