namespace ClassLibrary
{
    /// <summary>
    /// La clase <c>NormalMove</c>, hereda de <c>Move</c> y es responsables de implementar su propia
    /// lógica en el método `ExecuteMove`, inflingiendo daño directo al Pokémon objetivo sin efectos secundarios adicionales.
    /// </summary>
    public class MoveNormal: Move
    {
        /// <summary>
        /// Constructor de la clase <c>MoveNormal</c>. 
        /// </summary>
        /// <param name="name">El nombre del movimiento.</param>
        /// <param name="attackValue">El valor de ataque del movimiento.</param>
        /// <param name="accuracy">El valor de la precisión del movimiento.</param>
        public MoveNormal(string name, int attackValue, double accuracy): base(name, attackValue, accuracy) 
        {
            this.Name = name;
            this.AttackValue = attackValue;
            this.Accuracy = accuracy;
        }
        
        /// <summary>
        /// Método para aplicar el ataque considerando ambos pokemones y el valor de golpe crítico.
        /// </summary>
        /// <param name="attacker">El pokemon que está atacando.</param>
        /// <param name="target">El pokemon que está siendo atacado.</param>
        /// <param name="criticalHit">El valor de golpe crítico, que es 1.20 o 1 por default.</param>
        public override void ExecuteMove(Pokemon attacker, Pokemon target, double criticalHit)
        {
            //Verifica que los parámetros sean correctos
            if (attacker == null)
                throw new ArgumentNullException(nameof(attacker), "El atacante no puede ser nulo.");
            if (target == null)
                throw new ArgumentNullException(nameof(target), "El objetivo no puede ser nulo.");
            if (this.AttackValue <= 0)
                throw new InvalidOperationException("El valor de ataque debe ser mayor que cero.");
            
            double typeEffectiveness = PokemonType.GetEffectiveness(attacker.Type, target.Type);
            int calculatedDamage = (int)((this.AttackValue * typeEffectiveness)*(criticalHit));

            target.HealthPoints -= calculatedDamage;
        }
    }
} 