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
            // Obtener el nombre visible del jugador desde el contexto
            string displayName = CommandHelper.GetDisplayName(Context);
            List<string> moves = Facade.Instance.GameList.GetPokemonsWithMovesForPlayer(displayName);

            // Obtener los movimientos asociados al jugador a través de la fachada
            string result = string.Join(", ", moves); // Combina las cadenas en un solo string.

            // Enviar el resultado al canal de Discord
            await ReplyAsync(result);
        }
    }
}