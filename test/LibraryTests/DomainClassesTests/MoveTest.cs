using NUnit.Framework;

namespace ClassLibrary.Tests
{
    [TestFixture]
    public class MoveTests
    {
        [Test]
        public void MoveParalizeConstructor_ValidParameters_ShouldSetProperties()
        {
            var move = new MoveParalize("Paralizar", 40, 0.85, Type.Psychic);

            Assert.That(move.Name, Is.EqualTo("Paralizar"));
            Assert.That(move.AttackValue, Is.EqualTo(40));
            Assert.That(move.Accuracy, Is.EqualTo(0.85));
        }

        [Test]
        public void MoveParalizeConstructor_InvalidParameters_ShouldThrowArgumentException()
        {
            Assert.That(() => new MoveParalize(null, 40, 0.85, Type.Psychic), Throws.ArgumentException);
            Assert.That(() => new MoveParalize("", 40, 0.85, Type.Ghost), Throws.ArgumentException);
        }

        [Test]
        public void MoveParalizeExecuteMove_ShouldParalyzeTarget()
        {
            Move[] moves = new Move[]
            {
                new MoveNormal("Patada Ígnea", 80, 0.5, Type.Fire),
                new MoveNormal("Llamarada", 90, 0.7, Type.Fire),
                new MoveNormal("Tajo Aéreo", 70, 0.5, Type.Flying),
                new MoveBurn("Anillo Ígneo", 0, 0.3, Type.Fire)
            };
            var move = new MoveParalize("paralizador", 10, 1.0, Type.Electric);
            var attacker = new Pokemon(moves);
            var target = new Pokemon(moves);

            move.ExecuteMove(attacker, target, 1.0);

            Assert.That(target.IsParalyzed, Is.True);
            Assert.That(target.HealthPoints, Is.LessThan(100));
        }

        [Test]
        public void MovePoisonConstructor_ValidParameters_ShouldSetProperties()
        {
            var move = new MovePoison("Envenenar", 50, 0.8, Type.Poison);

            Assert.That(move.Name, Is.EqualTo("Envenenar"));
            Assert.That(move.AttackValue, Is.EqualTo(50));
            Assert.That(move.Accuracy, Is.EqualTo(0.8));
        }

        [Test]
        public void MovePoisonConstructor_InvalidParameters_ShouldThrowArgumentException()
        {
            Assert.That(() => new MovePoison(null, 50, 0.8, Type.Dragon), Throws.ArgumentException);
            Assert.That(() => new MovePoison("", 50, 0.8, Type.Poison), Throws.ArgumentException);
        }

        [Test]
        public void MovePoisonExecuteMove_ShouldPoisonTarget()
        {
            Move[] moves = new Move[]
            {
                new MoveNormal("Patada Ígnea", 80, 0.5, Type.Fire),
                new MoveNormal("Llamarada", 90, 0.7, Type.Fire),
                new MoveNormal("Tajo Aéreo", 70, 0.5, Type.Flying),
                new MoveBurn("Anillo Ígneo", 0, 0.3, Type.Fire)
            };
            var move = new MovePoison("Envenenar", 40, 0.8, Type.Poison);
            var attacker = new Pokemon(moves);
            var target = new Pokemon(moves);

            move.ExecuteMove(attacker, target, 1.0);

            Assert.That(target.IsPoisoned, Is.True);
            Assert.That(target.HealthPoints, Is.LessThan(100));
        }

        [Test]
        public void MoveSleepConstructor_ValidParameters_ShouldSetProperties()
        {
            var move = new MoveSleep("Dormir", 20, 0.7, Type.Water);

            Assert.That(move.Name, Is.EqualTo("Dormir"));
            Assert.That(move.AttackValue, Is.EqualTo(20));
            Assert.That(move.Accuracy, Is.EqualTo(0.7));
        }

        [Test]
        public void MoveSleepConstructor_InvalidParameters_ShouldThrowArgumentException()
        {
            Assert.That(() => new MoveSleep(null, 20, 0.7, Type.Flying), Throws.ArgumentException);
            Assert.That(() => new MoveSleep("", 20, 0.7, Type.Ground), Throws.ArgumentException);
        }

