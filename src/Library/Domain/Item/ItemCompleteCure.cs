namespace ClassLibrary
{
    public class ItemCompleteCure : Item
    {
        public ItemCompleteCure() : base("Cura total") { }

        public override string ApplyEffect(Pokemon pokemon)
        {
            if (pokemon == null)
            {
                return "No hay un Pokémon activo para curar.";
            }

            pokemon.HealthPoints = 100; 
            return $"{pokemon.Name} ha sido curado completamente.";
        }
    }
}