using Discord;
using Discord.Commands;
using ClassLibrary;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'change' del bot. Este comando permite al
/// jugador cambiar su Pokémon activo por otro de su equipo.
/// </summary>
// ReSharper disable once UnusedType.Global
public class AdvantageCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'change'. Este comando toma el nombre del nuevo
    /// Pokémon que el jugador desea usar como activo y actualiza la selección.
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