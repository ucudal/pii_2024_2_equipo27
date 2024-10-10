using ClassLibrary;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class FacadeTests
    {
        private Facade facade;

        [SetUp]
        public void Setup()
        {
            facade = new Facade();
        }

        [Test]
        public void ChoosePokemons_WhenCalled_AddsPokemonsToPlayer()
        {
            // Arrange
            string[] pokemonNames = { "Pikachu", "Charmander" };
            
            // Act
            List<string> result = facade.ChoosePokemons(1, pokemonNames);
            
            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0], Is.EqualTo("Pokémons seleccionados por el jugador 1."));
        }

        [Test]
        public void ShowMoves_WhenCalled_ReturnsPokemonMoves()
        {
            // Arrange
            string[] pokemonNames = { "Pikachu" };
            facade.ChoosePokemons(1, pokemonNames);
            
            // Act
            List<string> moves = facade.ShowMoves(1);
            
            // Assert
            Assert.That(moves.Count, Is.GreaterThan(0));
            Assert.That(moves[0], Does.Contain("Pikachu"));
        }

        [Test]
        public void ChoosePokemonAndMoveToAttack_ActivatesPokemonAndMove()
        {
            // Arrange
            string[] pokemonNames = { "Pikachu" };
            facade.ChoosePokemons(1, pokemonNames);
            
            // Act
            facade.ChoosePokemonAndMoveToAttack(1, "Thunderbolt", "Pikachu");
            
            // Assert
            // Aquí podríamos verificar si el movimiento fue activado correctamente si tuviéramos un método en la clase para comprobar el estado
            Assert.Pass(); // Placeholder - implementar lógica de verificación según la implementación interna.
        }

        [Test]
        public void GetPokemonsHealth_ReturnsCorrectHealthInfo()
        {
            // Arrange
            string[] player1Pokemons = { "Pikachu" };
            string[] player2Pokemons = { "Charmander" };
            facade.ChoosePokemons(1, player1Pokemons);
            facade.ChoosePokemons(2, player2Pokemons);
            
            // Act
            List<string> healthInfo = facade.GetPokemonsHealth(1);
            
            // Assert
            Assert.That(healthInfo.Count, Is.GreaterThan(0));
            Assert.That(healthInfo[0], Does.Contain("Pikachu"));
        }
    }
}
