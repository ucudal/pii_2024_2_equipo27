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
        public void HealthPoints_SetNegativeHealthPoints_ShouldThrowArgumentOutOfRangeException()
        {
            // Act & Assert
            Assert.That(() => _pokemon.HealthPoints = -10, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void SpecialMove_SetNullSpecialMove_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.That(() => _pokemon.SpecialMoveNormal = null, Throws.ArgumentNullException);
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
        public void SpecialMove_SetValidSpecialMove_ShouldSetSpecialMove()
        {
            // Arrange
            MoveNormal specialMoveNormal = new MoveNormal("Thunder", 60, 0.5);

            // Act
            _pokemon.SpecialMoveNormal = specialMoveNormal;

            // Assert
            Assert.That(_pokemon.SpecialMoveNormal, Is.EqualTo(specialMoveNormal));
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

