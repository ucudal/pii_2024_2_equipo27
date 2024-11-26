using Discord.Commands;
using ClassLibrary;

namespace Library.Commands
{
    public class CatalogCommand : ModuleBase<SocketCommandContext>
    {
        [Command("catalog")]
        [Summary("Muestra el catálogo de Pokémon disponibles, incluyendo sus movimientos.")]
        public async Task ExecuteAsync()
        {
            // Llamar al método de Facade para obtener el catálogo
            string catalogMessage = Facade.Instance.ShowPokemonCatalog();

            // Verificar si el mensaje excede el límite de Discord
            if (catalogMessage.Length <= 2000)
            {
                await ReplyAsync(catalogMessage);
            }
            else
            {
                // Dividir el mensaje en partes más pequeñas si es necesario
                var messages = SplitMessage(catalogMessage, 2000);
                foreach (var message in messages)
                {
                    await ReplyAsync(message);
                }
            }
        }

        private static List<string> SplitMessage(string message, int maxLength)
        {
            var result = new List<string>();
            int currentIndex = 0;
            while (currentIndex < message.Length)
            {
                int length = Math.Min(maxLength, message.Length - currentIndex);
                result.Add(message.Substring(currentIndex, length));
                currentIndex += length;
            }

            return result;
        }
    }
}