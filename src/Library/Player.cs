namespace ClassLibrary;

//Esta clase tiene la responsabilidaad de conocer a los pokemones que tiene disponibles el jugador,
//conocer los pokemones activos del jugador y sus movimientos y activar a los mismos 
public class Player
{
    public string Name { get; set;}

    public List<Pokemon> AvailablePokemons { get; } = new List<Pokemon>();
    
    public Pokemon ActivePokemon { get; private set; }
    
    public Move ActiveMove { get; private set; }

    public void AddPokemon(Pokemon pokemon)
    {
        this.AvailablePokemons.Add(pokemon);
    }

    public int GetIndexOfPokemon(string pokemonName)
    {
        for (int i = 0; i < this.AvailablePokemons.Count; i++)
        {
            if (this.AvailablePokemons[i].Name == pokemonName)
            {
                return i;
            }
        }

        return -1;
    }
    
    public void ActivatePokemon(int index)
    {
        this.ActivePokemon = this.AvailablePokemons[index];
        this.ActiveMove = null;
    }

    public int GetIndexOfMoveInActivePokemon(string moveName)
    {
        for (int i = 0; i < this.ActivePokemon.Moves.Count; i++)
        {
            if (this.ActivePokemon.Moves[i].Name == moveName)
            {
                return i;
            }
        }

        return -1;
    }

    public void ActivateMoveInActivePokemon(int index)
    {
        this.ActiveMove = this.ActivePokemon.Moves[index];
    }

    public void ActivateSpecialMove(string specialMoveName)
    {
        this.ActiveMove = this.ActivePokemon.SpecialMove;
        //turn.SpecialMoveIsAvailable = false;
    }
}