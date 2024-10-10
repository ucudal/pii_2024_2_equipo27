using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    public class PokemonTypeTest
    {
        [Test]
        public void GetEffectiveness_FireAgainstGrass_ReturnsSuperEffective()
        {
            // Arrange
            PokemonType.Type attacker = PokemonType.Type.Fire;
            PokemonType.Type defender = PokemonType.Type.Grass;

            // Act
            double effectiveness = PokemonType.GetEffectiveness(attacker, defender);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(2.0));
        }

        [Test]
        public void GetEffectiveness_FireAgainstWater_ReturnsNotVeryEffective()
        {
            // Arrange
            PokemonType.Type attacker = PokemonType.Type.Fire;
            PokemonType.Type defender = PokemonType.Type.Water;

            // Act
            double effectiveness = PokemonType.GetEffectiveness(attacker, defender);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(0.5));
        }

        [Test]
        public void GetEffectiveness_WaterAgainstFire_ReturnsSuperEffective()
        {
            // Arrange
            PokemonType.Type attacker = PokemonType.Type.Water;
            PokemonType.Type defender = PokemonType.Type.Fire;

            // Act
            double effectiveness = PokemonType.GetEffectiveness(attacker, defender);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(2.0));
        }

        [Test]
        public void GetEffectiveness_SameType_ReturnsNotVeryEffective()
        {
            // Arrange
            PokemonType.Type attacker = PokemonType.Type.Fire;
            PokemonType.Type defender = PokemonType.Type.Fire;

            // Act
            double effectiveness = PokemonType.GetEffectiveness(attacker, defender);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(0.5));
        }

        [Test]
        public void GetEffectiveness_UnknownTypeCombination_ReturnsNormalEffectiveness()
        {
            // Arrange
            PokemonType.Type attacker = PokemonType.Type.Fire;
            PokemonType.Type defender = PokemonType.Type.Psychic; // Este no está en el diccionario

            // Act
            double effectiveness = PokemonType.GetEffectiveness(attacker, defender);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(1.0)); // Sin ventaja o desventaja conocida
        }
    }
}
