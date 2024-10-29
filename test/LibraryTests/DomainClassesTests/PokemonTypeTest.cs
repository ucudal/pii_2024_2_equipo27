using NUnit.Framework;

namespace ClassLibrary.Tests
{
    [TestFixture]
    public class PokemonTypeTests
    {
        [Test]
        public void GetEffectiveness_FireVsGrass_ShouldReturn2()
        {
            // Arrange
            var attackingType = PokemonType.Type.Fire;
            var defendingType = PokemonType.Type.Grass;
            var expectedEffectiveness = 2.0;

            // Act
            var effectiveness = PokemonType.GetEffectiveness(attackingType, defendingType);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(expectedEffectiveness), 
                        "Fire vs Grass should return an effectiveness of 2.0.");
        }

        [Test]
        public void GetEffectiveness_WaterVsFire_ShouldReturn2()
        {
            // Arrange
            var attackingType = PokemonType.Type.Water;
            var defendingType = PokemonType.Type.Fire;
            var expectedEffectiveness = 2.0;

            // Act
            var effectiveness = PokemonType.GetEffectiveness(attackingType, defendingType);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(expectedEffectiveness), 
                        "Water vs Fire should return an effectiveness of 2.0.");
        }

        [Test]
        public void GetEffectiveness_FireVsWater_ShouldReturn05()
        {
            // Arrange
            var attackingType = PokemonType.Type.Fire;
            var defendingType = PokemonType.Type.Water;
            var expectedEffectiveness = 0.5;

            // Act
            var effectiveness = PokemonType.GetEffectiveness(attackingType, defendingType);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(expectedEffectiveness), 
                        "Fire vs Water should return an effectiveness of 0.5.");
        }

        [Test]
        public void GetEffectiveness_FireVsFire_ShouldReturn05()
        {
            // Arrange
            var attackingType = PokemonType.Type.Fire;
            var defendingType = PokemonType.Type.Fire;
            var expectedEffectiveness = 0.5;

            // Act
            var effectiveness = PokemonType.GetEffectiveness(attackingType, defendingType);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(expectedEffectiveness), 
                        "Fire vs Fire should return an effectiveness of 0.5.");
        }

        [Test]
        public void GetEffectiveness_WaterVsSteel_ShouldReturn1()
        {
            // Arrange
            var attackingType = PokemonType.Type.Water;
            var defendingType = PokemonType.Type.Steel;
            var expectedEffectiveness = 1.0;

            // Act
            var effectiveness = PokemonType.GetEffectiveness(attackingType, defendingType);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(expectedEffectiveness), 
                        "Water vs Steel should return an effectiveness of 1.0 (no advantage).");
        }

        [Test]
        public void GetEffectiveness_DragonVsDragon_ShouldReturn2()
        {
            // Arrange
            var attackingType = PokemonType.Type.Dragon;
            var defendingType = PokemonType.Type.Dragon;
            var expectedEffectiveness = 2.0;

            // Act
            var effectiveness = PokemonType.GetEffectiveness(attackingType, defendingType);

            // Assert
            Assert.That(effectiveness, Is.EqualTo(expectedEffectiveness), 
                        "Dragon vs Dragon should return an effectiveness of 2.0.");
        }
    }
}
