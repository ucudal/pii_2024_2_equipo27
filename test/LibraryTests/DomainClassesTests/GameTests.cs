namespace ClassLibrary.Tests;

using NUnit.Framework;

public class GameTests
{
    private Player _player1;
    private Player _player2;
    private Game _game;
    private PokemonCatalog catalog = new PokemonCatalog();

    [SetUp]
    public void SetUp()
    {
        // Configuración inicial para los tests
        _player1 = new Player("Player1");
        _player1.AddPokemon(catalog.FindPokemonByName("Pikachu"));

        _player2 = new Player("Player2");
        _player2.AddPokemon(catalog.FindPokemonByName("Pikachu"));

        _game = new Game(_player1, _player2);
    }

    [Test]
    public void Constructor_InitializesGamePropertiesCorrectly()
    {
        Assert.That(_game.Player1, Is.EqualTo(_player1));
        Assert.That(_game.Player2, Is.EqualTo(_player2));
        Assert.That(_game.PlayIsOn, Is.True);
        Assert.That(_game.Winner, Is.Null);
    }

    [Test]
    public void CheckIfGameEnds_EndsGameWhenAllPokemonsOfPlayer1HaveZeroHealth()
    {
        // Reducimos la vida de todos los Pokémon del jugador 1 a 0
        foreach (var pokemon in _player1.AvailablePokemons)
        {
            pokemon.HealthPoints = 0;
        }

        _game.CheckIfGameEnds();

        Assert.That(_game.PlayIsOn, Is.False);
        Assert.That(_game.Winner, Is.EqualTo(_player2));
    }

    [Test]
    public void CheckIfGameEnds_EndsGameWhenAllPokemonsOfPlayer2HaveZeroHealth()
    {
        // Reducimos la vida de todos los Pokémon del jugador 2 a 0
        foreach (var pokemon in _player2.AvailablePokemons)
        {
            pokemon.HealthPoints = 0;
        }

        _game.CheckIfGameEnds();

        Assert.That(_game.PlayIsOn, Is.False);
        Assert.That(_game.Winner, Is.EqualTo(_player1));
    }

    [Test]
    public void CheckIfGameEnds_GameRemainsActiveWhenBothPlayersHaveRemainingHealth()
    {
        _game.CheckIfGameEnds();

        Assert.That(_game.PlayIsOn, Is.True);
        Assert.That(_game.Winner, Is.Null);
    }

    [Test]
    public void TurnProperty_ReturnsCurrentPlayer()
    {
        Assert.That(_game.TurnPlayer, Is.EqualTo(_player1));
    }

    [Test]
    public void Constructor_ThrowsException_WhenPlayer1IsNull()
    {
        Assert.That(() => new Game(null, _player2),
            Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void Constructor_ThrowsException_WhenPlayer2IsNull()
    {
        Assert.That(() => new Game(_player1, null),
            Throws.InstanceOf<ArgumentNullException>());
    }
    
    [Test]
    public void CheckWhoisWinning_ReturnsNull_WhenEmpate()
    {
        Assert.That(_game.CheckWhoIsWinning(), Is.EqualTo(null));
    }
    
    [Test]
    public void CheckWhoisWinning_ReturnsPlayer1_WhenLowerHealthPercentage()
    {
        foreach (var pokemon in _player1.AvailablePokemons)
        {
            pokemon.HealthPoints = 0;
        }        
        
        Assert.That(_game.CheckWhoIsWinning(), Is.EqualTo(_player2));
    }
}
