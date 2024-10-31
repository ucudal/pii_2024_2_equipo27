using ClassLibrary;
using NUnit.Framework;
namespace ClassLibrary.Tests;

public class PokemonCatalogBuilderTests
{
    [Test]
    public void GetPokemonList_WhenCalled_ReturnsListOfPokemons()
    {
        // Arrange
        PokemonCatalogBuilder catalogBuilder = new PokemonCatalogBuilder();
        
        // Act
        List<Pokemon> pokemonList = catalogBuilder.GetPokemonList();
        
        // Assert
        Assert.That(pokemonList.Count, Is.GreaterThan(0)); 
    }

    [Test]
    public void Pokemon_InCatalog_HasCorrectHP()
    {
        // Arrange
        PokemonCatalogBuilder catalogBuilder = new PokemonCatalogBuilder();
        
        // Act
        List<Pokemon> pokemonList = catalogBuilder.GetPokemonList();

        // Assert
        foreach (Pokemon pokemon in pokemonList)
        {
            Assert.That(pokemon.HealthPoints, Is.EqualTo(100));
        }
    }

    [Test]
    public void Pokemon_InCatalog_HasSpecialMove()
    {
        // Arrange
        PokemonCatalogBuilder catalogBuilder = new PokemonCatalogBuilder();
        
        // Act
        List<Pokemon> pokemonList = catalogBuilder.GetPokemonList();

        // Assert
        foreach (Pokemon pokemon in pokemonList)
        {
            Assert.That(pokemon.SpecialMove, Is.Not.Null); 
        }
    }

    [Test]
    public void Pokemon_InCatalog_HasAtLeastOneMove()
    {
        // Arrange
        PokemonCatalogBuilder catalogBuilder = new PokemonCatalogBuilder();
        
        // Act
        List<Pokemon> pokemonList = catalogBuilder.GetPokemonList();

        // Assert
        foreach (Pokemon pokemon in pokemonList)
        {
            Assert.That(pokemon.Moves.Count, Is.GreaterThan(0)); 
        }
    }

    [Test]
    public void Pokemon_InCatalog_HasCorrectName()
    {
        // Arrange
        PokemonCatalogBuilder catalogBuilder = new PokemonCatalogBuilder();
        
        // Act
        List<Pokemon> pokemonList = catalogBuilder.GetPokemonList();
        Pokemon blaziken = pokemonList.Find(p => p.Name == "Blaziken");

        // Assert
        Assert.That(blaziken, Is.Not.Null); 
        Assert.That(blaziken.Name, Is.EqualTo("Blaziken"));
    }
}
