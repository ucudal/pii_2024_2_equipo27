namespace ClassLibrary
{
    /// <summary>
    /// La clase  <c>Facade</c> proporciona una interfaz simplificada para interactuar con el juego, permitiendo a los jugadores seleccionar
    /// Pokémon, mostrar movimientos, activar ataques y consultar la salud de los Pokémon. Aplica el Patrón de Diseño Facade,
    /// que oculta la complejidad del sistema y simplifica la interacción con múltiples subsistemas, mejorando la usabilidad.
    /// Esta clase sigue el Principio de Responsabilidad Única (SRP) al concentrar la lógica de interacción en un solo lugar,
    /// lo que facilita el mantenimiento y la evolución del sistema. Además, respeta el Principio de Inversión de Dependencias (DIP)
    /// al depender de abstracciones, permitiendo una mayor flexibilidad y una mejor capacidad de prueba. Esta estructura permite a los
    /// desarrolladores y jugadores interactuar con el juego de manera más intuitiva, minimizando la necesidad de conocer la
    /// implementación interna.
    /// </summary>
    public class Facade
    {
        private WaitingList WaitingList { get; }
        public GameList GameList { get; }
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
        /// Obtiene la salud de los Pokémon de un jugador y su oponente, formateada en una cadena.
        /// </summary>
        /// <param name="playerDisplayName">El nombre del jugador del cual se obtendrá la salud de los Pokémon.</param>
        /// <returns>Una cadena que contiene la información de la salud de los Pokémon del jugador y su oponente.</returns>
        /// <exception cref="ArgumentException">Se lanza si el jugador o el oponente no se encuentran.</exception>
        public string GetPokemonsHealth(string playerDisplayName)
        {
            // Busca al jugador por su nombre para obtener sus Pokémon.
            Player player = this.GameList.FindPlayerByDisplayName(playerDisplayName);
            if (player == null)
            {
                throw new ArgumentException($"El jugador {playerDisplayName} no está jugando.");
            }

            // Busca al oponente del jugador para obtener sus Pokémon.
            Player opponent = this.GameList.FindOpponent(playerDisplayName);
            if (opponent == null)
            {
                throw new ArgumentException($"No se encontró el oponente del jugador {playerDisplayName}.");
            }

            // Devuelve la cadena formateada con la salud de los Pokémon de ambos jugadores.
            return UserInterface.ShowMessagePokemonHealth(player.AvailablePokemons, opponent.AvailablePokemons);
        }
        
        //HISTORIA DE USUARIO 4
        /// <summary>
        /// Realiza un ataque en el turno del jugador, aplicando el daño basado en la efectividad del tipo.
        /// </summary>
        /// <param name="playerDisplayName">El jugador que realiza el ataque.</param>
        /// <param name="opponentDisplayName">El jugador que recibe el ataque.</param>
        /// <param name="moveName">El movimiento seleccionado para el ataque.</param>
        //public void PlayerAttack(Pokemon playerDisplayName, Pokemon opponentDisplayName, Move moveName)
        public string PlayerAttack(string playerDisplayName, string moveName)
        {
            if (playerDisplayName == null || moveName == null)
            {
                throw new ArgumentException("Datos inválidos para el ataque.");
            }

            Game game = GameList.FindGame(playerDisplayName);

            Pokemon attackingPokemon = game.TurnPlayer.ActivePokemon;
            Move move = attackingPokemon.GetMoveByName(moveName);
            Pokemon defendingPokemon = game.TurnPlayer.GetOpponent().ActivePokemon;

            // Calcula la efectividad del tipo
            double typeEffectiveness = PokemonType.GetEffectiveness(attackingPokemon.Type, defendingPokemon.Type);

            // Calcula el daño basado en la efectividad
            int baseDamage = move.AttackValue;
            int calculatedDamage = (int)(baseDamage * typeEffectiveness);

            // Aplica el daño al Pokémon defensor
            defendingPokemon.HealthPoints-= (int)calculatedDamage;

          // Console.WriteLine($"{playerDisplayName.Name} ataca con {moveName.Name}!");
          // Console.WriteLine($"{opponentDisplayName.Name} recibe {calculatedDamage} de daño! (Efectividad: {typeEffectiveness})");
          string message = $"{defendingPokemon.Name} recibe {calculatedDamage} de daño! (Efectividad: {typeEffectiveness})";
          game.CheckIfGameEnds();
          if (!game.PlayIsOn)
          {
              message += UserInterface.ShowBattleEndMessage(playerDisplayName);
          }

          return message;
        }
        
        
        
        //HISTORIA DE USUARIO 5
        
        
        //HISTORIA DE USUARIO 6
        /// <summary>
        /// Finaliza la batalla y muestra un mensaje indicando si el juego ha terminado o si la batalla sigue en curso.
        /// Verifica el estado de los Pokémon disponibles del jugador y maneja el flujo de finalización de la batalla.
        /// </summary>
        /// <param name="userInterface">La instancia de la interfaz de usuario que muestra los mensajes al jugador.</param>
        /// <param name="game">El objeto del juego que contiene la lógica para determinar si la batalla ha terminado.</param>
        /// <param name="player">El jugador que está participando en la batalla.</param>
        /// <param name="playerDisplayName">El nombre para mostrar del jugador, usado para personalizar los mensajes.</param>
        /// <returns>Un mensaje que indica si la batalla ha terminado o si la batalla continúa.</returns>
        /// <exception cref="ArgumentException">Se lanza si la batalla continúa y el jugador tiene solo un Pokémon disponible.</exception>
        public string EndGame(UserInterface userInterface, Game game, Player player, string playerDisplayName)
        {
            // Verifica si el juego ha terminado (puede modificar estados internos del juego)
            game.CheckIfGameEnds();

            // Si el jugador no tiene Pokémon disponibles, termina la batalla y muestra el mensaje de fin de la batalla
            if (player.AvailablePokemons.Count == 0)
            {
                return UserInterface.ShowBattleEndMessage(playerDisplayName);
            }
            // Si el jugador tiene solo un Pokémon disponible, la batalla no ha terminado
            else if (player.AvailablePokemons.Count == 1)
            {
                throw new ArgumentException($"La batalla continúa.");
            }

            return null;
        }



        //HISTORIA DE USUARIO 7

        /// <summary>
        /// Cambia el Pokémon activo del jugador al especificado por <paramref name="newPokemonName"/> y pierde su turno.
        /// </summary>
        /// <param name="playerDisplayName">Nombre del jugador que quiere cambiar de Pokémon.</param>
        /// <param name="newPokemonName">Nombre del nuevo Pokémon a activar.</param>
        /// <returns>Un mensaje formateado indicando el cambio de Pokémon y la pérdida de turno.</returns>
        /// <exception cref="ArgumentException">Se lanza si el jugador no está en la partida o si el Pokémon no está disponible.</exception>
        public string ChangePokemon(string playerDisplayName, string newPokemonName)
        {
            // Buscar el jugador por su nombre
            Player player = this.GameList.FindPlayerByDisplayName(playerDisplayName);
            if (player == null)
            {
                throw new ArgumentException($"El jugador {playerDisplayName} no está jugando", nameof(playerDisplayName));
            }

            // Obtener el índice del Pokémon
            int pokemonIndex = player.GetIndexOfPokemon(newPokemonName);
            if (pokemonIndex < 0)
            {
                throw new ArgumentException($"El Pokémon {newPokemonName} no está disponible para el jugador {playerDisplayName}", nameof(newPokemonName));
            }

            // Activar el Pokémon y generar mensaje
            player.ActivatePokemon(pokemonIndex);
            // falta hacer lo de penalizar el turno: Game.Turn.PenalizeTurn(player);
            return UserInterface.ShowMessageChangePokemon(player.DisplayName, player.ActivePokemon.Name);
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
               return UserInterface.AddPlayerToWaitingList(displayName);
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
                return UserInterface.ShowMessageNoPlayersWaiting();
            }

            return UserInterface.ShowMessagePlayersWaiting(this.WaitingList.GetAllWaiting());

        }
        
        //HISTORIA DE USUARIO 11

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

