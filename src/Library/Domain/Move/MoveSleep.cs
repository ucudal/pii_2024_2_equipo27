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
public class MoveSleep : Move
{
    /// <summary>
    /// Constructor de la clase <c>MoveSleep</c>. 
    /// </summary>
    /// <param name="name">El nombre del movimiento.</param>
    /// <param name="attackValue">El valor de ataque del movimiento.</param>
    /// <param name="accuracy">El valor de la precisión del movimiento.</param>
    public MoveSleep(string name, int attackValue, double accuracy, Type moveType) : base(name, attackValue, accuracy,
        moveType)
    {
        //Intencionalmente vacío
    }

    /// <summary>
    /// Ejecuta un movimiento de ataque de un Pokémon a otro, infligiendo daño y aplicando efectos secundarios.
    /// </summary>
    /// <param name="attacker">El Pokémon que realiza el ataque.</param>
    /// <param name="target">El Pokémon que recibe el ataque.</param>
    /// <param name="criticalHit">
    /// Factor de golpe crítico aplicado al daño base. Usualmente es 1.20 para golpes críticos o 1 por defecto.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Se lanza si <paramref name="attacker"/> o <paramref name="target"/> es nulo.
    /// </exception>
    /// <exception cref="PokemonException">
    /// Se lanza si el valor de ataque del movimiento (<see cref="AttackValue"/>) es menor o igual a cero.
    /// </exception>
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
            double typeEffectiveness = EffectivenessTable.GetEffectiveness(this.MoveType, target.PokemonType);
            int calculatedDamage = (int)((this.AttackValue * typeEffectiveness) * (criticalHit));
            target.HealthPoints -= calculatedDamage;
        }

        //Aplica al pokemon ataque de dormir
        RandomGenerator random = new RandomGenerator(1, 5);
        int sleepTurns = random.Generate();
        target.SleepTurns = sleepTurns;
    }
}