namespace ClassLibrary
{
    /// <summary>
    /// La clase <c>Facade</c> actúa como una interfaz simplificada para interactuar con el juego,
    /// permitiendo a los jugadores elegir Pokémon, mostrar movimientos, activar ataques y obtener información sobre la salud de los Pokémon.
    /// </summary>
    public class Facade
    {
        private WaitingList WaitingList { get; }
        private GameList GameList { get; }
        private UserInterface UserInterface { get;  }
        
        private static Facade? _instance;

        // Este constructor privado impide que otras clases puedan crear instancias de esta.
        private Facade()
        {
            this.WaitingList = new WaitingList();
            this.GameList = new GameList();
            this.UserInterface = new UserInterface();
        }
        
        /// <summary>
        /// Obtiene la única instancia de la clase <see cref="Facade"/>.
        /// </summary>
        public static Facade Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Facade();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Inicializa este singleton. Es necesario solo en los tests.
        /// </summary>
        public static void Reset()
        {
            _instance = null;
        }
        

        //HISTORIA DE USUARIO 1
        public string ShowPokemonCatalog()
        {
            return UserInterface.ShowMessagePokemonCatalog();
        }

        public string ChoosePokemons(string playerDisplayName, string[] pokemonNames)
        {
            Player player = this.GameList.FindPlayerByDisplayName(playerDisplayName);
            if (player == null)
            {
                return $"El jugador {playerDisplayName} no está jugando";
            }

            List<string> result = new List<string>
            {
                $"Pokémons seleccionados por el jugador {playerDisplayName}."
            };
            PokemonCatalog catalog = new PokemonCatalog();

            foreach (string pokemonName in pokemonNames)
            {
                Pokemon pokemon = catalog.FindPokemonByName(pokemonName);
                player.AddPokemon(pokemon);
            }

            return string.Join(",", result);
        }

        //HISTORIA DE USUARIO 2

        /// <summary>
        /// Muestra los movimientos disponibles de los Pokémon del jugador seleccionado.
        /// </summary>
        /// <param name="playerDisplayName">El nombre del jugador.</param>
        /// <returns>Una lista de cadenas con los Pokémon y sus movimientos.</returns>
        public List<string> ShowMoves(string playerDisplayName)
        {
            Player player = this.GameList.FindPlayerByDisplayName(playerDisplayName);
            if (player == null)
            {
                return new List<string> { $"El jugador {playerDisplayName} no está jugando" };
            }

            List<string> pokemonsWithMoves = new List<string>();

            foreach (Pokemon pokemon in player.AvailablePokemons)
            {
                List<string> movesList = new List<string>();

                foreach (Move move in pokemon.Moves)
                {
                    movesList.Add(move.Name);
                }

                movesList.Add(pokemon.SpecialMove.Name);

                string pokemonMoves = $"{pokemon.Name}: {string.Join(", ", movesList)}";

                pokemonsWithMoves.Add(pokemonMoves);
            }

            return pokemonsWithMoves;
        }

        /// <summary>
        /// Permite a un jugador seleccionar un Pokémon y un movimiento para atacar.
        /// </summary>
        /// <param name="playerDisplayName">El nombre del jugador.</param>
        /// <param name="moveName">El nombre del movimiento a utilizar.</param>
        /// <param name="pokemonName">El nombre del Pokémon que realizará el ataque.</param>
        public void ChoosePokemonAndMoveToAttack(string playerDisplayName, string moveName, string pokemonName)
        {
            Player player = this.GameList.FindPlayerByDisplayName(playerDisplayName);
            if (player == null)
            {
                throw new Exception($"El jugador {playerDisplayName} no está jugando");
            }

            int pokemonIndex = player.GetIndexOfPokemon(pokemonName);
            if (pokemonIndex < 0)
            {
                throw new Exception($"El Pokémon {pokemonName} no está disponible para el jugador {playerDisplayName}");
            }
            player.ActivatePokemon(pokemonIndex);

            if (moveName == player.ActivePokemon.SpecialMove.Name)
            {
                player.ActivateSpecialMove(moveName);
            }
            else
            {
                int moveIndex = player.GetIndexOfMoveInActivePokemon(moveName);
                if (moveIndex < 0)
                {
                    throw new Exception($"El movimiento {moveName} no está disponible para el Pokémon {pokemonName}");
                }
                player.ActivateMoveInActivePokemon(moveIndex);
            }
        }

        //HISTORIA DE USUARIO 3

        /// <summary>
        /// Obtiene la salud de los Pokémon de un jugador en comparación con el oponente.
        /// </summary>
        /// <param name="playerDisplayName">El nombre del jugador.</param>
        /// <returns>Una lista de cadenas que muestra la salud de los Pokémon del jugador y del oponente.</returns>
        public List<string> GetPokemonsHealth(string playerDisplayName)
        {
            Player player = this.GameList.FindPlayerByDisplayName(playerDisplayName);
            if (player == null)
            {
                return new List<string> { $"El jugador {playerDisplayName} no está jugando" };
            }

            Player opponent = this.GameList.FindOpponent(playerDisplayName);
            if (opponent == null)
            {
                return new List<string> { $"No se encontró el oponente del jugador {playerDisplayName}" };
            }

            UserInterface userInterface = new UserInterface();

            return userInterface.ShowMessagePokemonHealth(player.AvailablePokemons, opponent.AvailablePokemons);
        }

