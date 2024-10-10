namespace ClassLibrary;

//Esta clase tiene la responsabilidaad de conocer a los pokemones que tiene disponibles el jugador y de agregar a los pokemones a la lista
public class Player
{
    internal object Name;
    private List<Pokemon> availablePokemons = new List<Pokemon> ();

    public Player(string v)
    {
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.availablePokemons.Add(pokemon);
    }
}