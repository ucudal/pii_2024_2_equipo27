namespace ClassLibrary.Tests
{
    using NUnit.Framework;
    using ClassLibrary;
    using System.Collections.Generic;

    public class PlayerAttackTests
    {
        private Pokemon attacker;
        private Pokemon defender;
        private Move move;

        [SetUp]
        public void SetUp()
        {
            // Configuración inicial del atacante y defensor con sus tipos, HP y movimiento
            attacker = new Pokemon
            {
                Name = "Charizard",
                Type = PokemonType.Type.Fire,
                HealthPoints = 100,
                Moves = new List<Move>(),
                SpecialMove = new Move("Flamethrower", 50, 0,0) // Movimiento especial como ejemplo
            };
            move = new Move("Flamethrower", 50,0,0); // Movimiento a utilizar en las pruebas
            attacker.AddMove(move); // Añadir el movimiento a la lista de movimientos

            defender = new Pokemon
            {
                Name = "Bulbasaur",
                Type = PokemonType.Type.Grass,
                HealthPoints = 100,
                Moves = new List<Move>()
            };
        }

        [Test]
        public void PlayerAttack_WithEffectiveMove_AppliesIncreasedDamage()
        {
            // Ejecutar el ataque con efectividad de tipo (Fuego vs Planta)
            Facade.Instance.PlayerAttack("user", "oponent", "move");

            // Calculamos el HP esperado después del ataque efectivo
            int expectedHealth = 100 - (int)(50 * 2.0); // 2.0 es el multiplicador de efectividad
            Assert.That(defender.HealthPoints, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void PlayerAttack_WithNotVeryEffectiveMove_AppliesReducedDamage()
        {
            // Cambiamos el tipo del defensor a uno que resista (Fuego vs Fuego)
            defender.Type = PokemonType.Type.Fire;

            // Ejecutar el ataque
            Facade.Instance.PlayerAttack("user", "oponent", "move");

            // Calculamos el HP esperado con daño reducido (0.5 de multiplicador)
            int expectedHealth = 100 - (int)(50 * 0.5);
            Assert.That(defender.HealthPoints, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void PlayerAttack_WithNormalEffectiveness_AppliesBaseDamage()
        {
            // Cambiamos el tipo del defensor a uno sin ventaja ni desventaja (Eléctrico)
            defender.Type = PokemonType.Type.Electric;

            // Ejecutar el ataque
            Facade.Instance.PlayerAttack("user", "oponent", "move");

            // Daño sin modificador de efectividad
            int expectedHealth = 100 - 50;
            Assert.That(defender.HealthPoints, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void PlayerAttack_WithInvalidParameters_ThrowsArgumentException()
        {
            // Verificamos que la excepción se lanza al pasar parámetros nulos
            Assert.Throws<ArgumentException>(() => Facade.Instance.PlayerAttack(null, "oponent", "move"));
            Assert.Throws<ArgumentException>(() => Facade.Instance.PlayerAttack("user", null, "move"));
            Assert.Throws<ArgumentException>(() => Facade.Instance.PlayerAttack("user", "oponent", null));
        }

        [TearDown]
        public void TearDown()
        {
            Facade.Reset();
        }
    }
}