        //HISTORIA DE USUARIO 4
        
        
        //HISTORIA DE USUARIO 5
        
        
        //HISTORIA DE USUARIO 6
        

        //HISTORIA DE USUARIO 7

        public string ChangePokemon(string playerDisplayName, string newPokemonName)
        {
            Player player = this.GameList.FindPlayerByDisplayName(playerDisplayName);
            if (player == null)
            {
                return $"El jugador {playerDisplayName} no está jugando";
            }

            int pokemonIndex = player.GetIndexOfPokemon(newPokemonName);
            if (pokemonIndex < 0)
            {
                return $"El Pokémon {newPokemonName} no está disponible para el jugador {playerDisplayName}";
            }
            player.ActivatePokemon(pokemonIndex);

            // Aquí debes manejar el cambio de turno y verificar si el juego termina
            // Por ejemplo:
            // game.TurnPlayer = game.TurnPlayer == game.Player1 ? game.Player2 : game.Player1;
            // game.CheckIfGameEnds();

            return $"{player.DisplayName} cambió a {player.ActivePokemon.Name} y perdió su turno";
        }

        //HISTORIA DE USUARIO 8

        //HISTORIA DE USUARIO 9

        /// <summary>
        /// Agrega un jugador a la lista de espera.
        /// </summary>
        /// <param name="displayName">El nombre del jugador.</param>
        /// <returns>Un mensaje con el resultado.</returns>
        public string AddPlayerToWaitingList(string displayName)
        {
            if (this.WaitingList.AddPlayer(displayName))
            {
                return $"{displayName} agregado a la lista de espera";
            }

            return $"{displayName} ya está en la lista de espera";
        }

        /// <summary>
        /// Remueve un jugador de la lista de espera.
        /// </summary>
        /// <param name="displayName">El jugador a remover.</param>
        /// <returns>Un mensaje con el resultado.</returns>
        
        public string RemovePlayerFromWaitingList(string displayName)
        {
            if (this.WaitingList.RemovePlayer(displayName))
            {
                return $"{displayName} removido de la lista de espera";
            }
            else
            {
                return $"{displayName} no está en la lista de espera";
            }
        }

        //HISTORIA DE USUARIO 10

        /// <summary>
        /// Obtiene la lista de jugadores esperando.
        /// </summary>
        /// <returns>Un mensaje con el resultado.</returns>
        public string GetAllPlayersWaiting()
        {
            if (this.WaitingList.Count == 0)
            {
                return "No hay nadie esperando";
            }

            string result = "Esperan: ";
            foreach (Player player in this.WaitingList.GetAllWaiting())
            {
                result = result + player.DisplayName + "; ";
            }

            return result;
        }

        /// <summary>
        /// Determina si un jugador está esperando para jugar.
        /// </summary>
        /// <param name="displayName">El jugador.</param>
        /// <returns>Un mensaje con el resultado.</returns>
        public string PlayerIsWaiting(string displayName)
        {
            Player? player = this.WaitingList.FindPlayerByDisplayName(displayName);
            if (player == null)
            {
                return $"{displayName} no está esperando";
            }

            return $"{displayName} está esperando";
        }

        //HISTORIA DE USUARIO 11

        private string CreateBattle(string playerDisplayName, string opponentDisplayName)
        {
            Player player1 = new Player(playerDisplayName);
            Player player2 = new Player(opponentDisplayName);

            this.WaitingList.RemovePlayer(playerDisplayName);
            this.WaitingList.RemovePlayer(opponentDisplayName);

            this.GameList.AddGame(player1, player2);
            return $"Comienza {playerDisplayName} vs {opponentDisplayName}";
        }

        /// <summary>
        /// Crea una batalla entre dos jugadores.
        /// </summary>
        /// <param name="playerDisplayName">El primer jugador.</param>
        /// <param name="opponentDisplayName">El oponente.</param>
        /// <returns>Un mensaje con el resultado.</returns>
        public string StartBattle(string playerDisplayName, string? opponentDisplayName)
        {
            Player? opponent;

            if (!OpponentProvided() && !SomebodyIsWaiting())
            {
                return "No hay nadie esperando";
            }

            if (!OpponentProvided())
            {
                opponent = this.WaitingList.GetAnyoneWaiting();
                return this.CreateBattle(playerDisplayName, opponent!.DisplayName);
            }

            opponent = this.WaitingList.FindPlayerByDisplayName(opponentDisplayName!);

            if (!OpponentFound())
            {
                return $"{opponentDisplayName} no está esperando";
            }

            return this.CreateBattle(playerDisplayName, opponent!.DisplayName);

            // Funciones locales a continuación para mejorar la legibilidad

            bool OpponentProvided()
            {
                return !string.IsNullOrEmpty(opponentDisplayName);
            }

            bool SomebodyIsWaiting()
            {
                return this.WaitingList.Count != 0;
            }

            bool OpponentFound()
            {
                return opponent != null;
            }
        }
    }
}

