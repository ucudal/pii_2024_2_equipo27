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
            Facade.Instance.ChooseMoveToAttack(attacker, move);
            Facade.Instance.ChooseMoveToAttack(defender, move2);

            // Obtener el defensor y su Pokémon activo antes del ataque
            Player defenderPlayer = Facade.Instance.GameList.FindPlayerByDisplayName(defender);
            
            int healthPointsBefore = defenderPlayer.ActivePokemon.HealthPoints;

            // Act
            string result = Facade.Instance.PlayerAttack(attacker);

            // Obtener los puntos de salud después del ataque
            int healthPointsAfter = defenderPlayer.ActivePokemon.HealthPoints;

            // Assert
            Assert.That(result, Is.EqualTo(
                $" Jugador {attacker} usa al Pokémon {attackerPokemons[0]} que ataca con {move} a {defenderPokemons[0]} de {defender}, HP pasa de {healthPointsBefore} a {healthPointsAfter}"));
        }

        [Test]
        public void PlayerAttack_ThrowExepcion()
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

            //Act

            string result = Facade.Instance.PlayerAttack(attacker);

            //Assert
            Assert.That(() => Facade.Instance.PlayerAttack(""), Throws.InstanceOf<Exception>());

        }
        [Test]
        public void PlayerAttack_ShouldReduceHealth_WhenAttackIsExecuted()
        {
            // Act
            Facade.Instance.PlayerAttack(attacker);

            // Assert
            string healthInfo = Facade.Instance.GetPokemonsHealth(defender);
            Assert.That(healthInfo, Does.Contain("Tinkaton").And.Not.Contain("Max HP")); // Ensure HP reduced
        }

        //[Test]
        public void ExecuteMove_ShouldCauseExpectedDamage_WhenUsingConstantDamage()
        {
            // Arrange
            //var constantDamage = new ConstantGenerator(50);
            //Facade.Instance.GetPokemonsHealth(constantDamage);

            // Act
            // Facade.Instance.PlayerAttack(attacker);

            // Assert
            //string healthInfo = Facade.Instance.GetPokemonsHealth(defender);
            //Assert.That(healthInfo, Does.Contain("Tinkaton").And.Contain("-50 HP"));
        }
    }
}    
    



      