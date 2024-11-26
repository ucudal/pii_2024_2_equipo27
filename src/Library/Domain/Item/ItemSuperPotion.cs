namespace ClassLibrary;

/// <summary>
/// La clase <c>ItemSuperPotion</c> hereda de <c>Item</c> y representa un ítem que restaura puntos de vida
/// a un Pokémon, utilizando una cantidad fija de curación.
/// Cumple con el principio de responsabilidad única (SRP) al encargarse exclusivamente de modelar el efecto de curación
/// proporcionado por la super poción. Este diseño facilita su mantenimiento y reutilización.
/// La implementación sobrescribe el método <c>ApplyEffect</c>, utilizando el patrón de diseño Strategy para definir
/// un comportamiento específico para este ítem en comparación con otros. Además, sigue el principio de Sustitución de Liskov (LSP),
/// permitiendo que las subclases puedan ser usadas donde se espere un <c>Item</c> sin romper el comportamiento del sistema.
/// </summary>
public class ItemSuperPotion : Item
{
    /// <summary>
    /// Cantidad de puntos de vida que restaura la super poción.
    /// </summary>
    private const int HealingAmount = 70;

    /// <summary>
    /// Constructor de la clase <c>SuperPocion</c> que inicializa el ítem con el nombre "SuperPocion".
    /// </summary>
    public ItemSuperPotion() : base("SuperPocion")
    {
    }

    /// <summary>
    /// Aplica el efecto de la super poción, aumentando los puntos de vida del Pokémon.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se le aplicará la super poción.</param>
    /// <returns>Un mensaje que indica la cantidad de puntos de vida restaurados.</returns>
    /// <exception cref="Exception">Se lanza una excepción si no se pasa un Pokémon válido.</exception>
    public override string ApplyEffect(Pokemon pokemon)
    {
        if (pokemon == null)
        {
            throw new PokemonException("No hay un pokemon activo para curar");
        }

        int previousHealth = pokemon.HealthPoints;
        pokemon.HealthPoints += HealingAmount;
        int healthRestored = pokemon.HealthPoints - previousHealth;

        return $"{pokemon.Name} ha recuperado {healthRestored} puntos de vida.";
    }
}