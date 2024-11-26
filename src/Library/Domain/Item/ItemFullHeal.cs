namespace ClassLibrary;

/// <summary>
/// La clase <c>ItemFullHeal</c> hereda de <c>Item</c> y representa un ítem que cura completamente a un Pokémon,
/// restaurando sus puntos de salud y eliminando cualquier estado alterado.
/// Cumple con el principio de responsabilidad única (SRP), ya que su única función es manejar la lógica relacionada
/// con la curación total de un Pokémon.
/// La implementación del método <c>ApplyEffect</c> utiliza el patrón de diseño Strategy, permitiendo la personalización
/// del comportamiento del ítem sin afectar otras partes del sistema. También sigue el principio de Sustitución de Liskov (LSP),
/// ya que sobrescribe el comportamiento de la clase base <c>Item</c> respetando su contrato.
/// </summary>
public class ItemFullHeal : Item
{
    /// <summary>
    /// Constructor de la clase <c>CompleteCure</c> que inicializa el ítem con el nombre "Cura total".
    /// </summary>
    public ItemFullHeal() : base("Cura total")
    {
    }

    /// <summary>
    /// Aplica el efecto de curación completa y eliminación de estados alterados a un Pokémon.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se le aplicará la cura completa.</param>
    /// <returns>Un mensaje que indica que el Pokémon ha sido curado completamente.</returns>
    /// <exception cref="Exception">Se lanza una excepción si no se pasa un Pokémon válido.</exception>
    public override string ApplyEffect(Pokemon pokemon)
    {
        if (pokemon == null)
        {
            throw new Exception("No hay un Pokémon activo para curar.");
        }

        pokemon.HealthPoints = 100;
        pokemon.IsPoisoned = false;
        pokemon.IsBurned = false;
        pokemon.SleepTurns = 0;
        pokemon.IsParalyzed = false;
        return $"{pokemon.Name} ha sido curado completamente.";
    }
}