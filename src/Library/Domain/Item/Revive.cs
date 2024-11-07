namespace ClassLibrary
{
    public class Revivir : Item
    {
        private const int ReviveHealth = 50;

        public Revivir() : base("Revivir") { }

        public override string ApplyEffect(Pokemon pokemon)
        {
            if (pokemon == null)
            {
                return "No hay un Pokémon para revivir.";
            }

            if (pokemon.HealthPoints > 0)
            {
                return $"{pokemon.Name} no puede ser revivido.";
            }

            pokemon.HealthPoints = ReviveHealth;
            return $"{pokemon.Name} ha sido revivido con {ReviveHealth} puntos de vida.";
        }
    }
}   