namespace ClassLibrary.Tests;

using NUnit.Framework;
using ClassLibrary;

public class UserStoryGetCurrentTurnPlayerTests
{
    [SetUp]
    public void StartBattle()
    {
        // Configuración inicial para simular una partida
        Facade.Instance.AddPlayerToWaitingList("player1");
        Facade.Instance.AddPlayerToWaitingList("player2");
        Facade.Instance.StartBattle("player1", "player2");

        Facade.Instance.ChoosePokemons("player1",
            new[] { "Blaziken", "Pikahu", "Salamence", "Bellsprout", "Zangoose", "Rayquaza" });

        Facade.Instance.ChoosePokemons("player2",
            new[] { "Charizard", "Lucario", "Pikachu", "Lapras", "Gengar", "Tyranitar" });
    }

    [Test]
    public void GetCurrentTurnPlayer_WhenPlayerIsInGame_ReturnsCurrentTurnPlayer()
    {
        // Act
        string message = Facade.Instance.GetCurrentTurnPlayer("player1");
        
        Assert.That(message, Is.EqualTo("Es el turno de player1"));
    }
    

    [Test]
    public void GetCurrentTurnPlayer_WhenPlayerDoesNotExist_ThrowsException()
    {
        
        Assert.That(() => Facade.Instance.GetCurrentTurnPlayer("nonexistentplayer"), Throws.InstanceOf<Exception>());
    }
}