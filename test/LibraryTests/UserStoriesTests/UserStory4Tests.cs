namespace ClassLibrary.Tests
{
    using NUnit.Framework;
    using ClassLibrary;
    using System.Collections.Generic;

    public class UserStory4
    {
        private Pokemon attacker;
        private Pokemon defender;
        private Move move;

        [SetUp]
        public void SetUp()
        {
            // Utilizar el catálogo para obtener los Pokémon en lugar de configurarlos manualmente
            PokemonCatalog catalog = new PokemonCatalog();

            // Obtener los Pokémon desde el catálogo
            attacker = catalog.FindPokemonByName("Blaziken");
            defender = catalog.FindPokemonByName("Bulbasaur");

            // // Asegurarse de que los Pokémon existen en el catálogo
            // Assert.NotNull(attacker, "El Pokémon Blaziken no se encontró en el catálogo.");
            // Assert.NotNull(defender, "El Pokémon Bulbasaur no se encontró en el catálogo.");

            // Obtener el movimiento específico para las pruebas
            move = attacker.SpecialMove ?? new Move("Flamethrower", 50, 0, 0); // Usa el movimiento especial si está definido
            //attacker.AddMove(move); // Añadir el movimiento a la lista de movimientos
        }

        [Test]
        public void PlayerAttack_WithEffectiveMove_AppliesIncreasedDamage()
        {
            // Ejecutar el ataque con efectividad de tipo (Fuego vs Planta)
            Facade.Instance.PlayerAttack("user", "move");

            // Calculamos el HP esperado después del ataque efectivo
            int expectedHealth = defender.HealthPoints - (int)(move.AttackValue * 2.0); // 2.0 es el multiplicador de efectividad
            Assert.That(defender.HealthPoints, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void PlayerAttack_WithNotVeryEffectiveMove_AppliesReducedDamage()
        {
            // Cambiamos el tipo del defensor a uno que resista (Fuego vs Fuego)
            defender.Type = PokemonType.Type.Fire;

            // Ejecutar el ataque
            Facade.Instance.PlayerAttack("user", "move");

            // Calculamos el HP esperado con daño reducido (0.5 de multiplicador)
            int expectedHealth = defender.HealthPoints - (int)(move.AttackValue * 0.5);
            Assert.That(defender.HealthPoints, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void PlayerAttack_WithNormalEffectiveness_AppliesBaseDamage()
        {
            // Cambiamos el tipo del defensor a uno sin ventaja ni desventaja (Eléctrico)
            defender.Type = PokemonType.Type.Electric;

            // Ejecutar el ataque
            Facade.Instance.PlayerAttack("user", "move");

            // Daño sin modificador de efectividad
            int expectedHealth = defender.HealthPoints - move.AttackValue;
            Assert.That(defender.HealthPoints, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void PlayerAttack_WithInvalidParameters_ThrowsArgumentException()
        {
            // Verificamos que la excepción se lanza al pasar parámetros nulos
            Assert.Throws<ArgumentException>(() => Facade.Instance.PlayerAttack(null, "move"));
            Assert.Throws<ArgumentException>(() => Facade.Instance.PlayerAttack("user", null));
        }

        [TearDown]
        public void TearDown()
        {
            Facade.Reset();
        }
    }
}
