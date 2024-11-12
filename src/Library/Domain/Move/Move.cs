namespace ClassLibrary;

/// <summary>
/// La clase <c>Move</c> debe ser abstracta porque define la estructura y atributos básicos de todos los ataques en el
/// sistema de batallas, sin representar un movimiento específico por sí sola. Según el principio de responsabilidad única,
/// <c>Move</c> organiza los elementos comunes (como el nombre y precisión) y delega a sus subclases <c>MoveParalize</c>, <c>MoveSleep</c>,
/// <c>MovePosion</c> <c>MoveBurn</c> <c>MoveNormal</c> la implementación de efectos específicos, asegurando que cada ataque cumpla
/// su función particular sin duplicar código. Hicimos uso del patrón de diseño Strategy que permite diferentes estrategias de implementación
/// de un mismo método. Además, el diseño sigue los principios de Liskov y Abierto/Cerrado, permitiendo la adición de nuevos tipos de movimientos
/// sin modificar la estructura base, lo cual favorece un sistema extensible y polimórfico. 
/// </summary>
public abstract class Move
{
    /// <summary>
    /// Nombre del movimiento.
    /// </summary>
    private string _name;
    public string Name 
    { 
        get { return _name; }
        set 
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre del movimiento no puede estar vacío o ser solo espacios en blanco.");
            _name = value;
        }
    }

    /// <summary>
    /// Valor del ataque del movimiento.
    /// </summary>
    private int _attackValue;
    public int AttackValue 
    { 
        get { return _attackValue; }
        set 
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(AttackValue), "El valor de ataque no puede ser negativo.");
            _attackValue = value;
        }
    }
    /// <summary>
    /// El valor de precisión define la probabilidad de que el ataque se ejecute.
    /// </summary>
    private double _accuracy;
    public double Accuracy 
    { 
        get { return _accuracy; }
        set 
        {
            if (value < 0 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(Accuracy), "El valor de precisión debe estar entre 0 y 1.");
            _accuracy = value;
        }
    }

    /// <summary>
    /// Constructor de la clase.
    /// </summary>
    /// <param name="name">El nombre del movimiento.</param>
    /// <param name="attackValue">El valor de ataque del movimiento.</param>
    /// <param name="accuracy">El valor de precisión del movimiento.</param>
    public Move(string name, int attackValue, double accuracy)
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
    public abstract void ExecuteMove(Pokemon attacker, Pokemon target, double criticalHit);
}
