namespace ClassLibrary
{
    /// <summary>
    /// La clase <c>NormalMove</c> tiene la responsabilidad de almacenar y gestionar los valores de ataque, su nombre, y método de ejecución de un movimiento común.
    /// Esto sigue el principio de responsabilidad única (SRP) ya que su única función es representar los atributos de un movimiento en el juego.
    /// </summary>
    public class MoveNormal: Move
    {
        public MoveNormal(string name, int attackValue, double accuracy): base(name, attackValue, accuracy) 
        {
            this.Name = name;
            this.AttackValue = attackValue;
        }
        
        /// <summary>
        /// Método para aplicar el ataque considerando ambos pokemones.
        /// </summary>
        /// <param name="attacker">El pokemon que está atacando.</param>
        /// <param name="target">El pokemon que está siendo atacado.</param>
        ///
        public override void ExecuteMove(Pokemon attacker, Pokemon target, double criticalHit)
        {
            double typeEffectiveness = PokemonType.GetEffectiveness(attacker.Type, target.Type);
            int calculatedDamage = (int)((this.AttackValue * typeEffectiveness)*(criticalHit));

            target.HealthPoints -= calculatedDamage;
        }
    }
} 