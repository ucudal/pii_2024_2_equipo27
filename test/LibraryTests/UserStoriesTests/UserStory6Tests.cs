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
        
}