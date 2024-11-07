namespace ClassLibrary;

/// <summary>
/// Esta clase representa la lista de batallas en curso.
/// </summary>
public class GameList
{
    private List<Game> games = new List<Game>();

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
    public Player FindOpponent(string playerDisplayName)
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
    public Game FindGameByPlayerDisplayName(string displayName)
    {
        foreach (var game in games)
        {
            if (game.Player1.DisplayName == displayName || game.Player2.DisplayName == displayName)
            {
                return game;
            }
        }
        return null;
    }
}

