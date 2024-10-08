namespace ClassLibrary;

public class PokemonCatalog
{
    private List<Pokemon> pokemons = new List<Pokemon>();

    public PokemonCatalog()
    {
        Pokemon pikachu = new Pokemon();
        pikachu.Name = "Pikachu";
        this.pokemons.Add(pikachu);
    }
    
    public Pokemon FindPokemonByName(string pokemonName)
    {
        foreach (Pokemon pokemon in this.pokemons)
        {
            if (pokemon.Name == pokemonName)
            {
                return pokemon;
            }
        }

        return null;
    }
}