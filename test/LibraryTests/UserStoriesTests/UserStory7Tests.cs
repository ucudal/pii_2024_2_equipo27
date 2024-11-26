namespace ClassLibrary.Tests;
using NUnit.Framework;
using ClassLibrary;

public class UserStory7Tests
{
    [TearDown]
    public void TearDown()
    {
        Facade.Reset(); 
    }

    [Test]
    public void ChangePokemon_WhenPlayerExistsAndPokemonIsAvailable_ReturnsChangeMessage()
    {
        // Arrange
        Facade.Instance.GameList.AddGame(new Player("player1"), new Player("player2"));
        Facade.Instance.ChoosePokemons("player1", new string[] { "Mew", "Blaziken","Tinkaton", "Salamence", "Jigglypuff" });
        Facade.Instance.ChoosePokemons("player2", new string[] { "Mew", "Blaziken","Tinkaton", "Salamence", "Jigglypuff" });
        Facade.Instance.ChooseMoveToAttack( "player1",  "Corte");
        
        // Act
        string result = Facade.Instance.ChangePokemon("player1", "Blaziken");
        string expected = "player1 cambió a Blaziken y perdió su turno";

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ChangePokemon_WhenParameterPlayerDisplayName_IsNullOrEmpty_ThrowsException()
    {
        // Arrange
        Facade.Instance.GameList.AddGame(new Player("player1"), new Player("player2"));
        Facade.Instance.ChoosePokemons("player1", new string[] { "Mew", "Blaziken","Tinkaton", "Salamence", "Jigglypuff" });
        Facade.Instance.ChoosePokemons("player2", new string[] { "Mew", "Blaziken","Tinkaton", "Salamence", "Jigglypuff" });
        Facade.Instance.ChooseMoveToAttack( "player1",  "Corte");
        
        // Act Assert
        Assert.That(()=> Facade.Instance.ChangePokemon("", "Blaziken"), Throws.InstanceOf<Exception>());
    }
    
    [Test]
    public void ChangePokemon_WhenParameterNewPokemonName_IsNullOrEmpty_ThrowsException()
    {
        // Arrange
        Facade.Instance.GameList.AddGame(new Player("player1"), new Player("player2"));
        Facade.Instance.ChoosePokemons("player1", new string[] { "Mew", "Blaziken","Tinkaton", "Salamence", "Jigglypuff" });
        Facade.Instance.ChoosePokemons("player2", new string[] { "Mew", "Blaziken","Tinkaton", "Salamence", "Jigglypuff" });
        Facade.Instance.ChooseMoveToAttack( "player1",  "Corte");
        
        // Act & Assert
        Assert.That(()=> Facade.Instance.ChangePokemon("player1", null), Throws.InstanceOf<Exception>());
    }
    
     [Test]
     public void ChangePokemon_WhenPlayerDoesNotExist_ThrowsArgumentException()
     {
         // Arrange
         Facade.Instance.GameList.AddGame(new Player("player1"), new Player("player2"));
         Facade.Instance.ChoosePokemons("player1", new string[] { "Mew", "Blaziken","Tinkaton", "Salamence", "Jigglypuff" });
         Facade.Instance.ChoosePokemons("player2", new string[] { "Mew", "Blaziken","Tinkaton", "Salamence", "Jigglypuff" });
         Facade.Instance.ChooseMoveToAttack( "player1",  "Corte");
        
         // Act & Assert
         Assert.That(()=> Facade.Instance.ChangePokemon("player3", "Blaziken"), Throws.InstanceOf<Exception>());
     }
     
     [Test]
     public void ChangePokemon_WhenPokemonDoesNotExist_ThrowsArgumentException()
     {
         // Arrange
         Facade.Instance.GameList.AddGame(new Player("player1"), new Player("player2"));
         Facade.Instance.ChoosePokemons("player1", new string[] { "Mew", "Blaziken","Tinkaton", "Salamence", "Jigglypuff" });
         Facade.Instance.ChoosePokemons("player2", new string[] { "Mew", "Blaziken","Tinkaton", "Salamence", "Jigglypuff" });
         Facade.Instance.ChooseMoveToAttack( "player1",  "Corte");
        
         // Act & Assert
         Assert.That(()=> Facade.Instance.ChangePokemon("player1", "Lululemon"), Throws.InstanceOf<Exception>());
     }
 }
