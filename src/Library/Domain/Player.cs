namespace ClassLibrary;

/// <summary>
/// La clase  <c>Player</c> representa a un jugador en el juego, 
/// responsable de gestionar los Pokémon disponibles, el Pokémon activo
/// y el movimiento activo del jugador.
/// </summary>

public class Player
{
    private List<Item> items = new List<Item>();

    /// <summary>               
    /// Obtiene el nombre para mostrar del jugador.
    /// </summary>
    public string DisplayName { get; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase Player con el nombre especificado.
    /// </summary>
    /// <param name="displayName">Nombre del jugador para mostrar en el juego.</param>
    public Player(string displayName)
    {
        DisplayName = displayName;
        this.items.Add(new SuperPocion());
        this.items.Add(new SuperPocion());
        this.items.Add(new SuperPocion());
        this.items.Add(new SuperPocion());
        this.items.Add(new Revivir());
        this.items.Add(new CuraTotal());
        this.items.Add(new CuraTotal());

    }

    /// <summary>
    /// Obtiene la lista de Pokémon disponibles para el jugador.
    /// </summary>
    public List<Pokemon> AvailablePokemons { get; } = new List<Pokemon>();

    /// <summary>
    /// Obtiene el Pokémon actualmente activo del jugador.
    /// </summary>
    public Pokemon ActivePokemon { get; private set; }

    /// <summary>
    /// Obtiene el movimiento actualmente activo del Pokémon del jugador.
    /// </summary>
    public Move ActiveMove { get; private set; }

    /// <summary>
    /// Agrega un Pokémon a la lista de Pokémon disponibles para el jugador.
    /// </summary>
    /// <param name="pokemon">El Pokémon a agregar a la lista.</param>
    public void AddPokemon(Pokemon pokemon)
    {
        this.AvailablePokemons.Add(pokemon);
    }

    /// <summary>
    /// Obtiene el índice de un Pokémon en la lista de Pokémon disponibles
    /// según su nombre para mostrar.
    /// </summary>
    /// <param name="pokemonDisplayName">Nombre del Pokémon a buscar.</param>
    /// <returns>Índice del Pokémon en la lista o -1 si no se encuentra.</returns>
    public int GetIndexOfPokemon(string pokemonDisplayName)
    {
        for (int i = 0; i < this.AvailablePokemons.Count; i++)
        {
            if (this.AvailablePokemons[i].Name == pokemonDisplayName)
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// Activa un Pokémon de la lista disponible en base a su índice.
    /// </summary>
    /// <param name="index">Índice del Pokémon en la lista de disponibles.</param>
    public void ActivatePokemon(int index)
    {
        this.ActivePokemon = this.AvailablePokemons[index];
        this.ActiveMove = null; // Se resetea el movimiento activo.
    }

    /// <summary>
    /// Obtiene el índice de un movimiento en el Pokémon activo 
    /// según el nombre del movimiento.
    /// </summary>
    /// <param name="moveDisplayName">Nombre del movimiento a buscar.</param>
    /// <returns>Índice del movimiento en la lista de movimientos del Pokémon activo o -1 si no se encuentra.</returns>
    public int GetIndexOfMoveInActivePokemon(string moveDisplayName)
    {
        for (int i = 0; i < this.ActivePokemon.Moves.Count; i++)
        {
            if (this.ActivePokemon.Moves[i].Name == moveDisplayName)
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// Activa un movimiento en el Pokémon activo en base a su índice en la lista de movimientos.
    /// </summary>
    /// <param name="index">Índice del movimiento en la lista de movimientos del Pokémon activo.</param>
    public void ActivateMoveInActivePokemon(int index)
    {
        this.ActiveMove = this.ActivePokemon.Moves[index];
    }

    /// <summary>
    /// Activa el movimiento especial del Pokémon activo.
    /// </summary>
    /// <param name="specialMoveDisplayName">Nombre del movimiento especial a activar.</param>
    public void ActivateSpecialMove(string specialMoveDisplayName)
    {
        this.ActiveMove = this.ActivePokemon.SpecialMove;
        // turn.SpecialMoveIsAvailable = false; // Descomentar si el movimiento especial debe estar disponible condicionalmente
    }

    public Item UseItem(string itemName)
    {
        Item itemFound = null;
        foreach (Item item in this.items)
        {
            if (item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase))
            {
                itemFound = item;
                break; // Sale del bucle una vez encontrado
            }
        }

        if (itemFound == null)
        {
            throw new ApplicationException($"No existe el ítem {itemName} en el inventario.");
        }

        this.items.Remove(itemFound);
        return itemFound;
    }
}
    

