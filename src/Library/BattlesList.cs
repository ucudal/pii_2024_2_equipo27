namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa la lista de batallas en curso.
    /// </summary>
    public class BattlesList
    {
        private List<Battle> battles = new List<Battle>();
    
        /// <summary>
        /// Crea una nueva batalla entre dos jugadores.
        /// </summary>
        /// <param name="player1">El primer jugador.</param>
        /// <param name="player2">El oponente.</param>
        /// <returns>La batalla creada.</returns>
        public Battle AddBattle(Player player1, Player player2)
        {
            var battle = new Battle(player1, player2);
            this.battles.Add(battle);
            return battle;
        }

        /// <summary>
        /// Encuentra un jugador por su nombre para una batalla en curso.
        /// </summary>
        /// <param name="displayName">El nombre del jugador.</param>
        /// <returns>El objeto Player si se encuentra; de lo contrario, null.</returns>
        public Player FindPlayerByDisplayName(string displayName)
        {
            foreach (var battle in battles)
            {
                if (battle.Player1.DisplayName == displayName)
                {
                    return battle.Player1;
                }
                else if (battle.Player2.DisplayName == displayName)
                {
                    return battle.Player2;
                }
            }
            return null;
        }
        public Player FindOpponent(string playerDisplayName)
        {
            foreach (var battle in battles)
            {
                if (battle.Player1.DisplayName == playerDisplayName)
                {
                    return battle.Player2;
                }
                else if (battle.Player2.DisplayName == playerDisplayName)
                {
                    return battle.Player1;
                }
            }
            return null;
        }
    }
}