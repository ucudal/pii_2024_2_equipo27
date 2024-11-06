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
            Assert.That(() => _pokemon.SpecialMove = null, Throws.ArgumentNullException);
        }

        [Test]
        public void Moves_AddMoreThanMaxMoves_ShouldThrowInvalidOperationException()
        {
            // Arrange
            Move move1 = new Move("Esfera Aural", 80, 20, 0);
            Move move2 = new Move("Velocidad Extrema", 80, 5, 0);
            Move move3 = new Move("Puño Incremento", 50, 20, 0);
            Move move4 = new Move("Hululo", 20, 30, 0);
            Move move5 = new Move("Martillo", 20, 100, 0);


            // Act & Assert
            Assert.That(() => _pokemon.Moves = new List<Move>() { move1, move2, move3, move4, move5 }, Throws.InvalidOperationException);
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
            Move specialMove = new Move("Thunder", 60, 50, 10);

            // Act
            _pokemon.SpecialMove = specialMove;

            // Assert
            Assert.That(_pokemon.SpecialMove, Is.EqualTo(specialMove));
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

