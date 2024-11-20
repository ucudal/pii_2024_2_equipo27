namespace ClassLibrary.Tests;
using NUnit.Framework;
using ClassLibrary;
public class UserStory6Tests
{
    [SetUp]
    public void SetUp()
    {
        Facade.Reset();
    }
    [Test]
    public void Add_WaitingPlayer_To_WaitingList()
    {
        Player player1 = new Player(displayName: "Player 1");
        Player player2 = new Player(displayName: "Player 2");
        
        Facade.Instance.AddPlayerToWaitingList("Player 1");
        Facade.Instance.AddPlayerToWaitingList("Player 2");
        
        //Assert
        Assert.That(Facade.Instance.PlayerIsWaiting("Player 1"), Is.EqualTo("Player 1 está esperando"));
        
        
        
        
    }
    [Test]
    public void Player_Attack_Each_Other()
    {
        Player player1 = new Player(displayName: "Player 1");
        Player player2 = new Player(displayName: "Player 2");
        
        
        // Arrange
        Facade.Instance.GameList.AddGame(new Player("Player1"), new Player("Player2"));
        Facade.Instance.ChoosePokemons("Player1", new string[] { "Mew", "Blaziken","Tinkaton", "Salamence", "Jigglypuff" });
        Facade.Instance.ChoosePokemons("Player2", new string[] { "Mew", "Blaziken","Tinkaton", "Salamence", "Jigglypuff" });
        Facade.Instance.ChooseMoveToAttack( "Player1",  "Corte");
        Facade.Instance.ChooseMoveToAttack("Player2", "Psíquico");
        
        // Act
        string result = Facade.Instance.PlayerAttack("Player1");
        string expected =" Jugador Player1 usa al Pokémon Mew que ataca con Corte a Mew de Player2";
        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }
        
}