namespace ClassLibrary; 

/// <summary>
/// La clase  <c>Pokemon</c> es responsable de encapsular los atributos y comportamientos específicos de un Pokémon.
/// Aplica el principio de responsabilidad única (SRP) al gestionar exclusivamente los datos y comportamientos de
/// cada Pokémon. Utiliza el patrón Expert, ya que posee toda la información necesaria para administrar sus atributos,
/// como puntos de vida y movimientos. Además facilita la extensión de la clase para añadir nuevas categorías de Pokémon
/// o habilidades sin modificar la clase base, alineándose con el principio abierto/cerrado (OCP) y promoviendo una alta cohesión.
/// Además la robustez y seguridad de esta clase se asegura al evitar estados inválidos y facilitar la detección de errores
/// en el uso de la clase
/// </summary>
    
public class Pokemon
{ 
    private string _name;
    private int _healthPoints;
    private Move _specialMove;
    private const int MaxMoves = 4;
    private List<Move> _moves;
    
    /// <summary>
    /// Obtiene o establece el nombre del Pokémon.
    /// </summary>
    /// <exception cref="ArgumentNullException">Se lanza si el nombre es nulo o vacío.</exception>
    public string Name 
    { 
        get => _name; 
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Name), "El nombre del Pokémon no puede ser nulo o vacío.");
            _name = value;
        }
    }

    /// <summary>
    /// Obtiene o establece los puntos de salud del Pokémon.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Se lanza si los puntos de salud son negativos.</exception>
    public int HealthPoints 
    { 
        get => _healthPoints; 
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(HealthPoints), "Los puntos de salud no pueden ser negativos.");
            _healthPoints = value;
        }
    }

    /// <summary>
    /// Obtiene o establece el movimiento especial del Pokémon.
    /// </summary>
    /// <exception cref="ArgumentNullException">Se lanza si el movimiento especial es nulo.</exception>
    public Move SpecialMove 
    { 
        get => _specialMove; 
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(SpecialMove), "El movimiento especial no puede ser nulo.");
            _specialMove = value;
        }
    }

    /// <summary>
    /// Obtiene o establece el tipo del Pokémon.
    /// </summary>
    public PokemonType.Type Type { get; set; }

    /// <summary>
    /// Obtiene o establece la lista de movimientos regulares del Pokémon.
    /// </summary>
    public List<Move> Moves
    {
        get => _moves ??= new List<Move>(); // Inicializa la lista si es nula.
        set
        {
            if (value != null && value.Count > MaxMoves)
                throw new InvalidOperationException($"No se pueden agregar más de {MaxMoves} movimientos.");
                
            _moves = value;
        }
    }
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Pokemon"/> con una lista de movimientos vacía.
    /// </summary>
    public Pokemon()
    {
        Moves = new List<Move>();
    }
}
