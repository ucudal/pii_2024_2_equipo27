namespace ClassLibrary.Tests;

using NUnit.Framework;
using ClassLibrary;

public class UserStory9Tests
{
    [TearDown]
    public void TearDown()
    {
        Facade.Reset();
    }

    [Test]
    public void AddPlayerToWaitingList_WhenTrainerWasNotAdded_ReturnsAdded()
    {
        string result = Facade.Instance.AddPlayerToWaitingList("user");

        Assert.That(result, Is.EqualTo("user agregado a la lista de espera"));
    }

    [Test]
    public void AddPlayerToWaitingList_WhenTrainerWasAdded_ReturnsExisting()
    {
        Facade.Instance.AddPlayerToWaitingList("user");

        string result = Facade.Instance.AddPlayerToWaitingList("user");

        Assert.That(result, Is.EqualTo("user ya está en la lista de espera"));
    }

    // [Test]
    // public void RemovePlayerFromWaitingList_WhenTrainerWasAdded_ReturnsRemoved()
    // {
    //     Facade.Instance.RemovePlayerFromWaitingList("user");
    //
    //     string result = Facade.Instance.RemovePlayerFromWaitingList("user");
    //
    //     Assert.That(result, Is.EqualTo("user removido de la lista de espera"));
    // }

    [Test]
    public void RemovePlayerFromWaitingList_WhenTrainerWasNotAdded_ReturnsNotAdded()
    {
        string result = Facade.Instance.RemovePlayerFromWaitingList("user");

        Assert.That(result, Is.EqualTo("user no está en la lista de espera"));
    }
}