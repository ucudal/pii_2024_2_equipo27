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
        Facade.Instance.ChooseMoveToAttack( attacker,  move);
        Facade.Instance.ChooseMoveToAttack( defender,  move2);
    }

    [Test] 
    public void Player_Pokemon_Receive_Special_Attack()
    {
        string messages = Facade.Instance.ShowMoves(attacker);
        
        Assert.That(messages[0], Does.Contain(attackerPokemons[0]));
    }
    [Test]
    public void ShowMoves_ShouldReturnMovesOfActivePokemon()
    {
        // Act
        string moves = Facade.Instance.ShowMoves(attacker);

        // Assert
        Assert.That(moves.Split(',').Length, Is.EqualTo(3)); // Verifica que hay 3 movimientos disponibles
        Assert.That(moves, Does.Contain(move)); // Verifica que el movimiento "Patada Ígnea" está presente
    }

    [Test]
    public void ShowPlayerItems_ShouldReturnItemsAndQuantities()
    {
        // Arrange
        string itemResult = Facade.Instance.ShowPlayerItems(attacker);

        // Assert
        Assert.That(itemResult, Does.Contain("Super Potion")); // Verifica que el ítem "Super Potion" está listado
        Assert.That(itemResult, Does.Contain("Revive")); // Verifica que el ítem "Revive" está listado
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