namespace ClassLibrary.Tests;
using NUnit.Framework;
using ClassLibrary;

public class UserStory10Tests
{
    [TearDown]
    public void TearDown()
    {
        Facade.Reset();
    }

    [Test]
    public void GetAllPlayersWaiting_WhenNobodyIsWaiting_ReturnsNobodyIsWaiting()
    {
        string result = Facade.Instance.GetAllPlayersWaiting();
        
        Assert.That(result, Is.EqualTo("No hay nadie esperando"));
    }
    
    [Test]
    public void GetAllPlayersWaiting_WhenSomebodyIsWaiting_ReturnsSomebody()
    {
        Facade.Instance.AddPlayerToWaitingList("user");
        
        string result = Facade.Instance.GetAllPlayersWaiting();
        
        Assert.That(result, Does.Contain("user"));
    }
}