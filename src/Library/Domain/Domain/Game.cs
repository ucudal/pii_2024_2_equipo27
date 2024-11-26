namespace ClassLibrary;

/// <summary>
///  La clase <c>Game</c> tiene la responsabilidad de conocer a los jugadores y verificar si el juego está activo o ha terminado.
///  Esto sigue el principio de responsabilidad única (SRP) ya que su única función es gestionar el estado del juego.
///  Además, según el principio de "experto" (Expert), la clase <c>Game</c> es la más adecuada para gestionar estas tareas,
///  ya que contiene toda la información sobre los jugadores y el estado del juego.
/// </summary>
public class Game
{
    /// <summary>
    ///  Constructor de la clase <c>Game</c>. Inicializa los jugadores y el estado del juego.
    /// </summary>
    /// <param name="player1">El primer jugador.</param>
    /// <param name="player2">El segundo jugador.</param>
    public Game(Player player1, Player player2)
    {
        Player1 = player1;
        Player2 = player2;
        Turn = new Turn(player1, player2);
        PlayIsOn = true; // El juego inicia en estado activo
        Winner = null;
    }

    /// <summary>
    ///  Propiedad que almacena al jugador 1 del juego.
    /// </summary>
    public Player Player1 { get; }

    /// <summary>
    ///  Propiedad que almacena al jugador 2 del juego.
    /// </summary>
    public Player Player2 { get; }

    /// <summary>
    ///  Instancia de la clase Turn para gestionar el turno actual del juego.
    /// </summary>
    public Turn Turn { get; set; }

    /// <summary>
    ///  Propiedad que indica el jugador que actualmente tiene el turno.
    /// </summary>
    public Player TurnPlayer => Turn.CurrentPlayer;

    /// <summary>
    /// Propiedad que indica si el juego sigue activo (true) o ha terminado (false).
    /// </summary>
    public bool PlayIsOn { get; private set; }
    
    /// <summary>
    /// Propiedad que indica el jugdor que ganó la partida. 
    /// </summary>
    public Player Winner { get; private set; }

    /// <summary>
    /// Verifica si el juego debe terminar revisando si todos los Pokémon de alguno de los jugadores tienen 0 puntos de vida.
    /// Si un jugador pierde todos sus Pokémon, el juego termina y se declara un ganador.
    /// </summary>
    public void CheckIfGameEnds()
    {
        // Inicializamos una variable p
        var todosSonCeroPlayer1 = true; 
        var todosSonCeroPlayer2 = true;

        foreach (var pokemon in Player1.AvailablePokemons)
            if (pokemon.HealthPoints > 0)
                todosSonCeroPlayer1 = false;

        // Verificamos si todos los Pokémon del jugador 2 tienen 0 puntos de vida
        foreach (var pokemon in Player2.AvailablePokemons)
            if (pokemon.HealthPoints > 0)
                todosSonCeroPlayer2 = false;

        // Si todos los Pokémon de Player 1 tienen 0 puntos de vida, Player 2 gana
        if (todosSonCeroPlayer1)
        {
            PlayIsOn = false; // El juego termina
            Winner = Player2;
        }

        if (todosSonCeroPlayer2)
        {
            PlayIsOn = false; // El juego termina
            Winner = Player1;
        }
    }
}