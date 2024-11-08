namespace ClassLibrary 
/// <summary>
/// La clase <c>CuraTotal</c> es responsable de representar un ítem que cura completamente a un Pokémon.
/// Aplica el principio de responsabilidad única (SRP) al gestionar exclusivamente la lógica de curación completa
/// y eliminación de efectos de estado de un Pokémon. Utiliza el patrón Expert, ya que posee toda la información
/// necesaria para aplicar su efecto al Pokémon. Además, facilita la extensión de la clase para añadir nuevos
/// ítems sin modificar la clase base, alineándose con el principio abierto/cerrado (OCP) y promoviendo una alta cohesión.
/// La robustez y seguridad de esta clase se asegura al evitar estados inválidos y facilitar la detección de errores
/// en el uso de la clase.
{
    public class CuraTotal : Item
    {
        public CuraTotal() : base("Cura total") { }

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
}
