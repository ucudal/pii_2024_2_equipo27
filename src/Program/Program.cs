
using System;
using ClassLibrary;

namespace ConsoleApplication
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Punto de entrada del programa
            Facade facade = new Facade();
            List<string> messages;
            
            messages = facade.ChoosePokemons(1, new string[] {"Blaziken" });
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }
        }
    }
}
