using NUnit.Framework;

namespace ClassLibrary.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player player;
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

            player = new Player("Juan");
            _pokemon = new Pokemon(moves);
        }


        [Test]
        public void AddPokemon_ShouldAddPokemonToAvailablePokemons()
        {
            // Act
            player.AddPokemon(_pokemon);

            // Assert
            Assert.That(player.AvailablePokemons.Contains(_pokemon));
        }

        [Test]
        public void AddPokemon_ShouldSetActivePokemon_WhenFirstPokemonAdded()
        {
            // Act
            player.AddPokemon(_pokemon);

            // Assert
            Assert.That(player.ActivePokemon, Is.EqualTo(_pokemon));
        }


        [Test]
        public void UseItem_ShouldRemoveItemFromInventory_WhenItemExists()
        {
            // Arrange
            Player player = new Player("TestPlayer");
            Item item = new ItemRevive();

            // Act
            player.UseItem("Revivir");

            // Assert
            Assert.That(() => player.UseItem("Revivir"), Throws.InstanceOf<ApplicationException>());
        }
    }
}