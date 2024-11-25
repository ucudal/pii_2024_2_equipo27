
using ClassLibrary;
using Discord.Commands;

namespace Library.Commands
{
    public class UseItemCommand : ModuleBase<SocketCommandContext>
    {
        [Command("useitem")]
        [Summary("Usa un ítem específico en el Pokémon activo.")]
        public async Task ExecuteAsync([Remainder] string itemName)
        {
            // Verificar que se haya proporcionado el nombre del ítem
            if (string.IsNullOrWhiteSpace(itemName))
            {
                await ReplyAsync("Debes especificar el nombre del ítem. Ejemplo: `!useitem Superpoción`");
                return;
            }

            // Obtener el nombre del jugador desde el contexto
            string playerDisplayName = CommandHelper.GetDisplayName(Context);

            try
            {
                // Llamar al método de Facade para usar el ítem
                string result = Facade.Instance.PlayerUseItem(playerDisplayName, itemName);

                // Enviar el resultado al canal
                await ReplyAsync(result);
            }
            
            catch (ArgumentNullException ex)
            {
                // Manejo de errores de argumentos nulos
                await ReplyAsync($"Error: {ex.Message}");
            }
            catch (PokemonException ex)
            {
                // Manejo de errores específicos del juego
                await ReplyAsync($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                Console.WriteLine($"Error en el comando 'useitem': {ex.Message}");
                await ReplyAsync("Ocurrió un error inesperado al usar el ítem.");
            }
        }
    }
}