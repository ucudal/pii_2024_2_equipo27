using NUnit.Framework;

namespace ClassLibrary.Tests
{
    [TestFixture]
    public class EffectivenessTableTests
    {
        [Test]
        public void GetEffectiveness_FireVsGrass_ShouldReturn2()
        {
            // Arrange
            var attackingType = Type.Fire;
            var defendingType = Type.Grass;
            var expectedEffectiveness = 2.0;

            // Act
            var effectiveness = EffectivenessTable.GetEffectiveness(defendingType, attackingType);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(expectedEffectiveness),
                "Fire vs Grass should return an effectiveness of 2.0.");
        }

        [Test]
        public void GetEffectiveness_WaterVsFire_ShouldReturn2()
        {
            // Arrange
            var attackingType = Type.Water;
            var defendingType = Type.Fire;
            var expectedEffectiveness = 2.0;

            // Act
            var effectiveness = EffectivenessTable.GetEffectiveness(defendingType, attackingType);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(expectedEffectiveness),
                "Water vs Fire should return an effectiveness of 2.0.");
        }

        [Test]
        public void GetEffectiveness_FireVsWater_ShouldReturn05()
        {
            // Arrange
            var attackingType = Type.Fire;
            var defendingType = Type.Water;
            var expectedEffectiveness = 0.5;

            // Act
            var effectiveness = EffectivenessTable.GetEffectiveness(defendingType, attackingType);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(expectedEffectiveness),
                "Fire vs Water should return an effectiveness of 0.5.");
        }

        [Test]
        public void GetEffectiveness_FireVsRock_ShouldReturn05()
        {
            // Arrange
            var attackingType = Type.Fire;
            var defendingType = Type.Rock;
            var expectedEffectiveness = 0.5;

            // Act
            var effectiveness = EffectivenessTable.GetEffectiveness(defendingType, attackingType);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(expectedEffectiveness),
                "Fire vs Fire should return an effectiveness of 0.5.");
        }

        [Test]
        public void GetEffectiveness_WaterVsPsychic_ShouldReturn1()
        {
            // Arrange
            var attackingType = Type.Water;
            var defendingType = Type.Psychic;
            var expectedEffectiveness = 1.0;

            // Act
            var effectiveness = EffectivenessTable.GetEffectiveness(defendingType, attackingType);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(expectedEffectiveness),
                "Water vs Steel should return an effectiveness of 1.0 (no advantage).");
        }

        [Test]
        public void GetEffectiveness_DragonVsDragon_ShouldReturn2()
        {
            // Arrange
            var attackingType = Type.Dragon;
            var defendingType = Type.Dragon;
            var expectedEffectiveness = 2.0;

            // Act
            var effectiveness = EffectivenessTable.GetEffectiveness(defendingType, attackingType);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(expectedEffectiveness),
                "Dragon vs Dragon should return an effectiveness of 2.0.");
        }
    }
}