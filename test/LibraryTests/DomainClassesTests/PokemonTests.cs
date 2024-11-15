using NUnit.Framework;

namespace ClassLibrary.Tests
{
    public class PokemonTests
    {
        private Pokemon _pokemon;

        [SetUp]
        public void Setup()
        {
            Move[] moves = new Move[]
            {
                new MoveNormal("Patada Ígnea", 80, 0.5, Type.Fire),
                new MoveNormal("Llamarada", 90, 0.7, Type.Fire),
                new MoveNormal("Tajo Aéreo", 70, 0.5, Type.Flying),
                new MoveBurn("Anillo Ígneo", 0, 0.3, Type.Fire)
            };
            _pokemon = new Pokemon(moves);
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
            _pokemon.PokemonType = Type.Electric;

            // Assert
            Assert.That(_pokemon.PokemonType, Is.EqualTo(Type.Electric));
        }
        
        [Test]
        public void Constructor_ShouldInitializeMovesList()
        {
            // Assert
            Assert.That(_pokemon.Moves.Count, Is.EqualTo(Pokemon.MAX_MOVES));
        }
    }
}

