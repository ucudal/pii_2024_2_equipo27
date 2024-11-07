namespace ClassLibrary;

public abstract class Move: IMove
{
    /// <summary>
    /// Nombre del movimiento. 
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Valor del ataque del movimiento.
    /// </summary>
    public int AttackValue { get; set; }
    
    /// <summary>
    /// El valor de precisión define la probabilidad de que el ataque se ejecute. 
    /// </summary>
    public double Accuracy { get; set; }

    /// <summary>
    /// Constructor de la clase.
    /// </summary>
    /// <param name="name">El nombre del movimiento.</param>
    /// <param name="attackValue">El valor de ataque del movimiento.</param>
    public Move(string name, int attackValue, double accuracy)
    {
        this.Name = name;
        this.AttackValue = attackValue;
        this.Accuracy = accuracy;
    }
        
    /// <summary>
    /// Método para aplicar el ataque considerando ambos pokemones.
    /// </summary>
    /// <param name="attacker">El pokemon que está atacando.</param>
    /// <param name="target">El pokemon que está siendo atacado.</param>
    ///
    public virtual void ExecuteMove(Pokemon attacker, Pokemon target, bool criticalHit)
    {
        double typeEffectiveness = PokemonType.GetEffectiveness(attacker.Type, target.Type);
        int calculatedDamage;
        if (criticalHit)
        {
            calculatedDamage = (int)((this.AttackValue * typeEffectiveness) * 1.2);
        }
        else
        {
            calculatedDamage = (int)((this.AttackValue * typeEffectiveness));
        }

        target.HealthPoints -= calculatedDamage;
    }
}
