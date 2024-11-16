namespace ClassLibrary.Tests;

using NUnit.Framework;

[TestFixture]
public class ItemTests
{
    private ItemFullHeal curaTotal;
    private ItemRevive _itemRevive;
    private ItemSuperPotion _itemSuperPotion;

    [SetUp]
    public void Setup()
    {
        // Inicializamos los objetos que vamos a probar
        curaTotal = new ItemFullHeal();
        _itemRevive = new ItemRevive();
        _itemSuperPotion = new ItemSuperPotion();
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
        var ex = Assert.Throws<Exception>(() => _itemRevive.ApplyEffect(null));
        Assert.That(ex.Message, Is.EqualTo("No hay un Pokémon para revivir."));
    }

    [Test]
    public void Revivir_ThrowsException_WhenPokemonIsNotFainted()
    {
        // Arrange
        Move[] moves = new Move[]
        {
            new MoveNormal("Patada Ígnea", 80, 0.5, Type.Fire),
            new MoveNormal("Llamarada", 90, 0.7, Type.Fire),
            new MoveNormal("Tajo Aéreo", 70, 0.5, Type.Flying),
            new MoveBurn("Anillo Ígneo", 0, 0.3, Type.Fire)
        };
        Pokemon pokemon = new Pokemon(moves);

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => _itemRevive.ApplyEffect(pokemon));
        Assert.That(ex.Message, Is.EqualTo("Pikachu no puede ser revivido."));
    }

    [Test]
    public void SuperPocion_ThrowsException_WhenPokemonIsNull()
    {
        // Act & Assert
        var ex = Assert.Throws<Exception>(() => _itemSuperPotion.ApplyEffect(null));
        Assert.That(ex.Message, Is.EqualTo("No hay un pokemon activo para curar"));
    }

    [Test]
    public void CuraTotal_AppliesEffect_WhenPokemonIsValid()
    {
        // Arrange
        Move[] moves = new Move[]
        {
            new MoveNormal("Patada Ígnea", 80, 0.5, Type.Fire),
            new MoveNormal("Llamarada", 90, 0.7, Type.Fire),
            new MoveNormal("Tajo Aéreo", 70, 0.5, Type.Flying),
            new MoveBurn("Anillo Ígneo", 0, 0.3, Type.Fire)
        };
        Pokemon pokemon = new Pokemon(moves);

        // Act
        var message = curaTotal.ApplyEffect(pokemon);

        // Assert
        Assert.That(message, Is.EqualTo("Bulbasaur ha sido curado completamente."));
        Assert.That(pokemon.HealthPoints, Is.EqualTo(100));
        Assert.That(pokemon.IsPoisoned, Is.False);
    }
}
