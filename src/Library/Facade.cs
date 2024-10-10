namespace ClassLibrary;

public class Facade
{
    public void PlayerChoosesPokemons(int playerId)
    {
        PokemonCatalog catalog = new PokemonCatalog();
        Game game = new Game();
        Player player;
        UserInterface userInterface = new UserInterface();
        
        if (playerId == 1)
        {
            player = game.Player1;
        }
        else
        {
            player = game.Player2;
        }
        
        int selectionCount = 0;
        List<string> pokemonNames = new List<string>();

        while (selectionCount < 6)
        {
            Console.WriteLine(userInterface.ShowMessageToAddPokemons(selectionCount));
            pokemonNames.Add(Console.ReadLine().ToLower());
            selectionCount += 1;
        }

        foreach (string pokemonName in pokemonNames)
        {
            Pokemon pokemon = catalog.FindPokemonByName(pokemonName.ToLower());
            player.AddPokemon(pokemon);
        }
        
        Console.WriteLine("Pokémons seleccionados por el jugador 1.");
    }

    public List<string> GetPokemonsHealth(int playerId)
    {
        Game game = new Game();
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

