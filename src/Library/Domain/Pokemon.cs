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
    private MoveNormal _specialMoveNormal;
    private const int MaxMoves = 4;
    private List<IMove> _moves;
    private bool _isPoisoned;
    private bool _isBurned;
    private int _sleepTurns;
    private bool _isParalyzed;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Pokemon"/> con una lista de movimientos vacía.
    /// </summary>
   public Pokemon()
   {
       Moves = new List<IMove>();
       this.IsBurned = false;
       this.IsPoisoned = false;
       this.SleepTurns = 0;
       this.IsParalyzed = false;
   } 
    
    /// <summary>
    /// Obtiene o establece si un Pokémon está envenenado.
    /// Si el Pokémon ya está envenenado, no puede ser afectado por otro estado (quemado, paralizado, dormido).
    /// </summary>
    public bool IsPoisoned
    {
        get => _isPoisoned;
        set
        {
            // Verifica si el Pokémon ya está afectado por un estado especial
            if (_isBurned || _isParalyzed || _sleepTurns > 0)
            {
                throw new InvalidOperationException("El Pokémon no puede ser envenenado si ya está afectado por otro estado (quemado, paralizado, dormido).");
            }

            _isPoisoned = value;
        }
    }

    /// <summary>
    /// Obtiene o establece si un Pokémon está quemado.
    /// Si el Pokémon ya está quemado, no puede ser afectado por otro estado (envenenado, paralizado, dormido).
    /// </summary>
    public bool IsBurned
    {
        get => _isBurned;
        set
        {
            if (_isPoisoned || _isParalyzed || _sleepTurns > 0)
            {
                throw new InvalidOperationException("El Pokémon no puede ser quemado si ya está afectado por otro estado (envenenado, paralizado, dormido).");
            }

            _isBurned = value;
        }
    }

    /// <summary>
    /// Obtiene o establece si un Pokémon está paralizado.
    /// Si el Pokémon ya está paralizado, no puede ser afectado por otro estado (envenenado, quemado, dormido).
    /// </summary>
    public bool IsParalyzed
    {
        get => _isParalyzed;
        set
        {
            if (_isPoisoned || _isBurned || _sleepTurns > 0)
            {
                throw new InvalidOperationException("El Pokémon no puede ser paralizado si ya está afectado por otro estado (envenenado, quemado, dormido).");
            }

            _isParalyzed = value;
        }
    }

    /// <summary>
    /// Obtiene o establece los turnos durante los cuales el Pokémon queda dormido.
    /// Si el Pokémon ya está envenenado, quemado o paralizado, no puede quedarse dormido.
    /// </summary>
    public int SleepTurns
    {
        get => _sleepTurns;
        set
        {
            if (_isPoisoned || _isBurned || _isParalyzed)
            {
                throw new InvalidOperationException("El Pokémon no puede dormir si ya está afectado por otro estado (envenenado, quemado, paralizado).");
            }

            if (value < 0 || value > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(SleepTurns), "El número de turnos de sueño debe estar entre 1 y 4.");
            }

            _sleepTurns = value;
        }
    }

    
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
                _healthPoints= 0;
            _healthPoints = value;
        }
    }

    /// <summary>
    /// Obtiene o establece el movimiento especial del Pokémon.
    /// </summary>
    /// <exception cref="ArgumentNullException">Se lanza si el movimiento especial es nulo.</exception>
    public MoveNormal SpecialMoveNormal 
    { 
        get => _specialMoveNormal; 
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(SpecialMoveNormal), "El movimiento especial no puede ser nulo.");
            _specialMoveNormal = value;
        }
    }

    /// <summary>
    /// Obtiene o establece el tipo del Pokémon.
    /// </summary>
    public PokemonType.Type Type { get; set; }

    /// <summary>
    /// Obtiene o establece la lista de movimientos regulares del Pokémon.
    /// </summary>
    public List<IMove> Moves
    {
        get => _moves ??= new List<IMove>(); // Inicializa la lista si es nula.
        set
        {
            if (value != null && value.Count > MaxMoves)
                throw new InvalidOperationException($"No se pueden agregar más de {MaxMoves} movimientos.");
                
            _moves = value;
        }
    }
    
    /// <summary>
    /// Verifica si el <c>Pokemon</c>  puede atacar.
    /// </summary>
    public bool TryAttack()
    {
        if (IsParalyzed)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 1);
            if (randomNumber == 0)
                return false;
        }

        if (SleepTurns > 0)
        {
            SleepTurns -= 1;
            return false;
        }
        return true;
    }
}
