// namespace ClassLibrary.Tests;
// using NUnit.Framework;
// using ClassLibrary;
// public class UserStory3Tests
// {
//     private Facade facade;
//     private Player player1;
//     private Player player2;
//
//     [SetUp]
//     public void Setup()
//     {
//         Facade.Reset();
//         facade = Facade.Instance;
//     }
//     [Test]
//     public void GetPokemonsHealth_PlayerNotFound_ShouldThrowArgumentException()
//     {
//         facade.GameList.AddGame(player1, player2);
//         facade.GameList.FindPlayerByDisplayName("Jugador1");
//         Assert.That(() => facade.GetPokemonsHealth("Jugador1"), Throws.ArgumentException);
//     }
//     
//        [Test]
//     public void GetPokemonsHealth_OpponentNotFound_ShouldThrowArgumentException()
//     {
//         facade.GameList.FindPlayerByDisplayName("Jugador2"); //Me falta hacer que sea el oponente
//         Assert.That(() => facade.GetPokemonsHealth("Jugador1"), Throws.ArgumentException);
//     }
//
//     [Test]
//     public void GetPokemonsHealth_BothPlayersInGame_ShouldReturnFormattedHealthString()
//     {
//         // Agregar Pokémon a cada jugador
//         facade.AddPlayerToWaitingList("Jugador1");
//         facade.AddPlayerToWaitingList("Jugador2");
//          string[] pokemonNames1 = { "Blaziken", "Tinkaton" };
//          string[] pokemonNames2 = { "Blaziken", "Mew" };
//
//         facade.ChoosePokemons("Jugador1", pokemonNames1);
//         facade.ChoosePokemons("Jugador2", pokemonNames2);
//         
//         string result = facade.GetPokemonsHealth("Jugador1");
//
//         string expectedMessage = UserInterface.ShowMessagePokemonHealth(player1.AvailablePokemons, player2.AvailablePokemons);
//
//         Assert.That(result, Is.EqualTo(expectedMessage));
//     }
//     
    // [Test]
    // public void GetPokemonsHealth_PlayerHasNoPokemons_ShouldReturnOpponentHealthOnly()
    // {
    //     // Agregar Pokémon solo al oponente
    //     player2.AvailablePokemons.Add(new Pokemon("Charmander", 80));
    //
    //     // Obtener la salud formateada
    //     string result = facade.GetPokemonsHealth("Jugador1");
    //
    //     // Crear el mensaje esperado para el caso de un jugador sin Pokémon
    //     string expectedMessage = UserInterface.ShowMessagePokemonHealth(player1.AvailablePokemons, player2.AvailablePokemons);
    //
    //     Assert.That(result, Is.EqualTo(expectedMessage));
    // }
    //
    // [Test]
    // public void GetPokemonsHealth_OpponentHasNoPokemons_ShouldReturnPlayerHealthOnly()
    // {
    //     // Agregar Pokémon solo al jugador
    //     player1.AvailablePokemons.Add(new Pokemon("Pikachu", 100));
    //
    //     // Obtener la salud formateada
    //     string result = facade.GetPokemonsHealth("Jugador1");
    //
    //     // Crear el mensaje esperado cuando el oponente no tiene Pokémon
    //     string expectedMessage = UserInterface.ShowMessagePokemonHealth(player1.AvailablePokemons, player2.AvailablePokemons);
    //
    //     Assert.That(result, Is.EqualTo(expectedMessage));
    // }
    //
    // [Test]
    // public void GetPokemonsHealth_NeitherPlayerHasPokemons_ShouldReturnEmptyHealthStatus()
    // {
    //     // Ambos jugadores sin Pokémon
    //     string result = facade.GetPokemonsHealth("Jugador1");
    //
    //     // Mensaje esperado cuando ninguno de los jugadores tiene Pokémon
    //     string expectedMessage = UserInterface.ShowMessagePokemonHealth(player1.AvailablePokemons, player2.AvailablePokemons);
    //
    //     Assert.That(result, Is.EqualTo(expectedMessage));
    // }
// }

