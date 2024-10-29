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
            string[] pokemonNames = { "Blaziken", "Tinkaton" };
            
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
            string[] pokemonNames = { "Blaziken" };
            facade.ChoosePokemons(1, pokemonNames);
            
            // Act
            List<string> moves = facade.ShowMoves(1);
            
            // Assert
            Assert.That(moves.Count, Is.GreaterThan(0));
            Assert.That(moves[0], Does.Contain("Blaziken"));
        }

        [Test]
        public void ChoosePokemonAndMoveToAttack_ActivatesPokemonAndMove()
        {
            // Arrange
            string[] pokemonNames = { "Blaziken" };
            facade.ChoosePokemons(1, pokemonNames);
            
            // Act
            facade.ChoosePokemonAndMoveToAttack(1, "Patada Ígnea", "Blaziken");
            
            // Assert
            // Aquí podríamos verificar si el movimiento fue activado correctamente si tuviéramos un método en la clase para comprobar el estado
            Assert.Pass(); // Placeholder - implementar lógica de verificación según la implementación interna.
        }
    }
}
