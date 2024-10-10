using ClassLibrary;
using NUnit.Framework;

namespace Tests;

public class TurnTests
{
    [Test]
    public void TurnInitialization_ReturnsPlayer1()
    {
        Player player1 = new Player("Player 1");
        Player player2 = new Player("Player 2");

        Turn turn = new Turn(player1, player2);

        Assert.That(turn.CurrentPlayer, Is.EqualTo(player1));
    }
}
