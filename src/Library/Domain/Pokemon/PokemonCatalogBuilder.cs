namespace ClassLibrary;

/// <summary>
/// La clase  <c>PokemonCatalogBuilder</c> se encarga de crear y configurar un catálogo de Pokémon, gestionando la asignación
/// de atributos y movimientos. Aplica el Principio de Responsabilidad Única (SRP) al centralizar toda la lógica
/// de construcción, lo que facilita el mantenimiento. Como patrón de diseño, se puede considerar un Builder, ya que
/// permite crear objetos complejos de manera controlada. Además, utiliza el patrón Expert de GRASP, siendo la autoridad
/// en la creación de Pokémon, lo que asegura una implementación coherente. Cumple con el Principio de Sustitución de
/// Liskov (LSP), permitiendo su extensión sin afectar al catálogo. Esta estructura promueve un diseño desacoplado y escalable,
/// facilitando la integración de nuevas funcionalidades en el sistema.
/// </summary>
public class PokemonCatalogBuilder
{
    // Lista de Pokémons que serán añadidos al catálogo.
    private List<Pokemon> _pokemonList = new List<Pokemon>();

    /// <summary>
    /// Obtiene una lista de solo lectura de los Pokémon disponibles en el catálogo.
    /// </summary>
    public IReadOnlyList<Pokemon> PokemonList => _pokemonList;


    /// <summary>
    /// Constructor de la clase que inicializa y añade varios Pokémon al catálogo.
    /// </summary>
    public PokemonCatalogBuilder()
    {
        AddPokemonToCatalog("Blaziken", new Move[]
        {
            new MoveNormal("Patada Ígnea", 80, 0.5, Type.Fire),
            new MoveNormal("Llamarada", 90, 0.7, Type.Fire),
            new MoveNormal("Tajo Aéreo", 70, 0.5, Type.Flying),
            new MoveBurn("Anillo Ígneo", 0, 0.3, Type.Fire)
        }, Type.Fire);

        AddPokemonToCatalog("Tinkaton", new Move[]
        {
            new MoveNormal("Carantoña", 90, 0.6, Type.Normal),
            new MoveNormal("Roca Afilada", 80, 0.5, Type.Rock),
            new MoveNormal("Golpe Mordaza", 85, 0.8, Type.Fighting),
            new MovePoison("Martillo Gigante", 5, 0.8, Type.Poison)
        }, Type.Poison);

        AddPokemonToCatalog("Salamence", new Move[]
        {
            new MoveNormal("Enfado", 120, 0.4, Type.Dragon),
            new MoveNormal("Lanzallamas", 90, 0.6, Type.Fire),
            new MoveNormal("Cabeza de Hierro", 80, 0.9, Type.Fighting),
            new MoveParalize("Vuelo", 5, 0.4, Type.Flying)
        }, Type.Dragon);

        AddPokemonToCatalog("Bellsprout", new Move[]
        {
            new MoveNormal("Absorber", 20, 0.7, Type.Grass),
            new MoveNormal("Látigo Cepa", 45, 0.4, Type.Grass),
            new MoveNormal("Ácido", 40, 0.9, Type.Poison),
            new MoveBurn("Rayo Solar", 15, 0.3, Type.Grass)
        }, Type.Grass);

        AddPokemonToCatalog("Zangoose", new Move[]
        {
            new MoveNormal("Cuchillada", 70, 0.85, Type.Normal),
            new MoveNormal("Garra Brutal", 90, 0.6, Type.Normal),
            new MoveNormal("Despejar", 60, 0.9, Type.Normal),
            new MoveSleep("Danza Espada", 0, 1.0, Type.Normal)
        }, Type.Normal);

        AddPokemonToCatalog("Rayquaza", new Move[]
        {
            new MoveNormal("Ascenso Draco", 120, 0.5, Type.Dragon),
            new MoveNormal("Pulso Dragón", 85, 0.8, Type.Dragon),
            new MoveNormal("Rayo Hielo", 90, 0.7, Type.Ice),
            new MoveNormal("Hiperrayo", 40, 0.9, Type.Normal)
        }, Type.Dragon);

        AddPokemonToCatalog("Wailord", new Move[]
        {
            new MoveNormal("Hidrobomba", 110, 0.5, Type.Water),
            new MoveNormal("Cuerpo Pesado", 85, 0.8, Type.Normal),
            new MoveNormal("Ventisca", 110, 0.5, Type.Ice),
            new MovePoison("Salto Cañón", 5, 0.9, Type.Water)
        }, Type.Water);

        AddPokemonToCatalog("Sudowoodo", new Move[]
        {
            new MoveNormal("Avalancha", 75, 0.7, Type.Rock),
            new MoveNormal("Lanzarrocas", 50, 0.85, Type.Rock),
            new MoveNormal("Terremoto", 100, 0.5, Type.Ground),
            new MoveParalize("Maldición", 10, 0.8, Type.Ghost)
        }, Type.Rock);

        AddPokemonToCatalog("Mew", new Move[]
        {
            new MoveNormal("Psíquico", 90, 0.9, Type.Psychic),
            new MoveNormal("Sombra Vil", 70, 0.8, Type.Ghost),
            new MoveNormal("Corte", 50, 1.0, Type.Normal),
            new MoveSleep("Aurasfera", 0, 0.9, Type.Fighting)
        }, Type.Psychic);

        AddPokemonToCatalog("Azumarill", new Move[]
        {
            new MoveNormal("Rayo Burbuja", 65, 0.8, Type.Water),
            new MoveNormal("Cola Férrea", 75, 0.7, Type.Normal),
            new MoveNormal("Carantoña", 90, 0.6, Type.Bug),
            new MoveBurn("Acua Jet", 5, 1.0, Type.Water)
        }, Type.Water);

        AddPokemonToCatalog("Jigglypuff", new Move[]
        {
            new MoveNormal("Placaje", 40, 0.9, Type.Normal),
            new MoveNormal("Doble Bofetón", 30, 0.8, Type.Normal),
            new MoveNormal("Bostezo", 20, 0.85, Type.Normal),
            new MoveNormal("Hipnosis", 25, 0.6, Type.Normal)
        }, Type.Normal);

        AddPokemonToCatalog("Lucario", new Move[]
        {
            new MoveNormal("Esfera Aural", 80, 0.9, Type.Fighting),
            new MoveNormal("Velocidad Extrema", 80, 0.95, Type.Fighting),
            new MoveNormal("Puño Incremento", 50, 0.85, Type.Fighting),
            new MovePoison("Aurasfera", 10, 1.0, Type.Fighting)
        }, Type.Fighting);

        AddPokemonToCatalog("Pikachu", new Move[]
        {
            new MoveNormal("Impactrueno", 40, 0.95, Type.Electric),
            new MoveNormal("Rayo", 90, 0.7, Type.Electric),
            new MoveParalize("Onda Trueno", 0, 0.9, Type.Electric),
            new MoveNormal("Voltio Cruel", 100, 0.6, Type.Electric)
        }, Type.Electric);

        AddPokemonToCatalog("Charizard", new Move[]
        {
            new MoveNormal("Lanzallamas", 90, 0.7, Type.Fire),
            new MoveNormal("Garra Dragón", 80, 0.8, Type.Dragon),
            new MoveBurn("Anillo Ígneo", 5, 0.8, Type.Fire),
            new MoveNormal("Tajo Aéreo", 70, 0.9, Type.Flying)
        }, Type.Fire);

        AddPokemonToCatalog("Gengar", new Move[]
        {
            new MoveNormal("Bola Sombra", 80, 0.8, Type.Ghost),
            new MoveNormal("Psíquico", 90, 0.7, Type.Psychic),
            new MoveSleep("Hipnosis", 0, 0.6, Type.Ghost),
            new MovePoison("Bomba Lodo", 90, 0.7, Type.Poison)
        }, Type.Ghost);

        AddPokemonToCatalog("Lapras", new Move[]
        {
            new MoveNormal("Surf", 90, 0.8, Type.Water),
            new MoveNormal("Ventisca", 110, 0.6, Type.Ice),
            new MoveBurn("Canto Helado", 5, 0.9, Type.Ice),
            new MoveNormal("Cabeza de Hierro", 80, 0.8, Type.Normal)
        }, Type.Water);
    }

