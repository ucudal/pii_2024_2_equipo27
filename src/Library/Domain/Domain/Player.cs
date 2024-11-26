using System.Collections.ObjectModel;

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
    /// <param name="moves"></param>
    public Player(string displayName)
    {
        DisplayName = displayName;
        this.items.Add(new ItemSuperPotion());
        this.items.Add(new ItemSuperPotion());
        this.items.Add(new ItemSuperPotion());
        this.items.Add(new ItemSuperPotion());
        this.items.Add(new ItemRevive());
        this.items.Add(new ItemFullHeal());
        this.items.Add(new ItemFullHeal());
    }

    private List<Pokemon> availablePokemons = new List<Pokemon>();

    /// <summary>
    /// Obtiene la lista de Pokémon disponibles para el jugador.
    /// </summary>
    public ReadOnlyCollection<Pokemon> AvailablePokemons
    {
        get { return this.availablePokemons.AsReadOnly(); }
    }

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
    /// El oponente del jugador.
    /// </summary>
    public Player Opponent
    {
        get => _opponent;
        set => _opponent = value;
    }


    /// <summary>
    /// Agrega un Pokémon a la lista de Pokémon disponibles para el jugador.
    /// </summary>
    /// <param name="pokemon">El Pokémon a agregar a la lista.</param>
    public void AddPokemon(Pokemon pokemon)
    {
        this.availablePokemons.Add(pokemon.Clone());
        if (this.availablePokemons.Count == 1) // Es el primer pokemon que se agrega, lo activa por defecto
        {
            this.ActivePokemon = this.availablePokemons[0];
        }
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

    /// <summary>
    /// Devuelve los ítems disponibles y sus cantidades.
    /// </summary>
    /// <returns>Un diccionario con los nombres de los ítems y sus cantidades.</returns>
    public Dictionary<string, int> GetItemsWithQuantities()
    {
        var itemQuantities = new Dictionary<string, int>();

        foreach (var item in items)
        {
            if (itemQuantities.ContainsKey(item.Name))
            {
                itemQuantities[item.Name]++;
            }
            else
            {
                itemQuantities[item.Name] = 1;
            }
        }

        return itemQuantities;
    }

    /// <summary>
    /// Verifica si el Pokémon activo está vivo (HealthPoints > 0) y no está dormido.
    /// Si no cumple estas condiciones, asigna el próximo Pokémon disponible que las cumpla.
    /// </summary>
    public void CheckAndAssignNextActivePokemon()
    {
        // Verificar si el Pokémon activo está KO (HealthPoints <= 0) o dormido
        if (ActivePokemon.HealthPoints <= 0)
        {
            // Buscar el próximo Pokémon vivo y no dormido en la lista
            foreach (var pokemon in AvailablePokemons)
            {
                if (pokemon.HealthPoints > 0)
                {
                    // Asignar el siguiente Pokémon válido como el activo
                    ActivePokemon = pokemon;
                    ActiveMove = null; // Resetea el movimiento activo
                    return;
                }
            }

            // Si no se encuentra ningún Pokémon válido, el jugador queda sin opciones
            ActivePokemon = null;
            throw new InvalidOperationException("Todos los Pokémon del jugador están debilitados o dormidos.");
        }
    }


    public void ExecuteMove(Player defender, Player attacker)
    {
        /////////////////////////////

        //Encontrar los pokemones activos
        Pokemon attackingPokemon = attacker.ActivePokemon;
        Pokemon defendingPokemon = defender.ActivePokemon;

        // Verificar que el Pokémon tenga el ataque seleccionado

        if (attackingPokemon == null)
        {
            throw new ArgumentException($"El Pókemon '{attacker.ActivePokemon}' no está activo para la ataque.");
        }

        if (defendingPokemon == null)
        {
            throw new ArgumentException($"El Pókemon '{defender.ActivePokemon}' no está activo para la defensa.");
        }

        // Verificar si el ataque es efectivo aleatorio con random
        //Enviar mensaje interfaz de que no es efectivo y sino seguir 
        
        double AccuaracyAttack = attacker.ActiveMove.Accuracy;
        
        // Genera el Golpe Crítico con random
        Random random = new Random();
        
        double randomNumber2 = random.NextDouble(); // Genera un número entre 0.0 y 1.0

        if (AccuaracyAttack < randomNumber2)
        {
            
            // Generar un número aleatorio entre 1 y 100
            int randomNumber = random.Next(1, 101);
            double criticalHit = 1;
            if (randomNumber <= 10)
            {
                criticalHit = 1.20;
            }

            // Ejecuta el efecto de los ataques especiales que reducen el HP por turno
            if (defendingPokemon.IsPoisoned)
            {
                defendingPokemon.HealthPoints -= (int)0.05 * (attackingPokemon.HealthPoints);
            }

            if (defendingPokemon.IsBurned)
            {
                defendingPokemon.HealthPoints -= (int)0.10 * (attackingPokemon.HealthPoints);
            }
            
            //Ejecuta el movimiento
            this.ActiveMove.ExecuteMove(this.ActivePokemon, defender.ActivePokemon, criticalHit);

            //Cambia el turno del jugador
            Facade.Instance.ChangeTurn(attacker);
        }
        else
        {
            //Cambia el turno del jugador
            Facade.Instance.ChangeTurn(attacker);
        }
        
    }

    /// <summary>
    /// Actualiza el estado de los Pokémon disponibles del jugador al cambiar de turno.
    /// </summary>
    /// <remarks>
    /// Recorre la lista de Pokémon disponibles y, si un Pokémon está quemado (<see cref="Pokemon.IsBurned"/>),
    /// reduce sus puntos de salud en un 10%.
    /// </remarks>
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

    public IReadOnlyList<Move> GetPokemonsWithMovesForPlayer()
    {
        // Verificar si el Pokémon activo del jugador está definido
        if (this.ActivePokemon == null)
        {
            throw new ArgumentException($"El jugador {this.DisplayName} no tiene un Pokémon activo.");
        }

        // Obtener los movimientos del Pokémon activo
        return this.ActivePokemon.Moves;
    }
}