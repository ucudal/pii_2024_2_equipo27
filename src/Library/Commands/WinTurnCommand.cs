using Discord.Commands;
using ClassLibrary;

namespace Library.Commands
{
    /// <summary>
    /// Comando que muestra los HP de los Pokémon de ambos jugadores.
    /// </summary>
    public class WinTurnCommand : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Ejecuta el comando 'hp' que muestra los HP de los Pokémon de ambos jugadores.
        /// </summary>
        [Command("hp")]
        [Summary("Muestra los HP de los Pokémon del jugador cuando cambia de turno e indica quien esta ganando.")]
        public async Task ExecuteAsync()
        {
            string displayName = CommandHelper.GetDisplayName(Context);
            string result = Facade.Instance.GetPlayerWinning(Facade.Instance.GetCurrentTurnPlayer(displayName));
            await ReplyAsync(result);

        }
    }
}

