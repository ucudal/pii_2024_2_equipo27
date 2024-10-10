using NUnit.Framework;

namespace ClassLibrary.Tests
{
    [TestFixture]
    public class MoveTests
    {
        [Test]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            string expectedName = "Fire Blast";
            int expectedAttackValue = 100;
            int expectedDefenseValue = 50;
            int expectedCureValue = 30;

            // Act
            Move move = new Move(expectedName, expectedAttackValue, expectedDefenseValue, expectedCureValue);

            // Assert
            Assert.That(move.Name, Is.EqualTo(expectedName));
            Assert.That(move.AttackValue, Is.EqualTo(expectedAttackValue));
            Assert.That(move.DefenseValue, Is.EqualTo(expectedDefenseValue));
            Assert.That(move.CureValue, Is.EqualTo(expectedCureValue));
        }

        [Test]
        public void AttackValue_ShouldBePositive()
        {
            // Arrange & Act
            Move move = new Move("Slash", 80, 20, 0);

            // Assert
            Assert.That(move.AttackValue, Is.GreaterThan(0), "Attack value should be greater than zero.");
        }

        [Test]
        public void DefenseValue_ShouldBePositive()
        {
            // Arrange & Act
            Move move = new Move("Shield Block", 10, 60, 0);

            // Assert
            Assert.That(move.DefenseValue, Is.GreaterThan(0), "Defense value should be greater than zero.");
        }

        [Test]
        public void CureValue_ShouldBeZeroOrPositive()
        {
            // Arrange & Act
            Move move = new Move("Healing Wind", 0, 0, 25);

            // Assert
            Assert.That(move.CureValue, Is.GreaterThanOrEqualTo(0), "Cure value should be zero or greater.");
        }
    }
}