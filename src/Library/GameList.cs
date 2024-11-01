namespace Ucu.Poo.DiscordBot.Domain;

/// <summary>
/// Esta clase representa la lista de batallas en curso.
/// </summary>
public class GamesList
{
    private List<Game> games = new List<Game>();

    /// <summary>
    /// Crea una nueva batalla entre dos jugadores.
    /// </summary>
    /// <param name="player1">El primer jugador.</param>
    /// <param name="player2">El oponente.</param>
    /// <returns>La batalla creada.</returns>
    public Game AddGame(string player1, string player2)
    {
        
        if(player1.Equals(player2, StringComparasion.OrdinalIgnoreCase))
        { 
            trow new ApplicationException("El jugador no puede jugar consigo mismo")
        }
        var game = new Game(player1, player2);
        this.games.Add(game);
        return game;
    }
}
