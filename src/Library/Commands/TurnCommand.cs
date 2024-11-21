using Discord.Commands;
using ClassLibrary;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'turn' del bot. Este comando muestra de 
/// quien es el turno
/// </summary>
// ReSharper disable once UnusedType.Global
public class TurnCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'turn'. Este comando Este comando muestra de 
    /// quien es el turno
    [Command("turn")]
    [Summary("Muestra de quien es el turno")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Facade.Instance.GetCurrentTurnPlayer(displayName);
        await ReplyAsync(result);
    }
}