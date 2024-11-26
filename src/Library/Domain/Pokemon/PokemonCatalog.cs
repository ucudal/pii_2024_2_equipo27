using System.Collections.ObjectModel;

namespace ClassLibrary;

/// <summary>
/// La clase  <c>PokemonCatalog</c> se encarga de gestionar el acceso y la manipulación de un catálogo de Pokémon.
/// Utiliza un <c>PokemonCatalogBuilder</c> para inicializar el catálogo, permitiendo la búsqueda y recuperación de Pokémon por nombre.
/// </summary>
public class PokemonCatalog
{
    // Lista de Pokémon obtenida a través del builder.
    private IReadOnlyList<Pokemon> pokemons;

    /// <summary>
    /// Constructor de la clase <c>PokemonCatalog</c>.
    /// Inicializa la lista de Pokémon utilizando el builder.
    /// </summary>
    public PokemonCatalog()
    {
        PokemonCatalogBuilder builder = new PokemonCatalogBuilder();
        this.pokemons = builder.PokemonList;
    }

    /// <summary>
    /// Devuelve una lista de todos los Pokémon en el catálogo.
    /// </summary>
    /// <returns>Una lista de objetos Pokémon.</returns>
    public IReadOnlyList<Pokemon> GetAllPokemons()
    {
        return this.pokemons;
    }

    /// <summary>
    /// Encuentra un Pokémon por su nombre en el catálogo.
    /// </summary>
    /// <param name="pokemonName">Nombre del Pokémon a buscar.</param>
    /// <returns>El objeto Pokemon si se encuentra, de lo contrario null.</returns>
    /// <exception cref="ArgumentException">Se lanza si el nombre proporcionado es nulo, vacío o contiene solo espacios en blanco.</exception>
    public Pokemon FindPokemonByName(string pokemonName)
    {
        if (string.IsNullOrWhiteSpace(pokemonName))
        {
            throw new ArgumentException("El nombre del Pokémon no puede estar vacío.");
        }

        foreach (Pokemon pokemon in this.pokemons)
        {
            if (pokemon.Name.Equals(pokemonName, StringComparison.OrdinalIgnoreCase))
            {
                return pokemon;
            }
        }

        return null;
    }
}
