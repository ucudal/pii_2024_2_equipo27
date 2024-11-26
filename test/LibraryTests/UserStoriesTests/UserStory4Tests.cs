namespace ClassLibrary.Tests
{
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
            Facade.Instance.ChooseMoveToAttack( attacker,  move);
            Facade.Instance.ChooseMoveToAttack( defender,  move2);
            
            //Act
            string result = Facade.Instance.PlayerAttack(attacker);
            
            //Assert
            Assert.That(result, Is.EqualTo(
                $" Jugador {attacker} usa al Pokémon {attackerPokemons[0]} que ataca con {move} a {defenderPokemons[0]} de {defender}"));
           
        }
    }
}
