namespace ClassLibrary
{
    public class SuperPocion : Item
    {
        private const int HealingAmount = 70;

        public SuperPocion() : base("Super pocion") { }

        public override string ApplyEffect(Pokemon pokemon)
        {
            if (pokemon == null)
            {
                return "No hay un Pokémon activo para curar.";
            }

            int previousHealth = pokemon.HealthPoints;
            pokemon.HealthPoints += HealingAmount;
            int healthRestored = pokemon.HealthPoints - previousHealth;

            return $"{pokemon.Name} ha recuperado {healthRestored} puntos de vida.";
        }
    }
}