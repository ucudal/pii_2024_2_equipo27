namespace ClassLibrary.Tests;

using NUnit.Framework;


    [TestFixture]
    public class GameTests
    {
        private Game game;
        private Player player1;
        private Player player2;

        [SetUp]
        public void Setup()
        {
            player1 = new Player("Sebastian");
            player2 = new Player("Juan");
            game = new Game(player1, player2);
        }

        [Test]
        public void Constructor_ShouldInitializePlayers()
        {
            // Assert
            Assert.That(game.Player1, Is.EqualTo(player1));
            Assert.That(game.Player2, Is.EqualTo(player2));
        }

        [Test]
        public void StartGame_ShouldSetPlayIsOnToTrue()
        {
            // Act
            game.StartGame();

            // Assert
            Assert.That(game.PlayIsOn, Is.True);
        }

        [Test]
        public void EndGame_ShouldSetPlayIsOnToFalse()
        {
            // Act
            game.StartGame();

            // Assert
            Assert.That(game.PlayIsOn, Is.True);
        }
        
    }

