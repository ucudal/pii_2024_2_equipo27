namespace ClassLibrary;

/// <summary>
/// La clase  <c>Pokemon</c> es responsable de encapsular los atributos y comportamientos específicos de un Pokémon.
/// La clase Pokemon sigue los principios de diseño orientado a objetos, como el Principio de Responsabilidad Única y
/// al centrarse en gestionar el estado y las interacciones de un Pokémon en combate. Maneja atributos como puntos de salud,
/// movimientos y efectos de estado (veneno, quemado, parálisis y sueño), y valida que estos no se modifiquen de manera inapropiada
/// con excepciones y restricciones implementadas. Esas restricciones son como la cantidad máxima de movimientos y la validación
/// de estados, aseguran que el Pokémon funcione de acuerdo con las reglas del juego de manera coherente y extensible.
/// Además, el encapsulamiento permite que las propiedades puedan ser modificadas cuando se cumplen ciertas condiciones. 
/// </summary>
public class Pokemon

{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <c>Pokemon</c> con una lista de movimientos vacía.
    /// <param name="moves">Arreglo de movimientos del Pokémon. Debe contener exactamente 4 movimientos.</param>
    /// <exception cref="PokemonException">Se lanza si no se proporcionan exactamente 4 movimientos.</exception>
    /// </summary>
    public Pokemon(Move[] moves)
    {
        if (moves.Length != MAX_MOVES)
        {
            throw new PokemonException("Tiene que haber 4 movimientos");
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
    /// <exception cref="PokemonException">Se lanza si el Pokémon ya está afectado por otro estado (quemado, paralizado, dormido).</exception>
    /// </summary>
    public bool IsPoisoned
    {
        get { return this._isPoisoned; }
        set
        {
            // Verifica si el Pokémon ya está afectado por un estado especial
            if (_isBurned || _isParalyzed || _sleepTurns > 0)
            {
                throw new PokemonException(
                    "El Pokémon no puede ser envenenado si ya está afectado por otro estado (quemado, paralizado, dormido).");
            }

            _isPoisoned = value;
        }
    }

    private bool _isPoisoned;


    /// <summary>
    /// Obtiene o establece si un Pokémon está quemado.
    /// Si el Pokémon ya está quemado, no puede ser afectado por otro estado (envenenado, paralizado, dormido).
    /// <exception cref="PokemonException">Se lanza si el Pokémon ya está afectado por otro estado (envenenado, paralizado, dormido).</exception>
    /// </summary>
    public bool IsBurned
    {
        get => _isBurned;
        set
        {
            if (_isPoisoned || _isParalyzed || _sleepTurns > 0)
            {
                throw new PokemonException(
                    "El Pokémon no puede ser quemado si ya está afectado por otro estado (envenenado, paralizado, dormido).");
            }

            _isBurned = value;
        }
    }

    private bool _isBurned;

    /// <summary>
    /// Obtiene o establece si un Pokémon está paralizado.
    /// Si el Pokémon ya está paralizado, no puede ser afectado por otro estado (envenenado, quemado, dormido).
    /// <exception cref="PokemonException">Se lanza si el Pokémon ya está afectado por otro estado (envenenado, quemado, dormido).</exception>
    /// </summary>
    public bool IsParalyzed
    {
        get { return this._isParalyzed; }
        set
        {
            if (_isPoisoned || _isBurned || _sleepTurns > 0)
            {
                throw new PokemonException(
                    "El Pokémon no puede ser paralizado si ya está afectado por otro estado (envenenado, quemado, dormido).");
            }

            _isParalyzed = value;
        }
    }

    private bool _isParalyzed;


    /// <summary>
    /// Obtiene o establece los turnos durante los cuales el Pokémon queda dormido.
    /// Si el Pokémon ya está envenenado, quemado o paralizado, no puede quedarse dormido.
    /// <exception cref="PokemonException">Se lanza si el Pokémon ya está afectado por otro estado (envenenado, paralizado, quemado) o si los turnos de estar dormido no están entre 0 y 4.</exception>
    /// </summary>
    public int SleepTurns
    {
        get { return this._sleepTurns; }
        set
        {
            if (_isPoisoned || _isBurned || _isParalyzed)
            {
                throw new PokemonException(
                    "El Pokémon no puede dormir si ya está afectado por otro estado (envenenado, quemado, paralizado).");
            }

            if (value < 0 || value > 4)
            {
                throw new PokemonException("Los turnos de dormir deben estar entre 0 y 4");
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
                throw new ArgumentNullException("El nombre del Pokémon no puede ser nulo o vacío.");
            _name = value;
        }
    }

    private string _name;


    /// <summary>
    /// Obtiene o establece los puntos de salud del Pokémon.
    /// </summary>
    public int HealthPoints
    {
        get { return this._healthPoints; }
        set
        {
            if (value < 0)
                _healthPoints = 0;
            else
            {
                _healthPoints = value;
            }

            if (value > 100)
            {
                _healthPoints = 100;
            }
        }
    }

    private int _healthPoints;


    /// <summary>
    /// Obtiene o establece el tipo del Pokémon.
    /// <exception cref="ArgumentOutOfRangeException">Se lanza si el número de turnos está fuera del rango permitido (0-4).</exception>
    /// </summary>
    private Type _pokemonType;

    public Type PokemonType
    {
        get => _pokemonType;
        set
        {
            if (!Enum.IsDefined(typeof(Type), value))
            {
                throw new PokemonException("El tipo de Pokémon no es válido.");
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
            RandomGenerator random= new RandomGenerator(0,2);
            int randomNumber = random.Generate();
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

    /// <summary>
    /// Método para obtener los movimientos del Pokémon como una cadena.
    /// </summary>
    public string GetMovesString()
    {
        List<string> movesList = new List<string>();

        foreach (Move move in Moves)
        {
            movesList.Add(move.Name);
        }

        return string.Join(", ", movesList);
    }

    public Pokemon Clone()
    {
        Pokemon result = new Pokemon(this._moves.ToArray());
        result._name = this._name;
        result._sleepTurns = this.SleepTurns ;
        result._isParalyzed = this._isParalyzed;
        result._isPoisoned = this._isPoisoned;
        result._isBurned = this._isBurned;
        result._healthPoints = this._healthPoints;
        return result;
    }
}