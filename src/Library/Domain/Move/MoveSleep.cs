namespace ClassLibrary;

/// <summary>
/// <c>MoveSleep</c> es una subclase de <c>ove</c> que se encarga de infligir daño al Pokémon objetivo y, adicionalmente,
/// inducirlo al sueño. Después de calcular el daño con base en la efectividad del tipo y aplicar el daño
/// correspondiente, establece un número aleatorio de turnos de sueño mediante la propiedad SleepTurns del
/// Pokémon objetivo. Su responsabilidad es la de causar que el Pokémon objetivo duerma por un número determinado
/// de turnos, lo que puede afectar su capacidad para actuar en turnos posteriores. Este comportamiento sigue el
/// principio de responsabilidad única, gestionando exclusivamente el estado de sueño, sin interferir con otros 4
/// efectos de estado o tipos de movimientos.
/// </summary>
public class MoveSleep: Move
{
    /// <summary>
    /// Constructor de la clase <c>MoveSleep</c>. 
    /// </summary>
    /// <param name="name">El nombre del movimiento.</param>
    /// <param name="attackValue">El valor de ataque del movimiento.</param>
    /// <param name="accuracy">El valor de la precisión del movimiento.</param>
    public MoveSleep(string name, int attackValue, double accuracy): base(name, attackValue, accuracy) 
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
        
        //Aplica al pokemon ataque de dormir
        Random random = new Random();
        int sleepTurns = random.Next(1, 5);
        target.SleepTurns = sleepTurns;
    }
}