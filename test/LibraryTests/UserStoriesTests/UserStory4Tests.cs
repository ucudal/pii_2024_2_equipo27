namespace ClassLibrary.Tests
{
    using NUnit.Framework;
    using ClassLibrary;
    using System.Collections.Generic;

    public class UserStory4Tests
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
        public void PlayerAttack_Works_Correctly()
        {
            // Ejecutar el ataque 
            string message = Facade.Instance.PlayerAttack(attacker);

            Assert.That(message, Does.Contain(
                $"""
                 Jugador {attacker} usa al Pokémon {attackerPokemons[0]} que ataca con {move} a {defenderPokemons[0]} de {defender}
                 """));
        }
    }
}
