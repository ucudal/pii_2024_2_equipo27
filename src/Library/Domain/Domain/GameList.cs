namespace ClassLibrary;

/// <summary>
/// Esta clase representa la lista de batallas en curso.
/// </summary>
public class GameList
{
    private List<Game> games = new List<Game>();
    
    /// <summary>
    /// Obtiene una lista de juegos como solo lectura.
    /// </summary>
    public IReadOnlyList<Game> Games => games.AsReadOnly();
    
    /// <summary>
    /// Crea una nueva batalla entre dos jugadores.
    /// </summary>
    /// <param name="player1">El primer jugador.</param>
    /// <param name="player2">El oponente.</param>
    /// <returns>La batalla creada.</returns>
    public Game AddGame(Player player1, Player player2)
    {
        if (player1.DisplayName.Equals(player2.DisplayName, StringComparison.OrdinalIgnoreCase))
        {
            throw new ApplicationException("El jugador no puede jugar consigo mismo");
        }
        
        var game = new Game(player1,player2);
        this.games.Add(game);
        return game;
    }
    
    /// <summary>
    /// Encuentra un jugador por su nombre para una batalla en curso.
    /// </summary>
    /// <param name="displayName">El nombre del jugador.</param>
    /// <returns>El objeto Player si se encuentra; de lo contrario, null.</returns>
    public Player FindPlayerByDisplayName(string displayName)
    {
        foreach (var game in games)
        {
            if (game.Player1.DisplayName == displayName)
            {
                return game.Player1;
            }
            else if (game.Player2.DisplayName == displayName)
            {
                return game.Player2;
            }
        }
        return null;
    }
    
    /// <summary>
    /// Encuentra un jugador por el nombre de su oponente para una batalla en curso.
    /// </summary>
    /// <param name="displayName">El nombre del jugador.</param>
    /// <returns>El objeto Player si se encuentra; de lo contrario, null.</returns>
    public Player FindOpponentOfDisplayName(string playerDisplayName)
    {
        foreach (var game in games)
        {
            if (game.Player1.DisplayName == playerDisplayName)
            {
                return game.Player2;
            }
            else if (game.Player2.DisplayName == playerDisplayName)
            {
                return game.Player1;
            }
        }
        return null;
    }

    /// <summary>
    /// Encuentra una battala por el nombre de uno de sus jugadores.
    /// </summary>
    /// <param name="displayName">El nombre del jugador.</param>
    /// <returns> El objeto Game si se encuentra; de lo contrario, null.</returns>
    public Game FindGameByPlayerDisplayName(string playerDisplayName)
    {
        foreach ( Game game in games)
        {
             if (game.Player1.DisplayName == playerDisplayName || game.Player2.DisplayName == playerDisplayName)
            {
                return game;
            }
        }
        return null;
    }
    public List<string> GetPokemonsWithMovesForPlayer(string playerDisplayName)
    {
        // Buscar al jugador por su nombre
        Player player = FindPlayerByDisplayName(playerDisplayName);
        if (player == null)
        {
            return new List<string> { $"El jugador {playerDisplayName} no está jugando" };
        }

        // Obtener los Pokémon del jugador
        var pokemons = player.AvailablePokemons;

        // Crear una lista para almacenar los nombres de los Pokémon y sus movimientos
        List<string> pokemonsWithMoves = new List<string>();

        // Recorrer cada Pokémon y obtener sus movimientos
        foreach (var pokemon in pokemons)
        {
            // Obtener los nombres de los movimientos del Pokémon
            var moves = pokemon.Moves.Select(move => move.Name).ToList();

            // Formatear la información del Pokémon y sus movimientos
            string pokemonInfo = $"{pokemon.Name}: {string.Join(", ", moves)}";

            // Agregar la información a la lista
            pokemonsWithMoves.Add(pokemonInfo);
        }

        return pokemonsWithMoves;
    }


}

