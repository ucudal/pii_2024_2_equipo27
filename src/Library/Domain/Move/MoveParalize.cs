namespace ClassLibrary;

/// <summary>
/// <c>MoveParalize</c> es una subclase de <c>Move</c> encargada de implementar el movimiento que causa
/// parálisis en el Pokémon objetivo. Su responsabilidad principal es aplicar daño según la
/// lógica de efectividad de tipos y, adicionalmente, verificar si el objetivo no está ya
/// paralizado; si no lo está, establece su estado de parálisis en verdadero.
/// </summary>
public class MoveParalize: Move
{
    //// <summary>
    /// Constructor de la clase <c>MoveParalize</c>. 
    /// </summary>
    /// <param name="name">El nombre del movimiento.</param>
    /// <param name="attackValue">El valor de ataque del movimiento.</param>
    /// <param name="accuracy">El valor de la precisión del movimiento.</param>
    public MoveParalize(string name, int attackValue, double accuracy): base(name, attackValue, accuracy) 
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
        
        //Aplica el ataque común
        if (this.AttackValue > 0)
        {
            double typeEffectiveness = PokemonType.GetEffectiveness(attacker.Type, target.Type);
            int calculatedDamage = (int)((this.AttackValue * typeEffectiveness)*(criticalHit));
            target.HealthPoints -= calculatedDamage;
        }

        //Aplica al pokemon ataque de paralizar
        if (!target.IsParalyzed)
        {
            target.IsParalyzed = true;
        }
    }
}