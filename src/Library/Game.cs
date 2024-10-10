namespace ClassLibrary
{
    /// <summary>
    /// La clase <c>Game</c> tiene la responsabilidad de conocer a los jugadores y verificar si el juego está activo o ha terminado.
    /// Esto sigue el principio de responsabilidad única (SRP) ya que su única función es gestionar el estado del juego.
    /// Además, según el principio de "experto" (Expert), la clase <c>Game</c> es la más adecuada para gestionar estas tareas, 
    /// ya que contiene toda la información sobre los jugadores y el estado del juego.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Propiedad que almacena al jugador 1 del juego.
        /// La clase <c>Game</c> sigue el principio de "experto" (Expert), ya que tiene la responsabilidad de manejar los jugadores
        /// y su relación dentro del juego.
        /// </summary>
        public Player Player1 { get; }

        /// <summary>
        /// Propiedad que almacena al jugador 2 del juego.
        /// Similar a Player1, sigue el principio de "experto" (Expert) porque la clase <c>Game</c> necesita conocer los jugadores
        /// para controlar el flujo del juego.
        /// </summary>
        public Player Player2 { get; }

        /// <summary>
        /// Propiedad que indica qué jugador tiene el turno en el juego.
        /// Esto facilita la implementación de reglas como el cambio de turno, alineado con el principio de responsabilidad única (SRP).
        /// </summary>
        public Player TurnPlayer { get; set; }  

        /// <summary>
        /// Propiedad que indica si el juego sigue activo (true) o ha terminado (false).
        /// Esto también sigue el SRP, ya que la clase <c>Game</c> es la responsable de gestionar el estado del juego, 
        /// y no otros objetos, respetando el principio de segregación de responsabilidades.
        /// </summary>
        public bool PlayIsOn { get; set; }

        /// <summary>
        /// Constructor de la clase <c>Game</c>. Inicializa los jugadores y el estado del juego.
        /// El constructor asigna las propiedades adecuadamente siguiendo el principio de Liskov Substitution Principle (LSP),
        /// lo cual permite que cualquier clase derivada de <c>Player</c> funcione correctamente en la lógica del juego.
        /// </summary>
        /// <param name="player1">El primer jugador.</param>
        /// <param name="player2">El segundo jugador.</param>
        public Game(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
            TurnPlayer = player1; // El jugador 1 comienza con el turno
            PlayIsOn = true;      // El juego inicia en estado activo
        }

        /// <summary>
        /// Verifica si el juego debe terminar revisando si todos los Pokémon de alguno de los jugadores tienen 0 puntos de vida.
        /// Si un jugador pierde todos sus Pokémon, el juego termina y se declara un ganador.
        /// Este método puede ser fácilmente extendido o modificado con otras reglas de fin de juego, 
        /// alineado con el principio de Polimorfismo, donde nuevas reglas de finalización pueden ser añadidas sin alterar la estructura básica.
        /// </summary>
        public void CheckIfGameEnds()
        {
            // Verificamos si todos los Pokémon del jugador 1 tienen 0 puntos de vida
            bool todosSonCeroPlayer1 = Player1.AvailablePokemons.All(pokemon => pokemon.HealthPoints == 0);
            
            // Verificamos si todos los Pokémon del jugador 2 tienen 0 puntos de vida
            bool todosSonCeroPlayer2 = Player2.AvailablePokemons.All(pokemon => pokemon.HealthPoints == 0);

            // Si todos los Pokémon de Player 1 tienen 0 puntos de vida, Player 2 gana
            if (todosSonCeroPlayer1)
            {
                Console.WriteLine("¡Ha ganado Player 2!");
                PlayIsOn = false;  // El juego termina
            }
            // Si todos los Pokémon de Player 2 tienen 0 puntos de vida, Player 1 gana
            else if (todosSonCeroPlayer2)
            {
                Console.WriteLine("¡Ha ganado Player 1!");
                PlayIsOn = false;  // El juego termina
            }
        }
    }
}