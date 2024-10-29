using ClassLibrary;
using NUnit.Framework;

namespace ClassLibrary.Tests;

public class TurnTests
{
    [Test]
    public void TurnInitialization_ReturnsPlayer1()
    {
        Player player1 = new Player();
        Player player2 = new Player();

        Turn turn = new Turn(player1, player2);

        Assert.That(turn.CurrentPlayer, Is.EqualTo(player1));
    }
}
