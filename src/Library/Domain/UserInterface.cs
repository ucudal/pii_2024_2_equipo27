using System.Collections.ObjectModel;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// La clase <c>UserInterface</c> es responsable de construir y devolver mensajes 
    /// formateados para la interfaz de usuario, proporcionando la información necesaria sobre
    /// el juego, para interactuar con el usuario en el chatbot.
    /// - Principio de Responsabilidad Única (SRP): La clase se encarga exclusivamente de generar y mostrar mensajes
    /// que se utilizan para informar al usuario sobre el estado del juego, manteniéndose concentrada en
    /// esta responsabilidad sin realizar ninguna lógica del juego.
    /// - Expert Pattern (GRASP): Esta clase es la "experta" en formatear y construir mensajes para la interfaz de
    /// usuario, ya que es la única que conoce el formato y contenido de los mensajes que se deben mostrar.
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
            List<Pokemon> pokemonList = pokemons.GetPokemonList();

            StringBuilder catalogo = new StringBuilder();
            catalogo.AppendLine("📜 Catálogo de Pokémon:\n");

            foreach (Pokemon pokemon in pokemonList)
            {
                catalogo.AppendLine($"{pokemon.Name}");
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
        public static string ShowMessageSelectedPokemons(List<Pokemon> selectedPokemons)
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
        public static string ShowMessagePokemonHealth(List<Pokemon> playerPokemons, List<Pokemon> opponentPokemons)
        {
            // Validar que las listas no sean nulas
            if (playerPokemons == null)
            {
                throw new ArgumentNullException(nameof(playerPokemons), "La lista de Pokémon del jugador no puede ser nula.");
            }
            if (opponentPokemons == null)
            {
                throw new ArgumentNullException(nameof(opponentPokemons), "La lista de Pokémon del oponente no puede ser nula.");
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
    }
}
