// namespace ClassLibrary.Tests;
// using NUnit.Framework;
// using ClassLibrary;

// public class ChangePokemonTests
// {
//     [TearDown]
//     public void TearDown()
//     {
//         Facade.Reset(); // Asumiendo que el método `Reset` restablece el estado del juego.
//     }
//
//     [Test]
//     public void ChangePokemon_WhenPlayerExistsAndPokemonIsAvailable_ReturnsChangeMessage()
//     {
//         // Arrange
//         Facade.Instance.AddPlayer("player1"); // Agrega un jugador a la partida
//         Facade.Instance.AddPokemonToPlayer("player1", "Pikachu"); // Agrega un Pokémon al jugador
//         
//         // Act
//         string result = Facade.Instance.ChangePokemon("player1", "Pikachu");
//
//         // Assert
//         Assert.That(result, Is.EqualTo("player1 cambió a Pikachu y perdió su turno"));
//     }
//
//     [Test]
//     public void ChangePokemon_WhenPlayerDoesNotExist_ThrowsArgumentException()
//     {
//         // Arrange & Act & Assert
//         var ex = Assert.Throws<ArgumentException>(() => Facade.Instance.ChangePokemon("nonExistentPlayer", "Pikachu"));
//         Assert.That(ex.Message, Is.EqualTo("El jugador nonExistentPlayer no está jugando (Parameter 'playerDisplayName')"));
//     }
//
//     [Test]
//     public void ChangePokemon_WhenPokemonIsNotAvailable_ThrowsArgumentException()
//     {
//         // Arrange
//         Facade.Instance.AddPlayer("player1"); // Agrega un jugador sin Pokémon
//
//         // Act & Assert
//         var ex = Assert.Throws<ArgumentException>(() => Facade.Instance.ChangePokemon("player1", "Charizard"));
//     }
//     
//     [Test]
//     public void ChangePokemon_WhenPokemonNameIsNull_ThrowsArgumentException()
//     {
//         // Arrange
//         Facade.Instance.AddPlayer("player1");
//         Facade.Instance.AddPokemonToPlayer("player1", "Bulbasaur");
//
//         // Act & Assert
//         var ex = Assert.Throws<ArgumentException>(() => Facade.Instance.ChangePokemon("player1", null));
//         Assert.That(ex.Message, Is.EqualTo("El Pokémon  no está disponible para el jugador player1 (Parameter 'newPokemonName')"));
//     }
//     
//     [Test]
//     public void ChangePokemon_WhenPlayerHasMultiplePokemons_ChangesToSpecifiedPokemon()
//     {
//         // Arrange
//         Facade.Instance.AddPlayer("player1");
//         Facade.Instance.AddPokemonToPlayer("player1", "Pikachu");
//         Facade.Instance.AddPokemonToPlayer("player1", "Charizard");
//
//         // Act
//         string result = Facade.Instance.ChangePokemon("player1", "Charizard");
//
//         // Assert
//         Assert.That(result, Is.EqualTo("player1 cambió a Charizard y perdió su turno"));
//     }
// }
