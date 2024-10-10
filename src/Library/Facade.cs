namespace ClassLibrary;

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
        
        foreach (string pokemonName in pokemonNames)
        {
            Pokemon pokemon = catalog.FindPokemonByName(pokemonName.ToLower());
            player.AddPokemon(pokemon);
        }
        
        return result;
    }

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
}
    
    

    // Para implementar la clase de cambiar al pokemon y que te saca turnos hacerlo aca algo asi creo
    //
    // public void ChangePokemon()
    // {
    //     
    // }
    
    // if (pokemonName != player.ActivePokemon.Name)
    // {
    //     ChangePokemon();
    // }


