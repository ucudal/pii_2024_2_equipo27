namespace ClassLibrary;

/// <summary>
///  La clase <c>Game</c> aplica principios GRASP y SOLID para asegurar un diseño robusto y cohesivo. Sigue el principio de responsabilidad
/// única (SRP) al encargarse exclusivamente de gestionar el estado del juego, respetando también el principio GRASP de "experto", ya
/// que toma decisiones basadas en la información que posee, como verificar el fin del juego y determinar el ganador. Además, delega la
/// gestión de turnos a la clase <c>Turn</c>, alineándose con el principio abierto/cerrado (OCP), lo que facilita futuras extensiones sin modificar
/// la clase base. Su diseño encapsula correctamente propiedades críticas como <c>PlayIsOn</c> y <c>Winner</c>, garantizando la integridad del estado del objeto.
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
        // Verificar que los jugadores tengan Pokémon seleccionados
        if (Player1.AvailablePokemons == null || Player2.AvailablePokemons == null)
        {
            throw new ArgumentNullException("Los jugadores deben tener a sus Pokémon seleccionados");
        }

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
        if (todosSonCeroPlayer1 && todosSonCeroPlayer2)
        {
            PlayIsOn = false; // El juego termina en empate
            Winner = null; // Sin ganador
        }
        else if (todosSonCeroPlayer1)
        {
            PlayIsOn = false; // El juego termina
            Winner = Player2;
        }
        else if (todosSonCeroPlayer2)
        {
            PlayIsOn = false; // El juego termina
            Winner = Player1;
        }
    }

    /// <summary>
    /// Verifica que jugador tiene ventaja en cualquier momento de la partida.
    /// Este método está en Game, porque la clase tiene la responsabilidad de conocer a los dos jugadores enfrentados, y por lo tanto
    /// puede conocer cuál de los dos está ganando. Esta clase es experta en el estado del juego y sus componentes.
    /// <returns> El jugador que va ganando o null si hay un empate. </returns>
    /// </summary>
    public Player CheckWhoIsWinning()
    {
        // Verificar que los jugadores tengan Pokémon seleccionados
        if (Player1.AvailablePokemons == null || Player2.AvailablePokemons == null)
        {
            throw new ArgumentNullException("Los jugadores deben tener a sus Pokémon seleccionados");
        }

        double totalHealthPlayer1 = Player1.GetHealthPercentageSum();
        double totalHealthPlayer2 = Player2.GetHealthPercentageSum();

        // Si todos los Pokémon de Player 1 tienen 0 puntos de vida, Player 2 gana
        if (totalHealthPlayer1 > totalHealthPlayer2)
        {
            return Player1;
        }

        if (totalHealthPlayer2 > totalHealthPlayer1)
        {
            return Player2;
        }

        return null;
    }
}