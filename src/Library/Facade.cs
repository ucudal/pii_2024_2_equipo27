namespace ClassLibrary;

public class Facade
{
    public void PlayerChoosesPokemons(int playerId, string[] pokemonNames)
    {
        PokemonCatalog catalog = new PokemonCatalog();
        Game game = new Game();
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
            Pokemon pokemon = catalog.FindPokemonByName(pokemonName);
            player.AddPokemon(pokemon);
        }
    }
}

