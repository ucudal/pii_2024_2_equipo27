using ClassLibrary;
using NUnit.Framework;

namespace ClassLibrary.Tests
{
    public class PokemonCatalogTests
    {
        [Test]
        public void FindPokemonByName_ReturnsPokemonWithSpecialMove()
        {
            // Arrange
            PokemonCatalog catalog = new PokemonCatalog();
    
            // Act
            Pokemon pokemon = catalog.FindPokemonByName("Blaziken");

            // Assert
            Assert.That(pokemon, Is.Not.Null);
            Assert.That(pokemon.SpecialMove.Name, Is.EqualTo("Anillo Ígneo"));
        }
        
        [Test]
        public void FindPokemonByName_NameWithSpaces_ReturnsCorrectPokemon()
        {
            // Arrange
            PokemonCatalog catalog = new PokemonCatalog();
    
            // Act
            Pokemon pokemon = catalog.FindPokemonByName("Rayquaza");

            // Assert
            Assert.That(pokemon, Is.Not.Null);
            Assert.That(pokemon.Name, Is.EqualTo("Rayquaza"));
        }

        [Test]
        public void FindPokemonByName_PokemonNotFound_ReturnsNull()
        {
            // Arrange
            PokemonCatalog catalog = new PokemonCatalog();
    
            // Act
            Pokemon pokemon = catalog.FindPokemonByName("Pikachu");

            // Assert
            Assert.That(pokemon, Is.Null);
        }
        
        [Test]
        public void FindPokemonByName_CaseInsensitive_ReturnsCorrectPokemon()
        {
            // Arrange
            PokemonCatalog catalog = new PokemonCatalog();
    
            // Act
            Pokemon pokemon = catalog.FindPokemonByName("blaziken");

            // Assert
            Assert.That(pokemon, Is.Not.Null);
            Assert.That(pokemon.Name, Is.EqualTo("Blaziken"));
        }
        
        [Test]
        public void FindPokemonByName_ExactMatchWithCase_ReturnsCorrectPokemon()
        {
            // Arrange
            PokemonCatalog catalog = new PokemonCatalog();
    
            // Act
            Pokemon pokemon = catalog.FindPokemonByName("Blaziken");

            // Assert
            Assert.That(pokemon, Is.Not.Null);
            Assert.That(pokemon.Name, Is.EqualTo("Blaziken"));
        }


    }
}