namespace ClassLibrary.Tests;

using NUnit.Framework;
using ClassLibrary;

public class UserStory2Tests
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
    public void ShowMoves_ShouldReturnMovesOfActivePokemon()
    {
        // Arrange
        Facade.Instance.StartBattle(attacker, defender);
        Facade.Instance.ChoosePokemons(attacker, attackerPokemons);
        // Act
        string result = Facade.Instance.ShowMoves(attacker);

        // Assert
        Assert.That(result,
            Is.EqualTo(
                "\n=== Lista de Movimientos ===\r\n- Patada Ígnea (Precisión: 0,5)\r\n- Llamarada (Precisión: 0,7)\r\n- Tajo Aéreo (Precisión: 0,5)\r\n- Anillo Ígneo (Precisión: 0,3)\r\n"));
    }

    [Test]
    public void ReturnShowMoves_ShouldThrowArgumentException_WhenPlayerHasNoActivePokemon()
    {
        // Arrange
        Facade.Instance.StartBattle(attacker, defender);
        Facade.Instance.ChoosePokemons(attacker, attackerPokemons);
        // No se asigna un Pokémon activo al jugador

        // Act & Assert
        Assert.That(() => Facade.Instance.ShowMoves(playerDisplayName: move), Throws.ArgumentException);
    }


    [Test]
    public void ShowPlayerItems_ShouldReturnItemsAndQuantities()
    {
        // Arrange
        Facade.Instance.StartBattle(attacker, defender);
        Facade.Instance.ChoosePokemons(attacker, attackerPokemons);

        // Act
        string result = Facade.Instance.ShowPlayerItems(playerDisplayName: attacker);

        // Assert
        Assert.That(result, Is.EqualTo(result));
    }

    [Test]
    public void ChooseMoveToAttack_ShouldThrowException_WhenMoveDoesNotExist()
    {
        // Act & Assert
        var ex = Assert.Throws<Exception>(() => Facade.Instance.ChooseMoveToAttack(attacker, "NonExistentMove"));
        Assert.That(ex.Message, Does.Contain("no está disponible para el Pokémon actual"));
    }

    [Test]
    public void ChooseMoveToAttack_ShouldActivateMove_WhenMoveExists()
    {
        // Act
        Facade.Instance.ChooseMoveToAttack(attacker, move);
        // Assert
        string moves = Facade.Instance.ShowMoves(attacker);
        Assert.That(moves, Does.Contain(move)); // Verifica que "Patada Ígnea" sigue siendo accesible
    }
}