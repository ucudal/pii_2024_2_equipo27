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
        List<string> messages = Facade.Instance.ShowMoves(attacker);
        Assert.That(messages.Count, Is.EqualTo(3));
        Assert.That(messages[0], Does.Contain(attackerPokemons[0]));
    }
}