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
        this.items.Add(new ItemSuperPotion());
        this.items.Add(new ItemSuperPotion());
        this.items.Add(new ItemSuperPotion());
        this.items.Add(new ItemSuperPotion());
        this.items.Add(new ItemRevive());
        this.items.Add(new ItemCompleteCure());
        this.items.Add(new ItemCompleteCure());

    }
    
    /// <summary>
    /// Lista de Pokémon disponibles para el jugador.
    /// </summary>
    public List<Pokemon> AvailablePokemons { get; } = new List<Pokemon>();

    /// <summary>
    /// El Pokémon activo del jugador.
    /// </summary>
    public Pokemon ActivePokemon { get; private set; }

    /// <summary>
    /// El movimiento actualmente activo del Pokémon del jugador.
    /// </summary>
    public Move ActiveMove { get; private set; }

    // Referencia al oponente de este jugador.
    private Player _opponent;

    /// <summary>
    /// Establece al oponente del jugador.
    /// </summary>
    /// <param name="opponent">El jugador que será el oponente.</param>
    public void SetOpponent(Player opponent)
    {
        _opponent = opponent;
    }

    /// <summary>
    /// Obtiene el oponente del jugador.
    /// </summary>
    public Player GetOpponent()
    {
        return _opponent;
    }
    

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

    public void ExecuteMove(Player defender, double criticalHit)
    {
        this.ActiveMove.ExecuteMove(this.ActivePokemon, defender.ActivePokemon, criticalHit);
    }

    public void TurnChanged()
    {
        foreach (Pokemon pokemon in this.AvailablePokemons)
        {
            if (pokemon.IsBurned)
            {
                pokemon.HealthPoints = (int)(pokemon.HealthPoints * 0.9);
            }
        }
    }
}
    

