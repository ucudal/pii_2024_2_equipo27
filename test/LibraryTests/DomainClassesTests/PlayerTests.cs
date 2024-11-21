using NUnit.Framework;
using System;
using System.Collections.Generic;
using ClassLibrary;

namespace PlayerTests
{
    [TestFixture]
    public class PlayerTests
    {
        public Player player;
        public Pokemon pikachu;
        public Pokemon charizard;

        [SetUp]
        public void Setup()
        {
            player = new Player("Juan");
            pikachu = new Pokemon("Pikachu");
            charizard = new Pokemon("Charizard");
        }

        [Test]
        public void AddPokemon_ShouldAddPokemonToAvailablePokemons()
        {
            // Act
            player.AddPokemon(pikachu);

            // Assert
            Assert.That( player.AvailablePokemons.Contains(pikachu));
        }

        [Test]
        public void AddPokemon_ShouldSetActivePokemon_WhenFirstPokemonAdded()
        {
            // Act
            player.AddPokemon(pikachu);

            // Assert
            Assert.That(player.ActivePokemon, Is.EqualTo(pikachu));
        }


        [Test]
        public void UseItem_ShouldThrowException_WhenItemNotInInventory()
        {
            // Act & Assert
            var ex = Assert.Throws<ApplicationException>(() => player.UseItem("NonExistentItem"));
            Assert.That(ex.Message, Is.EqualTo("No existe el ítem NonExistentItem en el inventario."));
        }

        [Test]
        
        public void UseItem_ShouldRemoveItemFromInventory_WhenItemExists()
        {
            // Arrange
            var itemName = "SuperPotion";
            var item = new ItemSuperPotion();

            // Act
            var usedItem = player.UseItem(itemName);

            // Assert
            Assert.That(usedItem, Is.EqualTo(item));
            Assert.That(player.UseItem, Is.False);
        }

    }
}
