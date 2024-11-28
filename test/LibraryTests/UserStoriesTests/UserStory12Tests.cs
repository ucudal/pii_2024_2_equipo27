namespace ClassLibrary.Tests;

using NUnit.Framework;
using ClassLibrary;

public class UserStory12Tests
{
    [TearDown]
    public void TearDown()
    {
        Facade.Reset();
    }

    private string attacker = "player1";
    private string defender = "player2";
    private string[] attackerPokemons = new string[] { "Blaziken", "Tinkaton", "Salamence", };
    private string[] defenderPokemons = new string[] { "Tinkaton", "Zangoose", "Rayquaza", };
    private string move = "Patada Ígnea";
    private string move2 = "Carantoña";

    [SetUp]
    public void SetUp()
    {
        Facade.Instance.AddPlayerToWaitingList(attacker);
        Facade.Instance.AddPlayerToWaitingList(defender);
        Facade.Instance.StartBattle(attacker, defender);

        Facade.Instance.ChoosePokemons(attacker, attackerPokemons);
        Facade.Instance.ChoosePokemons(defender, defenderPokemons);
        Facade.Instance.ChooseMoveToAttack(attacker, move);
        Facade.Instance.ChooseMoveToAttack(defender, move2);
    }

    [Test]
    public void ShowCurrentWinner_WhenStringIsEmpty_ReturnsException()
    {
        Assert.That(() => Facade.Instance.ShowCurrentWinner(""), Throws.InstanceOf<Exception>());
        Assert.That(() => Facade.Instance.ShowCurrentWinner(null), Throws.InstanceOf<Exception>());
    }

    [Test]
    public void ShowCurrentWinner_WhenHealthDiminished_ReturnsCorrectPlayer()
    {
        Player playerDefender = Facade.Instance.GameList.FindPlayerByDisplayName(defender);
        Player playerAttacker = Facade.Instance.GameList.FindPlayerByDisplayName(attacker);

        foreach (var pokemon in playerDefender.AvailablePokemons)
        {
            pokemon.HealthPoints -= 20;
        }

        foreach (var pokemon in playerAttacker.AvailablePokemons)
        {
            pokemon.HealthPoints -= 10;
        }

        Assert.That(() => Facade.Instance.ShowCurrentWinner("player1"),
            Is.EqualTo("El jugador con ventaja actualmente es player1"));
    }
}