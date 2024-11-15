namespace ClassLibrary;

/// <summary>
/// La clase  <c>Pokemon</c> es responsable de encapsular los atributos y comportamientos específicos de un Pokémon.
/// La clase Pokemon sigue los principios de diseño orientado a objetos, como el Principio de Responsabilidad Única y
/// al centrarse en gestionar el estado y las interacciones de un Pokémon en combate. Maneja atributos como puntos de salud,
/// movimientos y efectos de estado (veneno, quemado, parálisis y sueño), y valida que estos no se modifiquen de manera inapropiada
/// con excepciones y restricciones implementadas. Esas restricciones son como la cantidad máxima de movimientos y la validación
/// de estados, aseguran que el Pokémon funcione de acuerdo con las reglas del juego de manera coherente y extensible. 
/// </summary>
public class Pokemon

{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <c>Pokemon</c> con una lista de movimientos vacía.
    /// </summary>
    public Pokemon(Move[] moves)
    {
        if (moves.Length != MAX_MOVES)
        {
            throw new ApplicationException("Tiene que haber 4 movimientos");
        }
        this._moves = moves.ToList();
        this.SleepTurns = 0;
        this.IsParalyzed = false;
        this._isPoisoned = false;
        this._isBurned = false;
        this.HealthPoints = 100;
    }

    /// <summary>
    /// Obtiene o establece si un Pokémon está envenenado.
    /// Si el Pokémon ya está envenenado, no puede ser afectado por otro estado (quemado, paralizado, dormido).
    /// </summary>
    public bool IsPoisoned
    {
        get { return this._isPoisoned; }
        set
        {
            // Verifica si el Pokémon ya está afectado por un estado especial
            if (_isBurned || _isParalyzed || _sleepTurns > 0)
            {
                throw new InvalidOperationException(
                    "El Pokémon no puede ser envenenado si ya está afectado por otro estado (quemado, paralizado, dormido).");
            }

            _isPoisoned = value;
        }
    }

    private bool _isPoisoned;


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
                throw new InvalidOperationException(
                    "El Pokémon no puede ser quemado si ya está afectado por otro estado (envenenado, paralizado, dormido).");
            }

            _isBurned = value;
        }
    }

    private bool _isBurned;

    /// <summary>
    /// Obtiene o establece si un Pokémon está paralizado.
    /// Si el Pokémon ya está paralizado, no puede ser afectado por otro estado (envenenado, quemado, dormido).
    /// </summary>
    public bool IsParalyzed
    {
        get { return this._isParalyzed; }
        set
        {
            if (_isPoisoned || _isBurned || _sleepTurns > 0)
            {
                throw new InvalidOperationException(
                    "El Pokémon no puede ser paralizado si ya está afectado por otro estado (envenenado, quemado, dormido).");
            }

            _isParalyzed = value;
        }
    }

    private bool _isParalyzed;


    /// <summary>
    /// Obtiene o establece los turnos durante los cuales el Pokémon queda dormido.
    /// Si el Pokémon ya está envenenado, quemado o paralizado, no puede quedarse dormido.
    /// </summary>
    public int SleepTurns
    {
        get { return this._sleepTurns; }
        set
        {
            if (_isPoisoned || _isBurned || _isParalyzed)
            {
                throw new InvalidOperationException(
                    "El Pokémon no puede dormir si ya está afectado por otro estado (envenenado, quemado, paralizado).");
            }

            if (value < 0 || value > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(SleepTurns),
                    "El número de turnos de sueño debe estar entre 1 y 4.");
            }

            _sleepTurns = value;
        }
    }

    private int _sleepTurns;


    /// <summary>
    /// Obtiene o establece el nombre del Pokémon.
    /// </summary>
    /// <exception cref="ArgumentNullException">Se lanza si el nombre es nulo o vacío.</exception>
    public string Name
    {
        get { return this._name; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Name), "El nombre del Pokémon no puede ser nulo o vacío.");
            _name = value;
        }
    }

    private string _name;


    /// <summary>
    /// Obtiene o establece los puntos de salud del Pokémon.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Se lanza si los puntos de salud son negativos.</exception>
    public int HealthPoints
    {
        get { return this._healthPoints; }
        set
        {
            if (value < 0)
                _healthPoints = 0;
            _healthPoints = value;
        }
    }

    private int _healthPoints;


    /// <summary>
    /// Obtiene o establece el tipo del Pokémon.
    /// </summary>
    private Type _pokemonType; 
    public Type PokemonType
    {
        get => _pokemonType;
        set
        {
            if (!Enum.IsDefined(typeof(Type), value))
            {
                throw new ArgumentException("El tipo de Pokémon no es válido.");
            }

            _pokemonType = value;
        }
    }


    /// <summary>
    /// Obtiene o establece la lista de movimientos regulares del Pokémon.
    /// </summary>
    public IReadOnlyList<Move> Moves
    {
        get { return this._moves.AsReadOnly(); }

        // set
        // {
        //     if (value != null && value.Count > MaxMoves)
        //         throw new InvalidOperationException($"No se pueden agregar más de {MaxMoves} movimientos.");
        //
        //     _moves = value;
        // }
    }

    public const int MAX_MOVES = 4;
    private List<Move> _moves;

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