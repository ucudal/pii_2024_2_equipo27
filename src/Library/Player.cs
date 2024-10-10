namespace ClassLibrary;

//Esta clase tiene la responsabilidaad de conocer a los pokemones que tiene disponibles el jugador y de agregar a los pokemones a la lista
public class Player
{
    public List<Pokemon> AvailablePokemons { get;  } = new List<Pokemon>();

    public void AddPokemon(Pokemon pokemon)
    {
        this.AvailablePokemons.Add(pokemon);
    }
}