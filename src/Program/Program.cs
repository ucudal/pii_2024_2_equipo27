
using System;
using ClassLibrary;

namespace ConsoleApplication
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Facade facade = new Facade();
            List<string> messages;

            messages = facade.ChoosePokemons(1, new string[] {"Blaziken", "Tinkaton", "Salamence", "Bellsprout", "Zangoose", "Rayquaza"});
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }

            messages = facade.ChoosePokemons(2, new string[] {"Wailord", "Sudowoodo", "Mew", "Azumarill", "Jigglypuff", "Lucario"});
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }

            Console.WriteLine("\nMovimientos de Jugador 1:");
            messages = facade.ShowMoves(1);
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }

            Console.WriteLine("\nMovimientos de Jugador 2:");
            messages = facade.ShowMoves(2);
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }

            Console.WriteLine("\nJugador 1 ataca con Rayquaza usando Ascenso Draco:");
            facade.ChoosePokemonAndMoveToAttack(1, "Ascenso Draco", "Rayquaza");

            Console.WriteLine("\nVida de los Pokémon después del primer turno:");
            messages = facade.GetPokemonsHealth(1);
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }

            Console.WriteLine("\nJugador 2 ataca con Lucario usando Esfera Aural:");
            facade.ChoosePokemonAndMoveToAttack(2, "Esfera Aural", "Lucario");

            Console.WriteLine("\nVida de los Pokémon después del segundo turno:");
            messages = facade.GetPokemonsHealth(2);
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }
        }
    }
}
