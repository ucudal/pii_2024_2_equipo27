using Discord;
using Discord.Commands;
using Discord.WebSocket;
using ClassLibrary;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'attack' del bot. Este comando ejecuta un ataque
/// usando un movimiento especificado por el usuario.
/// </summary>
// ReSharper disable once UnusedType.Global
public class AttackCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Esta clase implementa el comando 'attack'. Este comando realiza un ataque con el movimiento especificado.
    /// </summary>
    [Command("attack")]
    [Summary(
        """
        Realiza un ataque contra el oponente usando un movimiento específico.
        Ejemplo: `!attack Thunderbolt`
        """)]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync(
        [Remainder] [Summary("El nombre del movimiento que deseas usar para atacar.")]
        string moveName)
    {
        try
        {
            // Validar que el usuario ingresó un movimiento
            if (string.IsNullOrWhiteSpace(moveName))
            {
                await ReplyAsync(
                    "Debes especificar el nombre de un movimiento para atacar. Ejemplo: `!attack Thunderbolt`");
                return;
            }

            // Obtener el nombre del jugador
            string displayName = CommandHelper.GetDisplayName(Context);

            // Elegir el movimiento para atacar
            Facade.Instance.ChooseMoveToAttack(displayName, moveName);

            // Ejecutar el ataque
            string result = Facade.Instance.PlayerAttack(displayName);

            // Responder con el resultado de la operación
            await ReplyAsync(result);
        }
        catch (Exception ex)
        {
            // Manejo de errores genéricos
            Console.WriteLine($"Error en el comando 'attack': {ex.Message}");
            await ReplyAsync($"Ocurrió un error inesperado: {ex.Message}");
        }
    }
}