namespace ClassLibrary.Tests;

using NUnit.Framework;
using ClassLibrary;

public class UserStory8Tests
{
    [SetUp]
    public void StartBattle()
    {
        Facade.Instance.AddPlayerToWaitingList("player1");
        Facade.Instance.AddPlayerToWaitingList("player2");
        Facade.Instance.StartBattle("player1", "player2");

        Facade.Instance.ChoosePokemons("player1",
            new[] { "Blaziken", "Tinkaton", "Salamence", "Bellsprout", "Zangoose", "Rayquaza" });
    }


    [Test]
    public void PlayerUseItem_WhenPlayerAndItemExist()
    {
        string message = Facade.Instance.PlayerUseItem("player1", "SuperPocion");
        Assert.That(message, Is.EqualTo("player1 ha usado SuperPocion. Blaziken ha recuperado 70 puntos de vida."));
    }


    [Test]
    public void PlayerUseItem_WhenPlayerNotExcist()
    { 
        //string message = Facade.Instance.PlayerUseItem("playerfalse", "SuperPocion");
        Assert.That(()=> Facade.Instance.PlayerUseItem("playerfalse", "SuperPocion"), Throws.InstanceOf<Exception>());
    }
    
    [Test]
    public void PlayerUseItem_WhenItemNotExist()
    {
        //string message = Facade.Instance.PlayerUseItem("player1", "PocionFalse");
        //Assert.That(message, Is.EqualTo("No existe el ítem PocionFalse en el inventario."));
        Assert.That(()=> Facade.Instance.PlayerUseItem("player1", "FalsePocion"), Throws.InstanceOf<Exception>());
    }
}