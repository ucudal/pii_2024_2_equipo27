using Discord;
using Discord.Commands;
using Discord.WebSocket;
using ClassLibrary;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'rules' del bot. 
/// </summary>
// ReSharper disable once UnusedType.Global

public class RulesCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'rules'. Este comando muestra información sobre las reglas del juego"
    /// </summary>
    [Command("rules")]
    [Summary("Muestra información sobre las reglas del juego")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        try
        {
            // Obtener el mensaje de reglas a través de la fachada
            string result = Facade.Instance.GetRulesMessage();

            // Verificar que el resultado no sea nulo o vacío
            if (string.IsNullOrEmpty(result))
            {
                result = "No se pudo obtener el mensaje de reglas.";
            }

            // Enviar el mensaje al autor del mensaje
            await Context.Message.Author.SendMessageAsync(result);

            // También lo enviamos como un mensaje en el canal
            await ReplyAsync(result);
        }
        catch (Exception ex)
        {
            // Si hay algún error, logueamos el error
            Console.WriteLine($"Error en el comando 'help': {ex.Message}");
            await ReplyAsync("Ocurrió un error al intentar mostrar la ayuda.");
        }
    }
}