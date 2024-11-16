namespace ClassLibrary
{
    /// <summary>
    /// La clase  <c>Facade</c> proporciona una interfaz simplificada para interactuar con el juego, permitiendo a los jugadores seleccionar
    /// Pokémon, mostrar movimientos, activar ataques y consultar la salud de los Pokémon. Aplica el Patrón de Diseño Facade,
    /// que oculta la complejidad del sistema y simplifica la interacción con múltiples subsistemas, mejorando la usabilidad.
    /// Esta clase sigue el Principio de Responsabilidad Única (SRP) al concentrar la lógica de interacción en un solo lugar,
    /// lo que facilita el mantenimiento y la evolución del sistema. Esta estructura permite a los
    /// desarrolladores y jugadores interactuar con el juego de manera más intuitiva, minimizando la necesidad de conocer la
    /// implementación interna.
    /// </summary>
    public class Facade
    {
        private WaitingList WaitingList { get; }
        public GameList GameList { get; }
        private UserInterface UserInterface { get; }


        private static Facade _instance;

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
        
        /// <summary>
        /// Muestra el catálogo completo de Pokémon disponibles para seleccionar en la partida.
        /// </summary>
        /// <returns>Un mensaje que contiene la lista de Pokémon disponibles en el catálogo.</returns>
        public string ShowPokemonCatalog()
        {
            return UserInterface.ShowMessagePokemonCatalog();
        }
        
        /// <summary>
        /// Permite a un jugador seleccionar hasta seis Pokémon para su equipo en la partida.
        /// Verifica que el jugador esté activo y que no seleccione más de seis Pokémon. Luego,
        /// agrega los Pokémon seleccionados al equipo del jugador y muestra los detalles de los Pokémon seleccionados.
        /// </summary>
        /// <param name="playerDisplayName">El nombre del jugador que seleccionará los Pokémon.</param>
        /// <param name="pokemonNames">Un arreglo de nombres de los Pokémon que el jugador desea seleccionar.</param>
        /// <returns>Un mensaje que indica los Pokémon seleccionados o un mensaje de error si ocurre algún problema.</returnS>
        public string ChoosePokemons(string playerDisplayName, string[] pokemonNames)
        {
            Player player = this.GameList.FindPlayerByDisplayName(playerDisplayName);
            if (player == null)
            {
                return $"El jugador {playerDisplayName} no está jugando";
            }

            if (pokemonNames.Length > 6)
            {
                return "No puedes seleccionar más de 6 Pokémon.";
            }

            List<Pokemon> selectedPokemons = new List<Pokemon>();
            PokemonCatalog catalog = new PokemonCatalog();

            foreach (string pokemonName in pokemonNames)
            {
                Pokemon pokemon = catalog.FindPokemonByName(pokemonName);
                if (pokemon != null)
                {
                    player.AddPokemon(pokemon);
                    selectedPokemons.Add(pokemon);
                }
                else
                { ;
                    throw new Exception($"El pokemon {pokemonName} no esta en el catalogo");
                }
            }

            // Llama a UserInterface para mostrar los Pokémon seleccionados
            return UserInterface.ShowMessageSelectedPokemons(selectedPokemons);
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
            
            int moveIndex = player.GetIndexOfMoveInActivePokemon(moveName);
            if (moveIndex < 0)
            {
                throw new Exception($"El movimiento {moveName} no está disponible para el Pokémon {pokemonName}");
            }

            player.ActivateMoveInActivePokemon(moveIndex);
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
            //Verifica que el parámetro playerDisplayName no sea Null ni este vacío
            if (string.IsNullOrWhiteSpace(playerDisplayName))
            {
                throw new ArgumentNullException(nameof(playerDisplayName), "El nombre del jugador no puede ser nulo o estar vacío.");
            }
            
            // Busca al jugador por su nombre para obtener sus Pokémon.
            Player player = this.GameList.FindPlayerByDisplayName(playerDisplayName);
            if (player == null)
            {
                throw new PokemonException($"El jugador {playerDisplayName} no está jugando.");
            }

            // Busca al oponente del jugador para obtener sus Pokémon.
            Player opponent = this.GameList.FindOpponentOfDisplayName(playerDisplayName);
            if (opponent == null)
            {
                throw new PokemonException($"No se encontró el oponente del jugador {playerDisplayName}.");
            }

            // Devuelve la cadena formateada con la salud de los Pokémon de ambos jugadores.
            return UserInterface.ShowMessagePokemonHealth(player.AvailablePokemons, opponent.AvailablePokemons);
        }
        
        // HISTORIA DE USUARIO 4
        
        /// <summary>
        /// Realiza un ataque en el turno del jugador, aplicando el daño basado en la efectividad del tipo.
        /// </summary>
        /// <param name="attackerName">El nombre del jugador atacante.</param>
        /// <param name="defenderName">El nombre del jugador defensor.</param>
        /// <param name="moveName">El nombre del movimiento seleccionado para el ataque.</param>
        /// <returns>Un mensaje con el resultado del ataque.</returns>
        public string PlayerAttack(string attackerName)
        { 
            //Encontrar el jugador
            Player attacker = this.GameList.FindPlayerByDisplayName(attackerName);
            Player defender = this.GameList.FindOpponentOfDisplayName(attackerName);
            // Buscar el jugador por su nombre y validar que esté en el juego
            if (attacker == null )
            {
                throw new ArgumentException($"El jugador '{attackerName}' no está jugando.");
            }
            if (defender == null)
            {
                throw new ArgumentException($"El jugador '{attackerName}' no está jugando.");
            }
        
            if (attacker == null || defender == null)
            {
                throw new PokemonException("Uno o ambos jugadores no están en el juego");
                //return "Uno o ambos jugadores no están en el juego.";
            }
            //Ejecuta el ataque
            attacker.ExecuteMove(defender, attacker);
            
            // Construye el mensaje de resultado
            return UserInterface.ShowMessageAttackOcurred(attacker.ActivePokemon, defender.ActivePokemon, attacker, defender);
        }
        
        //HISTORIA DE USUARIO 5
        
        /// <summary>
        /// Obtiene el nombre del jugador que tiene el turno actual en la partida en la que se encuentra el jugador especificado.
        /// Verifica si el jugador está en una partida activa y, de ser así, devuelve el nombre del jugador cuyo turno está en curso.
        /// </summary>
        /// <param name="playerDisplayName">El nombre del jugador para buscar su partida.</param>
        /// <returns>Un mensaje que indica el nombre del jugador con el turno actual o un mensaje de error si el jugador no está en una partida.</returns>
        public string GetCurrentTurnPlayer(string playerDisplayName)
        {
                // Buscar la partida en la que está el jugador
            Game game = this.GameList.FindGameByPlayerDisplayName(playerDisplayName);

            if (game == null)
            {
                throw new Exception($"El jugador {playerDisplayName} no está en una partida.");
            }

                // Obtener el nombre del jugador que tiene el turno actual
            string currentPlayerDisplayName = game.Turn.CurrentPlayer.DisplayName;

            return UserInterface.ShowMessageCurrentTurnPlayer(currentPlayerDisplayName);
        }
        
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
        public string EndGame(Game game, Player player, string playerDisplayName)
        {
            // Verifica si el juego ha terminado (puede modificar estados internos del juego)
            game.CheckIfGameEnds();
            
            // Si el jugador no tiene Pokémon disponibles, termina la batalla y muestra el mensaje de fin de la batalla
            if (player.AvailablePokemons.Count == 0)
            {
                return UserInterface.ShowBattleEndMessage(playerName: playerDisplayName);
            }
            
            // Si el jugador tiene un Pokémon o mas  disponibles, la batalla no ha terminado
            if (player.AvailablePokemons.Count >= 1)
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
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="playerDisplayName"/> o <paramref name="newPokemonName"/> son nulos o están vacíos.</exception>
        public string ChangePokemon(string playerDisplayName, string newPokemonName)
        {
            // Validación de parámetros de entrada
            if (string.IsNullOrWhiteSpace(playerDisplayName)||string.IsNullOrWhiteSpace(newPokemonName))
            {
                throw new ArgumentNullException(nameof(playerDisplayName), "El nombre del jugador o de su pokemon seleccionado no puede ser nulo o estar vacío.");
            }

            // Buscar el jugador por su nombre y validar que esté en el juego
            Player player = this.GameList.FindPlayerByDisplayName(playerDisplayName);
            if (player == null)
            {
                throw new ArgumentException($"El jugador '{playerDisplayName}' no está jugando.");
            }

            // Obtener el índice del Pokémon y validar que el jugador tenga el pokemon
            int pokemonIndex = player.GetIndexOfPokemon(newPokemonName);
            if (pokemonIndex < 0)
            {
                throw new ArgumentException($"El Pokémon '{newPokemonName}' no está disponible para el jugador '{playerDisplayName}'");
            }

            // Activar el Pokémon y generar mensaje
            player.ActivatePokemon(pokemonIndex);

            // Penalizar el turno del jugador
            Game game = GameList.FindGameByPlayerDisplayName(playerDisplayName);
            game.Turn.PenalizeTurn(player);

            return UserInterface.ShowMessageChangePokemon(player.DisplayName, player.ActivePokemon.Name);
        }
        
        //HISTORIA DE USUARIO 8
        
        /// <summary>
        /// Permite que un jugador use un ítem específico en su Pokémon activo dentro de una partida.
        /// La función busca al jugador por su nombre, verifica que esté en la partida y que tenga un Pokémon activo
        /// para aplicar el ítem. Si es válido, aplica el efecto del ítem al Pokémon.
        /// </summary>
        /// <param name="playerDisplayName">El nombre del jugador que intenta usar el ítem.</param>
        /// <param name="itemName">El nombre del ítem que el jugador intenta usar.</param>
        /// <returns>Un mensaje que indica si el jugador usó el ítem con éxito, el efecto del ítem o cualquier error.</returns>
        public string PlayerUseItem(string playerDisplayName, string itemName) 
        {
            if (string.IsNullOrEmpty(playerDisplayName))
            {
                throw new ArgumentNullException(); // TODO: falta mensaje
            }   
            
            if (string.IsNullOrEmpty(itemName))
            {
                throw new ArgumentNullException(); // TODO: falta mensaje
            } 
            
            // Buscar el jugador por su nombre
            Player player = this.GameList.FindPlayerByDisplayName(playerDisplayName);
            if (player == null)
            {
                // Retorna un mensaje indicando que el jugador no está jugando
                throw new Exception($"El jugador {playerDisplayName} no está jugando");
            }

            try
            {
                // Intentar usar el ítem
                Item itemUsed = player.UseItem(itemName); 
                
                // TODO: todo lo que sigue va en Player.UseItem

                // Verificar que el jugador tiene un Pokémon activo
                if (player.ActivePokemon == null)
                {
                    throw new Exception($"{playerDisplayName} no tiene un Pokémon activo para aplicar el ítem.");
                }

                // Aplicar el efecto del ítem en el Pokémon activo del jugador
                string effectResult = itemUsed.ApplyEffect(player.ActivePokemon);

                // Retornar un mensaje que indica el uso del ítem y el resultado de su efecto
                return $"{playerDisplayName} ha usado {itemUsed.Name}. {effectResult}";
            }
            catch (ApplicationException ex)
            {
                // Si ocurre una excepción (por ejemplo, el ítem no existe), retorna el mensaje de error
                return ex.Message;
            }
        }

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
            Player player = this.WaitingList.FindPlayerByDisplayName(displayName);
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
        public string StartBattle(string playerDisplayName, string opponentDisplayName)
        {
            Player opponent;

            if (!OpponentProvided() && !SomebodyIsWaiting())
            {
                return "No hay nadie esperando";
            }

            if (!OpponentProvided())
            {
                opponent = this.WaitingList.GetAnyoneWaiting();
                return this.CreateBattle(playerDisplayName, opponent.DisplayName);
            }

            opponent = this.WaitingList.FindPlayerByDisplayName(opponentDisplayName!);

            if (!OpponentFound())
            {
                return $"{opponentDisplayName} no está esperando";
            }

            return this.CreateBattle(playerDisplayName, opponent.DisplayName);

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

        public void ChangeTurn(Player attacker)
        {
            Game game = GameList.FindGameByPlayerDisplayName(attacker.DisplayName);
            game.Turn.ChangeTurn();

            game.CheckIfGameEnds();
        }
        
        // COMANDOS Y REGLAS DEL JUEGO

        public string GetHelpMessage()
        {
            return UserInterface.ShowMessageHelp();
        }
        
        public string GetRulesMessage()
        {
            return UserInterface.ShowMessageRules();
        }
    }
}

