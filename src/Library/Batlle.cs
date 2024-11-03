namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa una batalla entre dos jugadores.
    /// </summary>
    public class Battle
    {
        /// <summary>
        /// Obtiene el primer jugador.
        /// </summary>
        public Player Player1 { get; }
        
        /// <summary>
        /// Obtiene el oponente.
        /// </summary>
        public Player Player2 { get; }
    
        /// <summary>
        /// Inicializa una instancia de la clase <see cref="Battle"/> con los jugadores proporcionados.
        /// </summary>
        /// <param name="player1">El primer jugador.</param>
        /// <param name="player2">El oponente.</param>
        public Battle(Player player1, Player player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
        }
    }
}