    /// <summary>
    /// Agrega un nuevo Pokémon al catálogo con un nombre, una lista de movimientos y un tipo.
    /// </summary>
    /// <param name="name">El nombre del Pokémon. No puede ser nulo, vacío ni contener solo espacios.</param>
    /// <param name="moves">
    /// Una lista de movimientos del Pokémon. Debe contener exactamente el número de movimientos permitido 
    /// definido por <see cref="Pokemon.MAX_MOVES"/>.
    /// </param>
    /// <param name="type">
    /// El tipo del Pokémon, especificado como un valor válido del enumerador <see cref="Type"/>.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Se lanza si el nombre es nulo, vacío, contiene solo espacios o si la lista de movimientos es nula.
    /// </exception>
    /// <exception cref="PokemonException">
    /// Se lanza si la lista de movimientos no contiene exactamente <see cref="Pokemon.MAX_MOVES"/> movimientos, o si el tipo proporcionado no es válido.
    /// </exception>
    private void AddPokemonToCatalog(string name, Move[] moves, Type type)
    {
        // Validar que el nombre no sea nulo, vacío o solo espacios
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "El nombre del Pokémon no puede estar vacío o ser solo espacios en blanco.");
        }

        // Validar que la lista de movimientos no sea nula
        if (moves == null)
        {
            throw new ArgumentException("La lista de movimientos no puede ser nula.");
        }

        // Validar que la lista de movimientos tenga la cantidad exacta definida
        if (moves.Length != Pokemon.MAX_MOVES)
        {
            throw new PokemonException(
                $"La lista de movimientos debe contener exactamente {Pokemon.MAX_MOVES} movimientos.");
        }

        // Validar que el tipo sea un valor válido del enum Type
        if (!Enum.IsDefined(typeof(Type), type))
        {
            throw new PokemonException("El tipo del Pokémon no es válido.");
        }

        // Crea una nueva instancia de un Pokémon y le asigna sus atributos.
        Pokemon pokemon = new Pokemon(moves);
        pokemon.Name = name;
        pokemon.PokemonType = type;
        this._pokemonList.Add(pokemon); // Añade el Pokémon a la lista del catálogo.
    }
}