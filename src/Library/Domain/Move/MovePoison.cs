namespace ClassLibrary;

/// <summary>
/// <c>MovePoison</c> es una subclase de <c>Move</c> cuyo objetivo es aplicar daño al Pokémon objetivo y,
/// además, envenenarlo. Su responsabilidad principal, aplicando el polimorfismo, es calcular el daño basado en la
/// efectividad de tipos y luego aplicar el estado de envenenamiento al objetivo, estableciendo
/// la propiedad IsPoisoned como true. Esto permite que el veneno sea un efecto persistente que
/// afecta al objetivo en el futuro. 
/// </summary>
public class MovePoison : Move
{
    /// <summary>
    /// Constructor de la clase <c>MovePoison</c>. 
    /// </summary>
    /// <param name="name">El nombre del movimiento.</param>
    /// <param name="attackValue">El valor de ataque del movimiento.</param>
    /// <param name="accuracy">El valor de la precisión del movimiento.</param>
    public MovePoison(string name, int attackValue, double accuracy, Type moveType) : base(name, attackValue, accuracy,
        moveType)
    {
        // Intencionalmente vacío
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

        //Aplica al pokemon ataque de envenenado
        target.IsPoisoned = true;
    }
}