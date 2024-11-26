namespace ClassLibrary
{
    /// <summary>
    /// Esta clase conoce las especificaciones del turno de un jugador actual con sus correspondientes ataques.
    /// </summary>
    public class Turn
    {
        /// <summary>
        /// Jugador que está actualmente en turno.
        /// </summary>
        public Player CurrentPlayer;

        /// <summary>
        /// Jugador que está esperando su turno.
        /// </summary>
        public Player WaitingPlayer;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Turn"/> con dos jugadores.
        /// </summary>
        /// <remarks>
        /// <see cref="Player"/> es la clase que representa a un jugador en el juego.
        /// </remarks>
        public Turn(Player player1, Player player2)
        {
            if (player1 == null)
            {
                throw new ArgumentNullException(nameof(player1), "El jugador 1 no puede ser nulo.");
            }

            if (player2 == null)
            {
                throw new ArgumentNullException(nameof(player2), "El jugador 2 no puede ser nulo.");
            }

            CurrentPlayer = player1;
            WaitingPlayer = player2;
        }

        /// <summary>
        /// Cambia el turno entre el jugador actual y el jugador en espera.
        /// </summary>
        /// <param name="player"></param>
        public void ChangeTurn()
        {
            // Intercambia los jugadores
            var temp = CurrentPlayer;
            CurrentPlayer = WaitingPlayer;
            WaitingPlayer = temp;

            CurrentPlayer.TurnChanged();
        }
    }
}