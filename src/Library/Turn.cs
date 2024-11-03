
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

        public Turn(Player player1, Player player2)
        {
            CurrentPlayer = player1;
            WaitingPlayer = player2;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Turn"/> con dos jugadores.
        /// </summary>
        /// <remarks>
        /// <see cref="Player"/> es la clase que representa a un jugador en el juego.
        /// </remarks>
        public Turn(Player player1, Player player2)
        {
            CurrentPlayer = player1;
            WaitingPlayer = player2;
        }

        /// <summary>
        /// Cambia el turno entre el jugador actual y el jugador en espera.
        /// </summary>
        public void ChangeTurn()
        {
            var temp = CurrentPlayer;
            CurrentPlayer = WaitingPlayer;
            WaitingPlayer = temp;
        }

        /// <summary>
        /// Penaliza el turno de un jugador. Si el jugador penalizado es el actual, se cambia el turno.
        /// </summary>
        /// <remarks>
        /// Se debe validar que el parámetro no sea nulo antes de usarlo.
        /// </remarks>
        public void PenalizeTurn(Player player)
        {
            if (player == CurrentPlayer)
            {
                // PenalizedPlayer = CurrentPlayer; // Descomentado si se necesita usar
                ChangeTurn();
            }
            else
            {
                Console.WriteLine($"{player.DisplayName} is not currently playing.");
            }
        }

        /// <summary>
        /// Permite que un jugador ataque a otro Pokémon usando un movimiento.
        /// </summary>
        /// <remarks>
        /// Se debe validar que move, attacker y defender no sean nulos antes de usar.
        /// </remarks>
        public void PlayerAttack(Pokemon attacker, Pokemon defender, Move move)
        {
            double effectiveness = PokemonType.GetEffectiveness(attacker.Type, defender.Type);
            double baseDamage = move.AttackValue;

            // Calcular el daño total con la efectividad.
            double totalDamage = baseDamage * effectiveness;

            defender.HealthPoints -= (int)totalDamage;

            Console.WriteLine($"{attacker.Name} usó {move.Name} y causó {totalDamage} de daño. ¡Es {GetEffectivenessMessage(effectiveness)}!");
        }

        /// <summary>
        /// Obtiene un mensaje sobre la efectividad del ataque.
        /// </summary>
        /// <returns>Un mensaje que describe la efectividad.</returns>
        private static string GetEffectivenessMessage(double effectiveness)
        {
            if (effectiveness > 1.0)
                return "¡súper efectivo!";
            else if (effectiveness < 1.0)
                return "no muy efectivo...";
            return "efectivo.";
        }
    }
}
    