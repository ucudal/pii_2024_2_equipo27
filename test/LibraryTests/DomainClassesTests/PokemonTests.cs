using NUnit.Framework;

namespace ClassLibrary.Tests
{
    public class PokemonTests
    {
        private Pokemon _pokemon;

        [SetUp]
        public void Setup()
        {
            _pokemon = new Pokemon();
        }
        
        [Test]
        public void Name_SetNullOrEmptyName_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.That(() => _pokemon.Name = null, Throws.ArgumentNullException);
            Assert.That(() => _pokemon.Name = "", Throws.ArgumentNullException);
        }
        

       [Test]
        public void Name_SetValidName_ShouldSetName()
        {
            // Act
            _pokemon.Name = "Pikachu";

            // Assert
            Assert.That(_pokemon.Name, Is.EqualTo("Pikachu"));
        }

        [Test]
        public void HealthPoints_SetValidHealthPoints_ShouldSetHealthPoints()
        {
            // Act
            _pokemon.HealthPoints = 100;

            // Assert
            Assert.That(_pokemon.HealthPoints, Is.EqualTo(100));
        }

        [Test]
        public void Type_SetValidType_ShouldSetType()
        {
            // Act
            _pokemon.Type = PokemonType.Type.Electric;

            // Assert
            Assert.That(_pokemon.Type, Is.EqualTo(PokemonType.Type.Electric));
        }
        
        [Test]
        public void Constructor_ShouldInitializeEmptyMovesList()
        {
            // Assert
            Assert.That(_pokemon.Moves, Is.Empty);
        }
    }
}

