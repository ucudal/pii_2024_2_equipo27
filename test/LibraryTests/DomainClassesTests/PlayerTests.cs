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
            _pokemon.Name = "Pikachu";
        }


        [Test]
        public void AddPokemon_ShouldAddPokemonToAvailablePokemons()
        {
            // Act
            player.AddPokemon(_pokemon);

            // Assert
            Assert.That(player.AvailablePokemons[0].Name, Is.EqualTo(_pokemon.Name));
        }


        [Test]
        public void AddPokemon_ShouldSetActivePokemon_WhenFirstPokemonAdded()
        {
            // Act
            player.AddPokemon(_pokemon);

            // Assert
            Assert.That(player.ActivePokemon.Name, Is.EqualTo(_pokemon.Name));
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

        [Test]
        public void GetHealthPercentageSum_ShouldReturnRightPercentage_WhenHealthDiminished()
        {
            // Arrange
            Player player = new Player("TestPlayer");
            _pokemon.HealthPoints = 80;
            player.AddPokemon(_pokemon);

            // Act
            double total = player.GetHealthPercentageSum();

            // Assert
            Assert.That(total, Is.EqualTo(80));
        }

        [Test]
        public void GetHealthPercentageSum_ShouldReturn100ForEachPokemon_WhenThereAreNoChanges()
        {
            // Arrange
            Player player = new Player("TestPlayer");
            player.AddPokemon(_pokemon);

            // Act
            double total = player.GetHealthPercentageSum();

            // Assert
            Assert.That(total, Is.EqualTo(100));
        }
    }
}