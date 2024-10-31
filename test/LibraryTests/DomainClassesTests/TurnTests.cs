using ClassLibrary;
using NUnit.Framework;

namespace ClassLibrary.Tests;

public class TurnTests
{
    [Test]
    public void TurnInitialization_ReturnsPlayer1_CurrentPlayer()
    {
        Player player1 = new Player();
        Player player2 = new Player();

        Turn turn = new Turn(player1, player2);

        Assert.That(turn.CurrentPlayer, Is.EqualTo(player1));
    }
    [Test]
    public void TurnInitialization_ReturnsPlayer2_WaitingPlayer()
    {
        Player player1 = new Player();
        Player player2 = new Player();
        Turn turn = new Turn(player1, player2);
        Assert.That(turn.WaitingPlayer, Is.EqualTo(player2));
    }
    [Test]
    public void ChangeTurn_ShouldSwitchPlayers()
    {
         // Act
        Player player1 = new Player();
        Player player2 = new Player();
        Turn turn = new Turn(player1, player2);
        turn.ChangeTurn();
         // Assert
        Assert.That(turn.WaitingPlayer, Is.EqualTo(player1));
        Assert.That(turn.CurrentPlayer, Is.EqualTo(player2));
    }
        [Test]
        public void PenalizeTurn_ShouldChangeTurn_WhenCurrentPlayerIsPenalized()
        {
            // Arrange
            Player player1 = new Player();
            Player player2 = new Player();
            Turn turn = new Turn(player1, player2);

            // Act
            turn.PenalizeTurn(player1);
            
            // Assert
            Assert.That(player1, Is.EqualTo(turn.WaitingPlayer));
            Assert.That(player2, Is.EqualTo(turn.CurrentPlayer));
        }

        [Test]
        public void PenalizeTurn_ShouldChangeTurn_WhenWaitingPlayerIsPenalized()
        {
            // Act
            Player player1 = new Player();
            Player player2 = new Player();
            Turn turn = new Turn(player1, player2);
            turn.ChangeTurn();
            turn.PenalizeTurn(player2);

            // Assert
            Assert.That(player2, Is.EqualTo(turn.PenalizedPlayer));
            Assert.That(player1, Is.EqualTo(turn.CurrentPlayer));
        }


}
