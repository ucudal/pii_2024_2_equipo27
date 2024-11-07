namespace ClassLibrary
{
    public class CuraTotal : Item
    {
        public CuraTotal() : base("Cura total") { }

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