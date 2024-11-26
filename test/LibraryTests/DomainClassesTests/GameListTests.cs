using NUnit.Framework;
using System;

namespace ClassLibrary.Tests
{
    [TestFixture]
    public class GameListTests
    {
        private GameList _gameList;

        [SetUp]
        public void SetUp()
        {
            _gameList = new GameList();
        }

        [Test]
        public void AddGame_ShouldAddGameSuccessfully()
        {
            // Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");

            // Act
            var game = _gameList.AddGame(player1, player2);

            // Assert
            Assert.That(_gameList.Games.Count, Is.EqualTo(1));
            Assert.That(_gameList.Games[0], Is.SameAs(game));
            Assert.That(game.Player1, Is.SameAs(player1));
            Assert.That(game.Player2, Is.SameAs(player2));
        }

        [Test]
        public void AddGame_ShouldThrowException_WhenPlayer1IsNull()
        {
            // Arrange
            Player player1 = null;
            var player2 = new Player("Player2");

            // Act & Assert
            Assert.That(() => _gameList.AddGame(player1, player2), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void AddGame_ShouldThrowException_WhenPlayer2IsNull()
        {
            // Arrange
            var player1 = new Player("Player1");
            Player player2 = null;

            // Act & Assert
            Assert.That(() => _gameList.AddGame(player1, player2), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void AddGame_ShouldThrowException_WhenPlayersAreSame()
        {
            // Arrange
            var player1 = new Player("Player");

            // Act & Assert
            Assert.That(() => _gameList.AddGame(player1, player1), Throws.InstanceOf<ApplicationException>());
        }

        [Test]
        public void FindPlayerByDisplayName_ShouldReturnCorrectPlayer()
        {
            // Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            _gameList.AddGame(player1, player2);

            // Act
            var result = _gameList.FindPlayerByDisplayName("Player1");

            // Assert
            Assert.That(result, Is.SameAs(player1));
        }

        [Test]
        public void FindPlayerByDisplayName_ShouldReturnNull_WhenPlayerNotFound()
        {
            // Act
            var result = _gameList.FindPlayerByDisplayName("NonExistent");

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void FindPlayerByDisplayName_ShouldThrowException_WhenDisplayNameIsNull()
        {
            // Act & Assert
            Assert.That(() => _gameList.FindPlayerByDisplayName(null),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("El jugador no puede estar vacío"));
        }

        [Test]
        public void FindOpponentOfDisplayName_ShouldReturnCorrectOpponent()
        {
            // Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            _gameList.AddGame(player1, player2);

            // Act
            var result = _gameList.FindOpponentOfDisplayName("Player1");

            // Assert
            Assert.That(result, Is.SameAs(player2));
        }

        [Test]
        public void FindOpponentOfDisplayName_ShouldReturnNull_WhenPlayerNotFound()
        {
            // Act
            var result = _gameList.FindOpponentOfDisplayName("NonExistent");

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void FindOpponentOfDisplayName_ShouldThrowException_WhenDisplayNameIsNull()
        {
            // Act & Assert
            Assert.That(() => _gameList.FindOpponentOfDisplayName(null),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("El jugador no puede estar vacío"));
        }

        [Test]
        public void FindGameByPlayerDisplayName_ShouldReturnCorrectGame()
        {
            // Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = _gameList.AddGame(player1, player2);

            // Act
            var result = _gameList.FindGameByPlayerDisplayName("Player1");

            // Assert
            Assert.That(result, Is.SameAs(game));
        }

        [Test]
        public void FindGameByPlayerDisplayName_ShouldReturnNull_WhenGameNotFound()
        {
            // Act
            var result = _gameList.FindGameByPlayerDisplayName("NonExistent");

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void FindGameByPlayerDisplayName_ShouldThrowException_WhenDisplayNameIsNull()
        {
            // Act & Assert
            Assert.That(() => _gameList.FindGameByPlayerDisplayName(null),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("El jugador no puede estar vacío"));
        }
    }
}
