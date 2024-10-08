namespace ClassLibrary;

public class Player
{
    private List<Pokemon> pokemons = new List<Pokemon>();
    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemons.Add(pokemon);
    }
}