namespace ClassLibrary;
/// <summary>
/// La clase <c>Facade</c> actúa como una interfaz simplificada para interactuar con el juego,
/// permitiendo a los jugadores elegir Pokémon, mostrar movimientos, activar ataques y obtener información sobre la salud de los Pokémon.
/// </summary>
public class Facade
{
    Game game = new Game(new Player(), new Player());

    public List<string> ChoosePokemons(int playerId, string[] pokemonNames)
    {
        List<string> result = new List<string>();
        result.Add($"Pokémons seleccionados por el jugador {playerId}.");
        PokemonCatalog catalog = new PokemonCatalog();

        Player player;
        
        if (playerId == 1)
        {
            player = game.Player1;
        }
        else
        {
            player = game.Player2;
        }
        
        foreach (string pokemonName in pokemonNames) //Agregar un argumentNullException para verificar que pokemonNames no sea nulo antes de usarlo
        {
            Pokemon pokemon = catalog.FindPokemonByName(pokemonName);
            player.AddPokemon(pokemon);
        }
        
        return result;
    }
    /// <summary>
    /// Muestra los movimientos disponibles de los Pokémon del jugador seleccionado.
    /// </summary>
    /// <param name="playerId">El ID del jugador (1 o 2).</param>
    /// <returns>Una lista de cadenas con los Pokémon y sus movimientos.</returns>
    public List<string> ShowMoves(int playerId)
    {
        Player player;
        if (playerId == 1)
        {
            player = game.Player1;
        }
        else
        {
            player = game.Player2;
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
    /// <param name="playerId">El ID del jugador (1 o 2).</param>
    /// <param name="moveName">El nombre del movimiento a utilizar.</param>
    /// <param name="pokemonName">El nombre del Pokémon que realizará el ataque.</param>
    public void ChoosePokemonAndMoveToAttack(int playerId, string moveName, string pokemonName)
    {
        List<string> result = new List<string>();
        Player player;

        if (playerId == 1)
        {
            player = game.Player1;
        }
        else
        {
            player = game.Player2;
        }
        
        int pokemonIndex = player.GetIndexOfPokemon(pokemonName);
        player.ActivatePokemon(pokemonIndex);
        
        if (moveName == player.ActivePokemon.SpecialMove.Name) 
        {
            player.ActivateSpecialMove(moveName); // Falta hacer lo de que no se pueda usar cada dos turnos creo que usando turn y game 
        }
        else
        {
            int moveIndex = player.GetIndexOfMoveInActivePokemon(moveName);
            player.ActivateMoveInActivePokemon(moveIndex);
        }
    }
    /// <summary>
    /// Obtiene la salud de los Pokémon de un jugador en comparación con el oponente.
    /// </summary>
    /// <param name="playerId">El ID del jugador (1 o 2).</param>
    /// <returns>Una lista de cadenas que muestra la salud de los Pokémon del jugador y del oponente.</returns>
    public List<string> GetPokemonsHealth(int playerId)
    {
        Player player;
        Player opponent;
        UserInterface userInterface = new UserInterface();
        
        if (playerId == 1)
        {
            player = game.Player1;
            opponent = game.Player2;
        }
        else
        {
            player = game.Player2;
            opponent = game.Player1;
        }

        return userInterface.ShowPokemonHealth(player.AvailablePokemons, opponent.AvailablePokemons);
    }

    public string ChangePokemon(int playerId,string newPokemonName){
        Player player;
        if(playerId==1)
        {
            player=game.Player1;
        }
        else
        {
            player=game.Player2;
        }
        int pokemonIndex=player.GetIndexOfPokemon(newPokemonName);
        if(pokemonIndex<0)
        {
            return $"El Pokemon {newPokemonName} no esta disponible para el jugador {playerId}";
        }
        player.ActivatePokemon(pokemonIndex);
        game.TurnPlayer=game.TurnPlayer==game.Player1 ? game.Player2:game.Player1;
        game.CheckIfGameEnds();
        return $"{player.Name} cambio a {player.ActivePokemon.Name} y perdio su turn";
    }

}


