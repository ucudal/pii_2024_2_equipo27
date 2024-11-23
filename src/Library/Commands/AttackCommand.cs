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
    /// Implementa el comando 'attack'. Este comando atacka al oponente
    /// </summary>
    [Command("attack")]
    [Summary("Ejecuta el ataque")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync([Remainder]string moveName)
    {
        //validar movename
        if (string.IsNullOrWhiteSpace(moveName))
        {
            await ReplyAsync("Debes especificar el nombre de un movimiento para atacar");
            return;
        }
        
        string displayName = CommandHelper.GetDisplayName(Context);
        Facade.Instance.ChooseMoveToAttack( displayName,  moveName);
        string result = Facade.Instance.PlayerAttack(displayName);
        
        await ReplyAsync(result);
    }
}