namespace ClassLibrary.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class GameListTests
    {
        private GameList gameList;
        private Player player1;
        private Player player2;

        [SetUp]
        public void Setup()
        {
            gameList = new GameList();
            player1 = new Player("Sebastian");
            player2 = new Player("Juan");
        }

        [Test]
        public void AddGame_ShouldAddGameToList()
        {
            // Act
            var game = gameList.AddGame(player1, player2);

            // Assert
            Assert.That(gameList.Games, Has.Member(game));
            Assert.That(gameList.Games.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddGame_SamePlayer_ShouldThrowException()
        {
            // Act & Assert
            var ex = Assert.Throws<PokemonException>(() => gameList.AddGame(player1, player1));
        }

        [Test]
        public void FindPlayerByDisplayName_ShouldReturnPlayer()
        {
            // Arrange
            gameList.AddGame(player1, player2);

            // Act
            var foundPlayer = gameList.FindPlayerByDisplayName("Sebastian");

            // Assert
            Assert.That(foundPlayer, Is.Not.Null);
            Assert.That(foundPlayer.DisplayName, Is.EqualTo(player1.DisplayName));
        }

        [Test]
        public void FindPlayerByDisplayName_PlayerNotInGame_ShouldReturnNull()
        {
            // Act
            var foundPlayer = gameList.FindPlayerByDisplayName("Desconocido");

            // Assert
            Assert.That(foundPlayer, Is.Null);
        }

        [Test]
        public void FindOpponentOfDisplayName_ShouldReturnOpponent()
        {
            // Arrange
            gameList.AddGame(player1, player2);

            // Act
            var opponent = gameList.FindOpponentOfDisplayName("Sebastian");

            // Assert
            Assert.That(opponent, Is.Not.Null);
            Assert.That(opponent.DisplayName, Is.EqualTo(player2.DisplayName));
        }

        [Test]
        public void FindOpponentOfDisplayName_PlayerNotInGame_ShouldReturnNull()
        {
            // Act
            var opponent = gameList.FindOpponentOfDisplayName("Desconocido");

            // Assert
            Assert.That(opponent, Is.Null);
        }

        [Test]
        public void FindGameByPlayerDisplayName_ShouldReturnGame()
        {
            // Arrange
            var game = gameList.AddGame(player1, player2);

            // Act
            var foundGame = gameList.FindGameByPlayerDisplayName("Sebastian");

            // Assert
            Assert.That(foundGame, Is.Not.Null);
            Assert.That(foundGame, Is.EqualTo(game));
        }

        [Test]
        public void FindGameByPlayerDisplayName_PlayerNotInAnyGame_ShouldReturnNull()
        {
            // Act
            var foundGame = gameList.FindGameByPlayerDisplayName("Desconocido");

            // Assert
            Assert.That(foundGame, Is.Null);
        }
    }
}