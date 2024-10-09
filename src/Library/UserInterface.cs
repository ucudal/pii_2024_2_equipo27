namespace ClassLibrary;

//Esta clase tiene la responsabilidad de mostrar lo que ve el usuario
public class UserInterface
{
    public string ShowPokemonCatalog()
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

    public string ShowMessageToAddPokemons(int currentSelection)
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
    public string ShowSelectedPokemons(List<Pokemon> selectedPokemons)
    {
        string selectedList = "⭐️ Pokémon seleccionados:\n";

        foreach (Pokemon pokemon in selectedPokemons)
        {
            selectedList += $"- {pokemon.Name}\n";
        }

        return selectedList;
    }
    
}