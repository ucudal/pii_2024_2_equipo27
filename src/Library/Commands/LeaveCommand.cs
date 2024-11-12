using Discord.Commands;
using ClassLibrary;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'leave' del bot. Este comando remueve el
/// jugador que envía el mensaje de la lista de jugadores esperando para jugar.
/// </summary>
// ReSharper disable once UnusedType.Global
public class LeaveCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'leave' del bot. Este comando remueve el jugador
    /// que envía el mensaje de la lista de jugadores esperando para jugar.
    /// </summary>
    [Command("leave")]
    [Summary("Remueve el usuario que envía el mensaje a la lista de espera")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Facade.Instance.RemovePlayerFromWaitingList(displayName);
        await ReplyAsync(result);
    }
}