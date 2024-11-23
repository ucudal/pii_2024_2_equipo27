using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using ClassLibrary;

namespace Library.Commands
{
    public class ItemsCommand : ModuleBase<SocketCommandContext>
    {
        [Command("items")]
        [Summary("Muestra los ítems disponibles y sus cantidades.")]
        public async Task ExecuteAsync()
        {
            // Obtener el nombre del jugador desde el contexto
            string playerDisplayName = CommandHelper.GetDisplayName(Context);

            // Llamar a Facade para obtener los ítems
            string itemsMessage = Facade.Instance.ShowPlayerItems(playerDisplayName);

            // Verificar si el mensaje excede el límite de Discord
            if (itemsMessage.Length <= 2000)
            {
                await ReplyAsync(itemsMessage);
            }
            else
            {
                // Dividir el mensaje en partes más pequeñas si es necesario
                var messages = SplitMessage(itemsMessage, 2000);
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