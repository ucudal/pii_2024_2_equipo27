namespace ClassLibrary;

//Esta clase tiene la responsabilidad de mostrar lo que ve el usuario
public class UserInterface
{
    public static string ShowPokemonCatalog()
    {
        PokemonCatalogBuilder pokemons = new PokemonCatalogBuilder();

        List<Pokemon> pokemonList = pokemons.GetPokemonList();

        string catalogo = "📜 Catálogo de Pokémon:\n";

        foreach (Pokemon pokemon in pokemonList)
        {
            catalogo += $"- {pokemon.Name}\n";
        }

        return catalogo;
    }

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
    public static string ShowSelectedPokemons(List<Pokemon> selectedPokemons) //Validar que selectedPokemons no sea nulo
    {
        string selectedList = "⭐️ Pokémon seleccionados:\n";

        foreach (Pokemon pokemon in selectedPokemons)
        {
            selectedList += $"- {pokemon.Name}\n";
        }

        return selectedList;
    }
    public List<string> ShowPokemonHealth(List<Pokemon> playerPokemons, List<Pokemon> opponentPokemons) //validar que playerpokemons y oponentPokemons no sea nulo
    {
        List<string> healthInfo = new List<string>();
        healthInfo.Add("💓 Salud de los Pokémon:");

        healthInfo.Add("Pokémon propios:");
        foreach (Pokemon pokemon in playerPokemons)
        {
            healthInfo.Add($"{pokemon.Name}: {pokemon.HealthPoints}/{pokemon.HealthPoints}"); 
        }

        healthInfo.Add("Pokémon oponentes:");
        foreach (Pokemon pokemon in opponentPokemons)
        {
            healthInfo.Add($"{pokemon.Name}: {pokemon.HealthPoints}/{pokemon.HealthPoints}"); 
        }

        return healthInfo;
    }
}