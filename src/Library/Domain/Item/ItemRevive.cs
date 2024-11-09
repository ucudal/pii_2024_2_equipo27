namespace ClassLibrary
{
    /// <summary>
    /// La clase <c>Revivir</c> representa un ítem que revive a un Pokémon debilitado, restaurando parcialmente sus puntos de vida.
    /// Aplica el principio de responsabilidad única (SRP) al gestionar exclusivamente la lógica de revivir y curación parcial
    /// para Pokémon debilitados. Utiliza el patrón Expert, ya que posee toda la información necesaria para aplicar su efecto
    /// al Pokémon. Además, facilita la extensión de la clase para añadir nuevos ítems sin modificar la clase base,
    /// alineándose con el principio abierto/cerrado (OCP) y promoviendo una alta cohesión. La clase asegura la robustez y
    /// seguridad de su comportamiento al prevenir estados inválidos y facilitar la detección de errores en su uso.
    /// </summary>
    public class Revivir : Item
    {
        private const int ReviveHealth = 50;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Revivir"/> con el nombre del ítem establecido como "Revivir".
        /// </summary>
        public Revivir() : base("Revivir") { }

        /// <summary>
        /// Aplica el efecto de la <c>Revivir</c> al Pokémon especificado. Si el Pokémon está debilitado (con puntos de vida iguales a cero),
        /// lo revive restaurando 50 puntos de vida. Si el Pokémon ya tiene puntos de vida, no se puede aplicar el efecto.
        /// </summary>
        /// <param name="pokemon">El Pokémon al que se le aplicará el ítem.</param>
        /// <returns>Un mensaje indicando el resultado de la aplicación del ítem.</returns>
        public override string ApplyEffect(Pokemon pokemon)
        {
            if (pokemon == null)
            {
                throw new Exception("No hay un Pokémon para revivir.");
            }

            if (pokemon.HealthPoints > 0)
            {
                throw new Exception($"{pokemon.Name} no puede ser revivido.");
            }

            pokemon.HealthPoints = ReviveHealth;
            return $"{pokemon.Name} ha sido revivido con {ReviveHealth} puntos de vida.";
        }
    }
}
