namespace ClassLibrary.Tests
{
    using NUnit.Framework;
    using ClassLibrary;
    using System.Collections.Generic;

    public class UserStory4
    {
        private string attacker = "player1";
        private string defender = "player2";
        private string[] attackerPokemons = new string[] { "Blaziken", "Tinkaton", "Salamence", };
        private string[] defenderPokemons = new string[] { "Bellsprout", "Zangoose", "Rayquaza", };
        private string move = "Absorber";

        [SetUp]
        public void SetUp()
        {
            Facade.Instance.AddPlayerToWaitingList(attacker);
            Facade.Instance.AddPlayerToWaitingList(defender);
            Facade.Instance.StartBattle(attacker, defender);
            Facade.Instance.ChoosePokemons(attacker, attackerPokemons);
        }

        [Test]
        public void PlayerAttack_WithEffectiveMove_AppliesIncreasedDamage()
        {
            // Ejecutar el ataque con efectividad de tipo (Fuego vs Planta)
            string message = Facade.Instance.PlayerAttack(attacker, defender, move);

            Assert.That(message, Does.Contain(
                $"""
                 Jugador {attacker} usa al Pokémon {attackerPokemons[0]} que ataca 
                 con {move} a {defenderPokemons[0]} de {defender}";
                 """));
        }
    }
}
