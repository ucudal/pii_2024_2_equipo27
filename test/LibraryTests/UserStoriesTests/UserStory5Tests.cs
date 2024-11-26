namespace ClassLibrary.Tests;

using NUnit.Framework;
using ClassLibrary;

public class UserStory5Tests
{
    [SetUp]
    public void StartBattle()
    {
        // Configuración inicial para simular una partida
        Facade.Instance.AddPlayerToWaitingList("player1");
        Facade.Instance.AddPlayerToWaitingList("player2");
        Facade.Instance.StartBattle("player1", "player2");

        Facade.Instance.ChoosePokemons("player1",
            new[] { "Blaziken", "Lapras", "Salamence", "Bellsprout", "Zangoose", "Rayquaza" });

        Facade.Instance.ChoosePokemons("player2",
            new[] { "Charizard", "Lucario", "Pikachu", "Lapras", "Gengar", "Gengar" });
    }

    [Test]
    public void GetCurrentTurnPlayer_WhenPlayerIsInGame_ReturnsCurrentTurnPlayer()
    {
        // Act
        string message = Facade.Instance.GetCurrentTurnPlayer("player2");

        Assert.That(message, Is.EqualTo("\ud83c\udfae Es el turno de player1."));
    }


    [Test]
    public void GetCurrentTurnPlayer_WhenPlayerDoesNotExist_ThrowsException()
    {
        Assert.That(() => Facade.Instance.GetCurrentTurnPlayer("nonexistentplayer"), Throws.InstanceOf<Exception>());
    }
}