        [Test]
        public void MoveSleepExecuteMove_ShouldSetSleepTurnsOnTarget()
        {
            Move[] moves = new Move[]
            {
                new MoveNormal("Patada Ígnea", 80, 0.5, Type.Fire),
                new MoveNormal("Llamarada", 90, 0.7, Type.Fire),
                new MoveNormal("Tajo Aéreo", 70, 0.5, Type.Flying),
                new MoveBurn("Anillo Ígneo", 0, 0.3, Type.Fire)
            };
            var move = new MoveSleep("Dormir", 30, 1.0, Type.Ground);
            var attacker = new Pokemon(moves);
            var target = new Pokemon(moves);

            move.ExecuteMove(attacker, target, 1.0);

            Assert.That(target.SleepTurns, Is.GreaterThanOrEqualTo(1).And.LessThanOrEqualTo(5));
            Assert.That(target.HealthPoints, Is.LessThan(100));
        }
        

        [Test]
        public void MoveBurnConstructor_ValidParameters_ShouldSetProperties()
        {
            var move = new MoveBurn("Quemadura", 45, 0.75, Type.Fire);

            Assert.That(move.Name, Is.EqualTo("Quemadura"));
            Assert.That(move.AttackValue, Is.EqualTo(45));
            Assert.That(move.Accuracy, Is.EqualTo(0.75));
        }

        [Test]
        public void MoveBurnConstructor_InvalidParameters_ShouldThrowArgumentException()
        {
            Assert.That(() => new MoveBurn(null, 45, 0.75, Type.Dragon), Throws.ArgumentException);
            Assert.That(() => new MoveBurn("", 45, 0.75, Type.Grass), Throws.ArgumentException);
        }

        [Test]
        public void MoveBurnExecuteMove_ShouldBurnTarget()
        {
            Move[] moves = new Move[]
            {
                new MoveNormal("Patada Ígnea", 80, 0.5, Type.Fire),
                new MoveNormal("Llamarada", 90, 0.7, Type.Fire),
                new MoveNormal("Tajo Aéreo", 70, 0.5, Type.Flying),
                new MoveBurn("Anillo Ígneo", 0, 0.3, Type.Fire)
            };
            var move = new MoveBurn("Quemadura", 40, 0.75, Type.Fire);
            var attacker = new Pokemon(moves);
            var target = new Pokemon(moves);

            move.ExecuteMove(attacker, target, 1.0);

            Assert.That(target.IsBurned, Is.True);
            Assert.That(target.HealthPoints, Is.LessThan(100));
        }

        [Test]
        public void MoveNormalConstructor_ValidParameters_ShouldSetProperties()
        {
            var move = new MoveNormal("Ataque Rápido", 35, 0.95, Type.Ice);

            Assert.That(move.Name, Is.EqualTo("Ataque Rápido"));
            Assert.That(move.AttackValue, Is.EqualTo(35));
            Assert.That(move.Accuracy, Is.EqualTo(0.95));
        }

        [Test]
        public void MoveNormalConstructor_InvalidParameters_ShouldThrowArgumentException()
        {
            Assert.That(() => new MoveNormal(null, 35, 0.95, Type.Fighting), Throws.ArgumentException);
            Assert.That(() => new MoveNormal("", 35, 0.95, Type.Ground), Throws.ArgumentException);
        }

        [Test]
        public void MoveNormalExecuteMove_ShouldReduceTargetHealth()
        {
            Move[] moves = new Move[]
            {
                new MoveNormal("Patada Ígnea", 80, 0.5, Type.Fire),
                new MoveNormal("Llamarada", 90, 0.7, Type.Fire),
                new MoveNormal("Tajo Aéreo", 70, 0.5, Type.Flying),
                new MoveBurn("Anillo Ígneo", 0, 0.3, Type.Fire)
            };
            var move = new MoveNormal("Ataque Rápido", 35, 0.95, Type.Ghost);
            var attacker = new Pokemon(moves);
            var target = new Pokemon(moves);

            move.ExecuteMove(attacker, target, 1.0);

            Assert.That(target.HealthPoints, Is.LessThan(200));
        }
    }
}