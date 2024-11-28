using Discord;
using Discord.Commands;
using ClassLibrary;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'advantage' del bot. Este comando muestra quien va ganando en el turno actual.
/// </summary>
// ReSharper disable once UnusedType.Global
public class AdvantageCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'advantage'. Muestra quien va ganando en el turno actual.
    /// </summary>
    [Command("advantage")]
    [Summary(
        "Muestra quien tiene ventaja durante el juego. El jugador que tiene más porcetaje de la salud de sus Pokémon.")]
    public async Task ExecuteAsync()
    {
        try
        {
            // Obtener el display name del jugador
            string playerDisplayName = CommandHelper.GetDisplayName(Context);

            // Llamar al método de la fachada para mostrar e l ganador.
            string result = Facade.Instance.ShowCurrentWinner(playerDisplayName);

            // Responder con el resultado de la operación
            await ReplyAsync(result);
        }

        catch (Exception ex)
        {
            // Manejo de errores genéricos
            Console.WriteLine($"Error en el comando 'advantage': {ex.Message}");
            await ReplyAsync("Ocurrió un error inesperado al intentar ver el jugador con ventaja actual.");
        }
    }
}