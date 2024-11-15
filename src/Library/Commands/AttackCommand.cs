using Discord.Commands;
using ClassLibrary;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'join' del bot. Este comando une al jugador
/// que envía el mensaje a la lista de jugadores esperando para jugar.
/// </summary>
// ReSharper disable once UnusedType.Global
public class AttackCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'join'. Este comando une al jugador que envía el
    /// mensaje a la lista de jugadores esperando para jugar.
    /// </summary>
    [Command("attack")]
    [Summary("Ejecuta el ataque")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync([Remainder]string moveName)
    {
        //validar movename
        
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Facade.Instance.PlayerAttack(displayName, moveName);
        
        
        await ReplyAsync(result);
        
    }
}