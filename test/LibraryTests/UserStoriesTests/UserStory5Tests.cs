using NUnit.Framework;

namespace ClassLibrary.Tests
{
    public class UserStory5Tests
    {
        [SetUp]
        public void SetUp()
        {
            Facade.Reset();
        }

        [Test]
        public void GetCurrentTurnPlayer_WhenPlayerIsInGame_ReturnsCurrentPlayerTurnMessage()
        {
            // Arrange
            Facade.Instance.AddPlayerToWaitingList("player1");
            Facade.Instance.AddPlayerToWaitingList("player2");
            Facade.Instance.StartBattle("player1", "player2");

            // Act
            string result = Facade.Instance.GetCurrentTurnPlayer("player1");

            // Assert
            Assert.That(result, Is.EqualTo("🎮 Es el turno de player1."));
        }

        [Test]
        public void GetCurrentTurnPlayer_WhenPlayerIsNotInGame_ReturnsNotInGameMessage()
        {
            // Arrange
            // No iniciamos una partida para "player3"

            // Act
            string result = Facade.Instance.GetCurrentTurnPlayer("player3");

            // Assert
            Assert.That(result, Is.EqualTo("El jugador player3 no está en una partida."));
        }
    }
}