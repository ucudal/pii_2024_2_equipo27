namespace ClassLibrary;

/// <summary>
/// La clase <c>ItemRevive</c> hereda de <c>Item</c> y representa un ítem que revive a un Pokémon debilitado,
/// restaurándole una cantidad limitada de puntos de vida.
/// Cumple con el principio de responsabilidad única (SRP) ya que su única tarea es manejar la lógica específica
/// de revivir un Pokémon. Este diseño encapsula esta funcionalidad de manera clara y separada.
/// La implementación del método <c>ApplyEffect</c> utiliza el patrón de diseño Strategy para definir un comportamiento
/// personalizado en comparación con otros ítems. Además, sigue el principio de Sustitución de Liskov (LSP),
/// sobrescribiendo el método de la clase base <c>Item</c> respetando su contrato.
/// </summary>
public class ItemRevive : Item
{
    private const int ReviveHealth = 50;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ItemRevive"/> con el nombre del ítem establecido como "Revivir".
    /// </summary>
    public ItemRevive() : base("Revivir")
    {
    }

    /// <summary>
    /// Aplica el efecto de la <c>ItemRevive</c> al Pokémon especificado. Si el Pokémon está debilitado (con puntos de vida iguales a cero),
    /// lo revive restaurando 50 puntos de vida. Si el Pokémon ya tiene puntos de vida, no se puede aplicar el efecto.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se le aplicará el ítem.</param>
    /// <returns>Un mensaje indicando el resultado de la aplicación del ítem.</returns>
    public override string ApplyEffect(Pokemon pokemon)
    {
        if (pokemon == null)
        {
            throw new ArgumentNullException(nameof(pokemon), "No hay un Pokémon para revivir.");
        }

        if (pokemon.HealthPoints > 0)
        {
            throw new PokemonException($"{pokemon.Name} no puede ser revivido porque ya tiene puntos de vida.");
        }

        pokemon.HealthPoints = ReviveHealth;
        return $"{pokemon.Name} ha sido revivido con {ReviveHealth} puntos de vida.";
    }
}