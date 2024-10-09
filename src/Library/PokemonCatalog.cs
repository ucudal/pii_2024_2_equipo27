namespace ClassLibrary;

//Esta clase tiene la responsabilidad de acceder a los distintos atributos de los pokemones un catálogo de pokemones
public class PokemonCatalog
{
    static PokemonCatalogBuilder catalogo = new PokemonCatalogBuilder();
    public List<Pokemon> pokemons = catalogo.GetPokemonList();
 
    public Pokemon FindPokemonByName(string pokemonName)
    {
        foreach (Pokemon pokemon in catalogo.pokemons)
        {
            if (pokemon.Name == pokemonName)
            {
                return pokemon;
            }
        }

        return null;
    }
}