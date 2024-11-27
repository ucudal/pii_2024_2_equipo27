namespace ClassLibrary;

/// <summary>
/// Esta clase representa la lista de batallas en curso. La clase GameList representa y gestiona la lista de
/// batallas en curso, permitiendo crear nuevas partidas, buscar jugadores, oponentes y juegos activos por nombre.
/// Aplica principios GRASP y el principio de responsabilidad única (SRP) al encargarse exclusivamente de estas tareas.
/// Además, su método AddGame asegura la consistencia del sistema al validar que un jugador no pueda enfrentarse a sí mismo.
/// El diseño también respeta el principio abierto/cerrado (OCP), facilitando futuras extensiones sin modificar su
/// estructura base, manteniendo así la cohesión y adaptabilidad.
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

        var game = new Game(player1, player2);
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
        if (string.IsNullOrWhiteSpace(displayName))
        {
            throw new ArgumentNullException("El jugador no puede estar vacío");
        }

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
        if (string.IsNullOrWhiteSpace(playerDisplayName))
        {
            throw new ArgumentNullException("El jugador no puede estar vacío");
        }

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
        foreach (Game game in games)
        {
            if (game.Player1.DisplayName == playerDisplayName || game.Player2.DisplayName == playerDisplayName)
            {
                return game;
            }
        }

        return null;
    }
}