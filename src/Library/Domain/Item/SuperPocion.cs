namespace ClassLibrary
{
    /// <summary>
    /// La clase <c>SuperPocion</c> representa un ítem que restaura puntos de vida a un Pokémon en batalla.
    /// Aplica el principio de responsabilidad única (SRP) al encargarse exclusivamente de la lógica de curación
    /// parcial de un Pokémon. Utiliza el patrón Expert, ya que posee toda la información necesaria para aplicar
    /// su efecto al Pokémon. La clase también está diseñada para cumplir con el principio abierto/cerrado (OCP),
    /// facilitando la extensión mediante la adición de otros ítems sin necesidad de modificar la clase base.
    /// </summary>
    public class SuperPocion : Item
    {
        private const int HealingAmount = 70;

        public SuperPocion() : base("SuperPocion") { }

        public override string ApplyEffect(Pokemon pokemon)
        {
            if (pokemon == null)
            {
                throw new ("No hay un pokemon activo para curar");
            }

            int previousHealth = pokemon.HealthPoints;
            pokemon.HealthPoints += HealingAmount;
            int healthRestored = pokemon.HealthPoints - previousHealth;

            return $"{pokemon.Name} ha recuperado {healthRestored} puntos de vida.";
        }
    }
}