namespace ClassLibrary.Tests
{
    using NUnit.Framework;
    using ClassLibrary;
    using System;

    [TestFixture]
    public class UserStory1Tests
    {
        [SetUp]
        public void SetUpPlayersAndBattle()
        {
            // Utilizar un patrón similar al ejemplo
            Facade.Instance.AddPlayerToWaitingList("player1");
            Facade.Instance.AddPlayerToWaitingList("player2");
            Facade.Instance.StartBattle("player1", "player2");
        }

        [Test]
        public void ChoosePokemons_WhenPlayerDoesNotExist_ShouldReturnErrorMessage()
        {
            // Act
            string result = Facade.Instance.ChoosePokemons("nonExistingPlayer",
                new[] { "Pikachu", "Larpas" });

            // Assert
            Assert.That(result, Is.EqualTo("El jugador nonExistingPlayer no está jugando"));
        }

        [Test]
        public void ChoosePokemons_WhenPokemonNotInCatalog_ShouldThrowException()
        {
            // Act & Assert
            Assert.That(() => Facade.Instance.ChoosePokemons("player1", new[] { "Pikachu", "PokemonFalso" }),
                Throws.InstanceOf<Exception>()
                    .With.Message.EqualTo("El pokemon PokemonFalso no esta en el catalogo"));
        }

        [Test]
        public void ChoosePokemons_WhenValidPokemonsSelected_ShouldReturnSuccessMessage()
        {
            // Act
            string message = Facade.Instance.ChoosePokemons("player1",
                new[] { "Blaziken", "Tinkaton", "Salamence", "Bellsprout", "Zangoose", "Rayquaza" });

            // Assert
            Assert.That(message, Is.Not.Empty);
        }
    }
}