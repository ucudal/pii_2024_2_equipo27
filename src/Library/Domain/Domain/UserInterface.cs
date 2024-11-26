using System.Collections.ObjectModel;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// La clase <c>UserInterface</c> es responsable de construir y devolver mensajes 
    /// formateados para la interfaz de usuario, proporcionando la información necesaria sobre
    /// el juego, para interactuar con el usuario en el chatbot.
    /// La clase se encarga exclusivamente de generar y mostrar mensajes que se utilizan para
    /// informar al usuario sobre el estado del juego, manteniéndose concentrada en esta responsabilidad
    /// sin realizar ninguna lógica del juego, por lo que cumple con el patrón de Responsabilidad Única(SRP)
    /// También esta clase es la "experta" en formatear y construir mensajes para la interfaz de
    /// usuario, ya que es la única que conoce el formato y contenido de los mensajes que se deben mostrar,
    /// por lo que sigue el patrón Expert.
    /// </summary>
    public class UserInterface
    {
        /// <summary>
        /// Genera un mensaje con el catálogo de todos los Pokémon disponibles.
        /// </summary>
        /// <returns>Una cadena con el catálogo de nombres de Pokémon.</returns>
        public static string ShowMessagePokemonCatalog()
        {
            PokemonCatalogBuilder pokemons = new PokemonCatalogBuilder();

            StringBuilder catalogo = new StringBuilder();
            catalogo.AppendLine("📜 Catálogo de Pokémon:\n");

            foreach (Pokemon pokemon in pokemons.PokemonList)
            {
                catalogo.AppendLine($"{pokemon.Name}:");
                foreach (Move move in pokemon.Moves)
                {
                    catalogo.AppendLine($"   -{move.Name}: attackvalue {move.AttackValue}, accuracy {move.Accuracy} , type {move.MoveType}");
                }
            }

            return catalogo.ToString();
        }

        /// <summary>
        /// Genera un mensaje indicando el número del Pokémon a seleccionar o informa que ya se han seleccionado los 6 Pokémon.
        /// </summary>
        /// <param name="currentSelection">El índice actual de selección de Pokémon.</param>
        /// <returns>Un mensaje indicando el número de selección de Pokémon o que ya se completó la selección.</returns>
        public static string ShowMessageToAddPokemons(int currentSelection)
        {
            if (currentSelection < 6)
            {
                return $"Selecciona el Pokémon número {currentSelection + 1}:";
            }
            else
            {
                return "Ya has seleccionado 6 Pokémon.";
            }
        }

        /// <summary>
        /// Genera un mensaje con la lista de Pokémon seleccionados por el jugador.
        /// </summary>
        /// <param name="selectedPokemons">Lista de Pokémon seleccionados.</param>
        /// <returns>Un mensaje con los nombres de los Pokémon seleccionados.</returns>
        public static string ShowMessageSelectedPokemons(ReadOnlyCollection<Pokemon> selectedPokemons)
        {
            string selectedList = "⭐️ Pokémon seleccionados:\n";

            foreach (Pokemon pokemon in selectedPokemons)
            {
                selectedList += $"- {pokemon.Name}\n";
            }

            return selectedList;
        }

        /// <summary>
        /// Genera un mensaje con la información de salud de los Pokémon del jugador y del oponente.
        /// </summary>
        /// <param name="playerPokemons">Lista de Pokémon del jugador.</param>
        /// <param name="opponentPokemons">Lista de Pokémon del oponente.</param>
        /// <returns>Una cadena con la información de salud de los Pokémon.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si alguna de las listas es nula.</exception>
        public static string ShowMessagePokemonHealth(ReadOnlyCollection<Pokemon> playerPokemons, ReadOnlyCollection<Pokemon> opponentPokemons)
        {
            // Validar que las listas no sean nulas
            if (playerPokemons == null)
            {
                throw new ArgumentNullException(nameof(playerPokemons),
                    "La lista de Pokémon del jugador no puede ser nula.");
            }

            if (opponentPokemons == null)
            {
                throw new ArgumentNullException(nameof(opponentPokemons),
                    "La lista de Pokémon del oponente no puede ser nula.");
            }

            // Usar StringBuilder para construir la cadena de manera eficiente
            StringBuilder healthInfo = new StringBuilder();
            healthInfo.AppendLine("💓 Salud de los Pokémon:");
            healthInfo.AppendLine("Pokémon propios:");
            foreach (Pokemon pokemon in playerPokemons)
            {
                healthInfo.AppendLine($"{pokemon.Name}: {pokemon.HealthPoints}/100 HP");
            }

            healthInfo.AppendLine("Pokémon oponentes:");
            foreach (Pokemon pokemon in opponentPokemons)
            {
                healthInfo.AppendLine($"{pokemon.Name}: {pokemon.HealthPoints}/100 HP");
            }

            return healthInfo.ToString();
        }

        /// <summary>
        /// Genera un mensaje indicando que el jugador ha cambiado su Pokémon activo y ha perdido su turno.
        /// </summary>
        /// <param name="playerDisplayName">Nombre del jugador que realizó el cambio de Pokémon.</param>
        /// <param name="newPokemonName">Nombre del nuevo Pokémon activado.</param>
        /// <returns>Mensaje formateado indicando el cambio de Pokémon y la pérdida de turno.</returns>
        public static string ShowMessageChangePokemon(string playerDisplayName, string newPokemonName)
        {
            return $"{playerDisplayName} cambió a {newPokemonName} y perdió su turno";
        }

        /// <summary>
        /// Genera un mensaje indicando que no hay jugadores en la lista de espera.
        /// </summary>
        /// <returns>Mensaje indicando que no hay nadie esperando.</returns>
        public static string ShowMessageNoPlayersWaiting()
        {
            return "No hay nadie esperando";
        }

        /// <summary>
        /// Genera un mensaje listando los nombres de los jugadores en la lista de espera.
        /// </summary>
        /// <param name="waitingPlayers">Lista de jugadores en espera.</param>
        /// <returns>Un mensaje con los nombres de los jugadores en espera.</returns>
        public static string ShowMessagePlayersWaiting(ReadOnlyCollection<Player> waitingPlayers)
        {
            StringBuilder result = new StringBuilder("Esperan: ");
            foreach (Player player in waitingPlayers)
            {
                result.AppendLine($"{player.DisplayName}");
            }

            return result.ToString();
        }

        public string AddPlayerToWaitingList(string displayName)
        {
            if (displayName == displayName)
            {
                return $"{displayName} ya está en la lista de espera";
            }

            return displayName;
        }

        public static string ShowBattleEndMessage(string playerName)
        {
            return $"{playerName} ha ganado la batalla";
        }
        
        public static string ShowBattleContinuesMessage(Player turnPlayer)
        {
            return $"El juego continúa, es el turno de {turnPlayer.DisplayName}.";
        }

        public static string ShowMessageCurrentTurnPlayer(string currentPlayerDisplayName)
        {
            return $"🎮 Es el turno de {currentPlayerDisplayName}.";
        }

        /// <summary>
        /// Muestra un mensaje indicando que un ataque ha ocurrido, con detalles sobre el atacante, el defensor y el movimiento usado.
        /// </summary>
        /// <param name="attackingPokemon">El Pokémon que está atacando.</param>
        /// <param name="defendingPokemon">El Pokémon que está siendo atacado.</param>
        /// <param name="attacker">El jugador que controla al Pokémon atacante.</param>
        /// <param name="defender">El jugador que controla al Pokémon defensor.</param>
        /// <returns>Un mensaje formateado indicando que el ataque ocurrió.</returns>
        public static string ShowMessageAttackOcurred(Pokemon attackingPokemon, Pokemon defendingPokemon,
            Player attacker, Player defender, int healthPointsBefore, int healthPointsAfter)
        {
            return
                $" Jugador {attacker.DisplayName} usa al Pokémon {attackingPokemon.Name} que ataca con {attacker.ActiveMove.Name} a {defendingPokemon.Name} de {defender.DisplayName}, HP pasa de {healthPointsBefore} a {healthPointsAfter}";
        }

        /// <summary>
        /// Muestra un mensaje indicando que el ataque no ocurrió, debido a que el Pokémon del jugador tiene un ataque especial activo que lo impide.
        /// </summary>
        /// <param name="attacker">El jugador que intenta realizar el ataque.</param>
        /// <param name="attackingPokemon">El Pokémon que está intentando atacar.</param>
        /// <returns>Un mensaje formateado indicando que el ataque no ocurrió debido a un movimiento especial activo.</returns>
        public static string ShowMessageAttackDidNotOccur(Player attacker, Pokemon attackingPokemon)
        {
            return
                $"$ El jugador {attacker} no puede jugar porque su Pokémon {attackingPokemon} tiene un ataque especial activo que no lo permite";
        }

        /// <summary>
        /// Muestra un mensaje que la efectividad del ataque fue alta.
        /// </summary>
        /// <param name="attacker">El jugador que intenta realizar el ataque.</param>
        /// <param name="attackingPokemon">El Pokémon que está intentando atacar.</param>
        /// <returns>Un mensaje formateado indicando la efectividad.</returns>
        public static String ShowMessageHighEffectiveness(Double accuaracyAttack)
        {
            return $"$ La efectividad del ataque es alta:  {accuaracyAttack} ";
        }

        /// <summary>
        /// Muestra un mensaje indicando que la efectividad del mensaje fue baja.
        /// </summary>
        /// <param name="attacker">El jugador que intenta realizar el ataque.</param>
        /// <param name="attackingPokemon">El Pokémon que está intentando atacar.</param>
        /// <returns>Un mensaje formateado indicando la efectividad.</returns>
        public static string ShowMessageLowEffectiveness(double accuaracyAttack)
        {
            return $"$ La efectividad del ataque es baja: {accuaracyAttack} ";
        }

        /// <summary>
        /// Retorna un mensaje con todos los comandos disponibles y las reglas del juego.
        /// </summary>
        public static string ShowMessageHelp()
        {
            var helpMessage = new StringBuilder();
            
            // Reglas del juego
            helpMessage.AppendLine("\n=== Instrucciones del Juego ===")
                .AppendLine("1. Cada jugador debe unirse a la lista de espera con !join, para salir de la misma se usa !leave.")
                .AppendLine("2. Usa !waiting para ver los jugadores que están esperando")
                .AppendLine("3. Usa !battle {username} para comenzar una batalla (el username es opcional).")
                .AppendLine("4. Antes de la batalla, usa !catalog para ver los Pokémon disponibles.")
                .AppendLine("5. Selecciona seis Pokémon con !choose {pokemon1 pokemon2 pokemon3 pokemon4 pokemon5 pokemon6}. Asegúrate de separar los Pokémon con espacios.")
                .AppendLine("6. El juego elige aleatoriamente quién comienza.")
                .AppendLine("7. Se pueden ver los movimientos disponibles de tu Pokémon activo con !moves.")
                .AppendLine("8. Se pueden ver los items disponibles y su cantidad con !items")
                .AppendLine("8. Se enfrentan los primeros Pokémon vivos de cada jugador.")
                .AppendLine("9. Usa !turn para verificar de quién es el turno.")
                .AppendLine("10. En tu turno, puedes realizar una de las siguientes acciones:")
                .AppendLine("   - Usar un ataque con !attack {move} seleccionando un movimiento que tenga tu pokémon.")
                .AppendLine("   - Cambiar de Pokémon con !change {pokemon}")
                .AppendLine("   - Usar un ítem con !useitem {item}.")
                .AppendLine("11. Usa !hp para consultar los HP de tus Pokémon y los del oponente.")
                .AppendLine("12. La batalla termina cuando todos los Pokémon de un jugador llegan a 0 HP.")
                .AppendLine("\n !help: Muestra los comandos disponibles y las instrucciones de juego.")
                .AppendLine("!rules: Muestra las reglas del juego.");

            return helpMessage.ToString();

        }

        public static string ShowMessageRules()
        {
            var helpMessage = new StringBuilder();

            // Cómo funciona un ataque 
            helpMessage.AppendLine("\n=== Cómo Funciona el Ataque ===")
                .AppendLine("1. Usa !attack {move} para atacar con el movimiento seleccionado del Pokémon activo.")
                .AppendLine("2. Los ataques tienen diferentes niveles de efectividad según los tipos de Pokémon (fuego, agua, planta, etc.).")
                .AppendLine("3. Los ataques especiales pueden usarse cada dos turnos y tienen efectos adicionales:")
                .AppendLine("   - Sleep: El Pokémon queda inactivo entre 1 y 4 turnos, sin poder atacar.")
                .AppendLine("   - Paralize: El Pokémon tiene una probabilidad de fallar su turno de manera aleatoria.")
                .AppendLine("   - Poison: El Pokémon pierde el 5% de su HP cada turno.")
                .AppendLine("   - Burn: El Pokémon pierde el 10% de su HP cada turno.")
                .AppendLine("4. Que se produzca un ataque o no depende de su valor de precisión y es aleatorio.")
                .AppendLine("5. El daño infligido por los ataques depende de si es un golpe crítico")
                .AppendLine("   - Un golpe crítico aumenta el daño en un 20% y tiene una probabilidad del 10%.")
                .AppendLine("5. Si un pokemon alcanza 0 HP, el pokemon actual de un jugador pasa al siguiente Pokémon en la lista.");

            // Cómo funcionan los Ítems
            helpMessage.AppendLine("\n=== Cómo Funcionan los Ítems ===")
                .AppendLine("1. Usa !useitem {item} para aplicar un efecto durante tu turno.")
                .AppendLine("2. Los ítems pueden:")
                .AppendLine("   - Revive: Revive a un Pokémon con el 50% de su HP total. (Cada jugador tiene 1)" )
                .AppendLine("   - FullHeal: Elimina efectos de estados especiales como parálisis, dormir, envenenamiento o quemaduras.(Cada jugador tiene 2)")
                .AppendLine("   - SuperPotion: Restaura 70 puntos de HP. (Cada jugador tiene 4)")
                .AppendLine("3. Usar un ítem consume tu turno actual.");

            return helpMessage.ToString();
        }

        /// <summary>
        /// Devuelve un string que muestra los movimientos de los Pokémon de forma detallada.
        /// </summary>
        public static string ReturnShowMoves(IReadOnlyList <Move> moves, Player player)
        {
            if (player == null)
            {
                return "El jugador no está definido.";
            }

            if (player.ActivePokemon == null)
            {
                return $"El jugador {player.DisplayName} no tiene un Pokémon activo.";
            }

            if (moves == null || moves.Count == 0)
            {
                return $"El Pokémon activo de {player.DisplayName} no tiene movimientos disponibles.";
            }

            var movesMessage = new StringBuilder();
            movesMessage.AppendLine("\n=== Lista de Movimientos ===");

            foreach (var move in moves)
            {
                movesMessage.AppendLine($"- {move.Name} (Precisión: {move.Accuracy})");
            }

            return movesMessage.ToString();
        }

    }
}

