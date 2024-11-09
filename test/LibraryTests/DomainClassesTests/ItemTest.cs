namespace ClassLibrary.Tests;

using NUnit.Framework;

[TestFixture]
public class ItemTests
{
    private CompleteCure curaTotal;
    private Revivir revivir;
    private SuperPocion superPocion;

    [SetUp]
    public void Setup()
    {
        // Inicializamos los objetos que vamos a probar
        curaTotal = new CompleteCure();
        revivir = new Revivir();
        superPocion = new SuperPocion();
    }

    [Test]
    public void CuraTotal_ThrowsException_WhenPokemonIsNull()
    {
        // Act & Assert
        var ex = Assert.Throws<Exception>(() => curaTotal.ApplyEffect(null));
        Assert.That(ex.Message, Is.EqualTo("No hay un Pokémon activo para curar."));
    }

    [Test]
    public void Revivir_ThrowsException_WhenPokemonIsNull()
    {
        // Act & Assert
        var ex = Assert.Throws<Exception>(() => revivir.ApplyEffect(null));
        Assert.That(ex.Message, Is.EqualTo("No hay un Pokémon para revivir."));
    }

    [Test]
    public void Revivir_ThrowsException_WhenPokemonIsNotFainted()
    {
        // Arrange
        var pokemon = new Pokemon { Name = "Pikachu", HealthPoints = 100 };

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => revivir.ApplyEffect(pokemon));
        Assert.That(ex.Message, Is.EqualTo("Pikachu no puede ser revivido."));
    }

    [Test]
    public void SuperPocion_ThrowsException_WhenPokemonIsNull()
    {
        // Act & Assert
        var ex = Assert.Throws<Exception>(() => superPocion.ApplyEffect(null));
        Assert.That(ex.Message, Is.EqualTo("No hay un pokemon activo para curar"));
    }

    [Test]
    public void CuraTotal_AppliesEffect_WhenPokemonIsValid()
    {
        // Arrange
        var pokemon = new Pokemon { Name = "Bulbasaur", HealthPoints = 50, IsPoisoned = true };

        // Act
        var message = curaTotal.ApplyEffect(pokemon);

        // Assert
        Assert.That(message, Is.EqualTo("Bulbasaur ha sido curado completamente."));
        Assert.That(pokemon.HealthPoints, Is.EqualTo(100));
        Assert.That(pokemon.IsPoisoned, Is.False);
    }
}
