namespace ClassLibrary;


/// <summary>
/// La clase <c>MoveSleep</c> tiene la responsabilidad de almacenar y gestionar los valores de ataque, su nombre, y método de ejecución de un movimiento especial.
/// Esto sigue el principio de responsabilidad única (SRP) ya que su única función es representar los atributos de un movimiento en el juego.
/// </summary>
/// 
public class MoveBurn: Move
{
    /// <summary>
    /// Constructor de la clase <c>MoveBurn</c>. Inicializa los valores de nombre, ataque, defensa y curación.
    /// Esto sigue el principio de Liskov Substitution Principle (LSP) porque permite que cualquier clase derivada de <c>MoveSleep</c> (si la hubiera) 
    /// pueda sustituirse sin alterar el comportamiento de la lógica del juego.
    /// </summary>
    /// <param name="name">El nombre del movimiento.</param>
    /// <param name="attackValue">El valor de ataque del movimiento.</param>
    
    public MoveBurn(string name, int attackValue, double accuracy): base(name, attackValue, accuracy) 
    {
        this.Name = name;
        this.AttackValue = attackValue;
        this.Accuracy = accuracy;

    }
    
    /// <summary>
    /// Método para aplicar el ataque del <c>IMove</c> en particular, considerando ambos pokemones.
    /// </summary>
    /// <param name="attacker">El pokemon que está atacando.</param>
    /// <param name="target">El pokemon que está siendo atacado.</param>
    ///
    public override void ExecuteMove(Pokemon attacker, Pokemon target, double criticalHit)
    {
        //Aplica el ataque común
        if (this.AttackValue > 0)
        {
            double typeEffectiveness = PokemonType.GetEffectiveness(attacker.Type, target.Type);
            int calculatedDamage = (int)((this.AttackValue * typeEffectiveness)*(criticalHit));
            target.HealthPoints -= calculatedDamage;
        }
        
        //Aplica al pokemon ataque de quemado
        target.IsBurned= true;
    }
}