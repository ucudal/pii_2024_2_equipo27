namespace ClassLibrary
{
    // Esta clase conoce las especificaciones del turno de un jugador actual con sus correspondientes ataques
    public class Turn
    {
        public Player CurrentPlayer;
        public Player WaitingPlayer;
        public Player PenalizedPlayer;

        public Turn(Player player1, Player player2)
        {
            CurrentPlayer = player1;
            WaitingPlayer = player2;
        }

        public void ChangeTurn()
        {
            var temp = CurrentPlayer;
            CurrentPlayer = WaitingPlayer;
            WaitingPlayer = temp;
        }

        public void PenalizeTurn(Player player) // Validar que el parámetro 'player' no sea nulo antes de usarlo
        {
            if (player == null)
            {
                Console.WriteLine("El jugador proporcionado es nulo.");
                return;
            }

            if (player == CurrentPlayer)
            {
                PenalizedPlayer = CurrentPlayer;
                ChangeTurn();
                Console.WriteLine($"{PenalizedPlayer.DisplayName} ha perdido su turno.");
            }
            else
            {
                Console.WriteLine($"{player.DisplayName} no está jugando actualmente.");
            }
        }

        public void PlayerAttack(Pokemon attacker, Pokemon defender, Move move) // Validar que 'move', 'attacker', 'defender' no sean nulos antes de usarlo
        {
            if (attacker == null || defender == null || move == null)
            {
                Console.WriteLine("Atacante, defensor o movimiento no pueden ser nulos.");
                return;
            }

            double effectiveness = PokemonType.GetEffectiveness(attacker.Type, defender.Type);
            double baseDamage = move.AttackValue; 
            
            // Calcular el daño total con la efectividad.
            double totalDamage = baseDamage * effectiveness;

            defender.HealthPoints -= (int)totalDamage;

            Console.WriteLine($"{attacker.Name} usó {move.Name} y causó {totalDamage} de daño. ¡Es {GetEffectivenessMessage(effectiveness)}!");
        }

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
