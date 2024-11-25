using ClassLibrary;
using NUnit.Framework;
using System.Linq;

namespace ClassLibrary.Tests;

public class PokemonCatalogBuilderTests
{
    private PokemonCatalogBuilder catalogBuilder;

    [SetUp]
    public void Setup()
    {
        this.catalogBuilder = new PokemonCatalogBuilder();
    }

    [Test]
    public void GetPokemonList_WhenCalled_ReturnsListOfPokemons()
    {
        // Act
        IReadOnlyList<Pokemon> pokemonList = catalogBuilder.PokemonList;
        
        // Assert
        Assert.That(pokemonList.Count, Is.GreaterThan(0)); 
    }

    [Test]
    public void Pokemon_InCatalog_HasCorrectHP()
    {
        
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
        // Act
        IReadOnlyList<Pokemon> pokemonList = catalogBuilder.PokemonList;

        // Assert
        foreach (Pokemon pokemon in pokemonList)
        {
            Assert.That(pokemon.Moves.Count, Is.EqualTo(4)); 
        }
    }

    [Test]
    public void Pokemon_InCatalog_HasCorrectName()
    {
        // Act
        IReadOnlyList<Pokemon> pokemonList = catalogBuilder.PokemonList;
        Pokemon blaziken = pokemonList.First(p => p.Name == "Blaziken");

        // Assert
        Assert.That(blaziken, Is.Not.Null); 
        Assert.That(blaziken.Name, Is.EqualTo("Blaziken"));
    }
    
}
