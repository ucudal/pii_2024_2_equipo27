namespace ClassLibrary.Tests;
using NUnit.Framework;
using ClassLibrary;

public class UserStory3Tests
{
    [TearDown]
    public void TearDown()
    {
        Facade.Reset();
    }

    [Test]
    public void GetPokemonsHealth_WhenPlayerAndOpponentExist_ReturnsHealthInfoMessage()
    {
        // Arrange
        Facade.Instance.GameList.AddGame(new Player("player1"), new Player("player2"));
        Facade.Instance.ChoosePokemons("player1", new string[] { "Mew", "Blaziken", "Tinkaton", "Salamence", "Jigglypuff" });
        Facade.Instance.ChoosePokemons("player2", new string[] { "Mew", "Blaziken", "Tinkaton", "Salamence", "Jigglypuff" });

        // Act
        string result = Facade.Instance.GetPokemonsHealth("player1");
        string expected = UserInterface.ShowMessagePokemonHealth(
            Facade.Instance.GameList.FindPlayerByDisplayName("player1").AvailablePokemons,
            Facade.Instance.GameList.FindPlayerByDisplayName("player2").AvailablePokemons
        );

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GetPokemonsHealth_WhenParameterPlayerDisplayName_IsNullOrEmpty_ThrowsArgumentNullException()
    {
        // Arrange
        Facade.Instance.GameList.AddGame(new Player("player1"), new Player("player2"));

        // Act & Assert
        Assert.That(() => Facade.Instance.GetPokemonsHealth(null), Throws.ArgumentNullException.With.Message.EqualTo("El nombre del jugador no puede ser nulo o estar vacío."));
    }

    [Test]
    public void GetPokemonsHealth_WhenPlayerDoesNotExist_ThrowsArgumentException()
    {
        // Arrange
        Facade.Instance.GameList.AddGame(new Player("player2"), new Player("player3"));

        // Act & Assert
        Assert.That(() => Facade.Instance.GetPokemonsHealth("player1"), Throws.ArgumentException.With.Message.EqualTo("El jugador 'player1' no está jugando."));
    }

    [Test]
    public void GetPokemonsHealth_WhenOpponentDoesNotExist_ThrowsArgumentException()
    {
        // Arrange
        Facade.Instance.GameList.AddGame(new Player("player1"), null); 

        // Act & Assert
        Assert.That(() => Facade.Instance.GetPokemonsHealth("player1"), Throws.ArgumentException.With.Message.EqualTo("No se encontró el oponente del jugador player1."));
    }
}
