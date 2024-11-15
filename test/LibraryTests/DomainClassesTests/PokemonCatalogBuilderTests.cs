using ClassLibrary;
using NUnit.Framework;
using System.Linq;

namespace ClassLibrary.Tests;

public class PokemonCatalogBuilderTests
{
    [Test]
    public void GetPokemonList_WhenCalled_ReturnsListOfPokemons()
    {
        // Arrange
        PokemonCatalogBuilder catalogBuilder = new PokemonCatalogBuilder();
        
        // Act
        IReadOnlyList<Pokemon> pokemonList = catalogBuilder.PokemonList;
        
        // Assert
        Assert.That(pokemonList.Count, Is.GreaterThan(0)); 
    }

    [Test]
    public void Pokemon_InCatalog_HasCorrectHP()
    {
        // Arrange
        PokemonCatalogBuilder catalogBuilder = new PokemonCatalogBuilder();
        
        // Act
        IReadOnlyList<Pokemon> pokemonList = catalogBuilder.PokemonList;

        // Assert
        foreach (Pokemon pokemon in pokemonList)
        {
            Assert.That(pokemon.HealthPoints, Is.EqualTo(100));
        }
    }

    [Test]
    public void Pokemon_InCatalog_HasAtLeastOneMove()
    {
        // Arrange
        PokemonCatalogBuilder catalogBuilder = new PokemonCatalogBuilder();
        
        // Act
        IReadOnlyList<Pokemon> pokemonList = catalogBuilder.PokemonList;

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
        IReadOnlyList<Pokemon> pokemonList = catalogBuilder.PokemonList;
        Pokemon blaziken = pokemonList.First(p => p.Name == "Blaziken");

        // Assert
        Assert.That(blaziken, Is.Not.Null); 
        Assert.That(blaziken.Name, Is.EqualTo("Blaziken"));
    }
    

}
