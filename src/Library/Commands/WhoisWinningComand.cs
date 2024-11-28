using Discord.Commands;
using ClassLibrary;

namespace Library.Commands
{
    /// <summary>
    /// Esta clase implementa el comando 'whoiswinning' del bot.
    /// Este comando permite al jugador saber quién va ganando la pelea.
    /// </summary>
    public class WhoIsWinningCommand : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Implementa el comando 'whoiswinning'. Este comando muestra
        /// quién va ganando la batalla actual del jugador.
        /// </summary>
        [Command("whoiswinning")]
        [Summary("Muestra quién va ganando la pelea actual")]
        public async Task ExecuteAsync()
        {
            string playerDisplayName = Context.User.Username;

            string result = Facade.Instance.GetCurrentBattleStatus(playerDisplayName);

            await ReplyAsync(result);
        }
    }
}