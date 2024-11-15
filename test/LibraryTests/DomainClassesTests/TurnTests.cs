using ClassLibrary;
using NUnit.Framework;

namespace ClassLibrary.Tests
{
    public class TurnTests
    {
        private Turn turn;
        private Player _player1;
        private Player _player2;

        [SetUp]
        public void Setup()
        {
            _player1 = new Player("Player 1");
            _player2 = new Player("Player 2");
            turn = new Turn(_player1, _player2);
        }

        [Test]
        public void Constructor_NullPlayer1_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.That(() => new Turn(null, _player2), Throws.ArgumentNullException);
        }

        [Test]
        public void Constructor_NullPlayer2_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.That(() => new Turn(_player1, null), Throws.ArgumentNullException);
        }

        [Test]
        public void Constructor_ValidPlayers_InitializesCurrentAndWaitingPlayers()
        {
            // Assert
            Assert.That(turn.CurrentPlayer, Is.EqualTo(_player1));
            Assert.That(turn.WaitingPlayer, Is.EqualTo(_player2));
        }

        [Test]
        public void ChangeTurn_SwitchesCurrentAndWaitingPlayers()
        {
            // Act
            turn.ChangeTurn();

            // Assert
            Assert.That(turn.CurrentPlayer, Is.EqualTo(_player2));
            Assert.That(turn.WaitingPlayer, Is.EqualTo(_player1));
        }

        [Test]
        public void PenalizeTurn_CurrentPlayer_ChangesTurn()
        {
            // Arrange
            var initialCurrentPlayer = turn.CurrentPlayer;

            // Act
            turn.PenalizeTurn(turn.CurrentPlayer);

            // Assert
            Assert.That(turn.CurrentPlayer, Is.Not.EqualTo(initialCurrentPlayer));
        }

        [Test]
        public void PenalizeTurn_WaitingPlayer_DoesNotChangeTurn()
        {
            // Arrange
            var initialCurrentPlayer = turn.CurrentPlayer;

            // Act
            turn.PenalizeTurn(turn.WaitingPlayer);

            // Assert
            Assert.That(turn.CurrentPlayer, Is.EqualTo(initialCurrentPlayer));
        }

        [Test]
        public void PenalizeTurn_NullPlayer_DoesNotChangeTurn()
        {
            // Arrange
            var initialCurrentPlayer = turn.CurrentPlayer;

            // Act
            turn.PenalizeTurn(null);

            // Assert
            Assert.That(turn.CurrentPlayer, Is.EqualTo(initialCurrentPlayer));
        }
    }
}
