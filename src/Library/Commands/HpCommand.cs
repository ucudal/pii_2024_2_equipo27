using Discord.Commands;
using ClassLibrary;

namespace Library.Commands
{
    /// <summary>
    /// Comando que muestra los HP de los Pokémon de ambos jugadores.
    /// </summary>
    public class HpCommand : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Ejecuta el comando 'hp' que muestra los HP de los Pokémon de ambos jugadores.
        /// </summary>
        [Command("hp")]
        [Summary("Muestra los HP de los Pokémon de ambos jugadores.")]
        public async Task ExecuteAsync()
        {
            string displayName = CommandHelper.GetDisplayName(Context);
            string result = Facade.Instance.GetPokemonsHealth(displayName);
            await ReplyAsync(result);
        }
    }
}