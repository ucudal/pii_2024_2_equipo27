using Discord.Commands;
using ClassLibrary;

namespace Library.Commands
{
    /// <summary>
    /// Comando que muestra los movimientos disponibles de los Pokémon del jugador
    /// para los Pokémon del oponente.
    /// </summary>
    public class MovesCommand : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Ejecuta el comando 'moves' que muestra los movimientos disponibles de los
        /// Pokémon del jugador para los Pokémon del oponente.
        /// </summary>
        [Command("moves")]
        [Summary("Muestra los movimientos disponibles de tus Pokémon para los Pokémon del oponente.")]
        public async Task ExecuteAsync()
        {
            string displayName = CommandHelper.GetDisplayName(Context);
            List<string> result = Facade.Instance.ShowMoves(displayName);
            await ReplyAsync(result.ToString());
        }
    }
}