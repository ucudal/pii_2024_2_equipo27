using ClassLibrary;
using NUnit.Framework;

namespace Tests;

public class PokemonCatalogTests
{
    [Test]
    public void FindPokemonByName_NameDoesNotExists_ReturnsNull()
    {
        PokemonCatalog catalog = new PokemonCatalog();

        Pokemon pokemon = catalog.FindPokemonByName("#$%&");
        
        Assert.That(pokemon, Is.Null);
    }

    [Test]
    public void FindPokemonByName_WhenPokemonExists_ReturnsPokemon()
    {
        PokemonCatalog catalog = new PokemonCatalog();

        Pokemon pokemon = catalog.FindPokemonByName("Pikachu");
        
        Assert.That(pokemon.Name, Is.EqualTo("Pikachu")); 
    }
}