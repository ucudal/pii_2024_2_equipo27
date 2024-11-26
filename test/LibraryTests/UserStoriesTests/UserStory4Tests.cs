namespace ClassLibrary.Tests;

using NUnit.Framework;
using ClassLibrary;
using System.Collections.Generic;

public class UserStory4Tests
{
    [SetUp]
    public void SetUp()
    {
        Facade.Reset();
    }

    private string attacker = "player1";
    private string defender = "player2";
    private string[] attackerPokemons = new string[] { "Blaziken", "Tinkaton", "Salamence", };
    private string[] defenderPokemons = new string[] { "Tinkaton", "Zangoose", "Rayquaza", };
    private string move = "Patada Ígnea";
    private string move2 = "Carantoña";

    [Test]
    public void PlayerAttack_Works_Correctly()
    {
        // Arrange
        Facade.Instance.GameList.AddGame(new Player(attacker), new Player(defender));
        Facade.Instance.AddPlayerToWaitingList(attacker);
        Facade.Instance.AddPlayerToWaitingList(defender);
        Facade.Instance.StartBattle(attacker, defender);
        Facade.Instance.ChoosePokemons(attacker, attackerPokemons);
        Facade.Instance.ChoosePokemons(defender, defenderPokemons);
        Facade.Instance.ChooseMoveToAttack(attacker, move);
        Facade.Instance.ChooseMoveToAttack(defender, move2);

        // Act
        string result = Facade.Instance.PlayerAttack(attacker);

        // Assert
        Assert.That(result, Is.EqualTo(
            $" Jugador {attacker} usa al Pokémon {attackerPokemons[0]} que ataca con {move} a {defenderPokemons[0]} de {defender}, HP pasa de 100 a 0"));
    }

    [Test]
    public void PlayerAttack_ThrowsException_WhenInvalidPlayerName()
    {
        // Arrange
        Facade.Instance.GameList.AddGame(new Player(attacker), new Player(defender));
        Facade.Instance.AddPlayerToWaitingList(attacker);
        Facade.Instance.AddPlayerToWaitingList(defender);
        Facade.Instance.StartBattle(attacker, defender);
        Facade.Instance.ChoosePokemons(attacker, attackerPokemons);
        Facade.Instance.ChoosePokemons(defender, defenderPokemons);
        Facade.Instance.ChooseMoveToAttack(attacker, move);
        Facade.Instance.ChooseMoveToAttack(defender, move2);

        // Act & Assert
        // Intentar un ataque con un jugador que no existe
        Assert.That(() => Facade.Instance.PlayerAttack(""), Throws.InstanceOf<Exception>());
        
        // Intentar atacar cuando no es tu turno
        Assert.That(() => Facade.Instance.PlayerAttack(defender), Throws.InstanceOf<Exception>());
    }

    [Test]
    public void PlayerAttack_ShouldThrowExceptionIfNotYourTurn()
    {
        // Arrange
        Facade.Instance.GameList.AddGame(new Player(attacker), new Player(defender));
        Facade.Instance.AddPlayerToWaitingList(attacker);
        Facade.Instance.AddPlayerToWaitingList(defender);
        Facade.Instance.StartBattle(attacker, defender);
        Facade.Instance.ChoosePokemons(attacker, attackerPokemons);
        Facade.Instance.ChoosePokemons(defender, defenderPokemons);
        Facade.Instance.ChooseMoveToAttack(attacker, move);
        Facade.Instance.ChooseMoveToAttack(defender, move2);
        
        // Asignar turno al jugador defensor
        Facade.Instance.GameList.FindGameByPlayerDisplayName(attacker).Turn.CurrentPlayer = new Player(defender);

        // Act & Assert
        Assert.That(() => Facade.Instance.PlayerAttack(attacker), Throws.InstanceOf<Exception>().With.Message.EqualTo($"No es tu turno: '{attacker}' "));
    }
    
}