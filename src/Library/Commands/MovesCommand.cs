using Discord.Commands;
using ClassLibrary;

namespace Library.Commands
{
    /// <summary>
    /// Comando que muestra los movimientos disponibles de los Pokémon del jugador
    /// </summary>
    public class MovesCommand : ModuleBase<SocketCommandContext>
    { 
            /// <summary>
            /// Implementa el comando 'moves'. Este comando muestra los movimientos disponibles del Pokémon actual del jugador.
            /// </summary>
            [Command("moves")]
            [Summary("Muestra los movimientos del Pokémon actual.")]
            public async Task ExecuteAsync()
            {
                // Obtén el nombre de usuario del jugador que ejecutó el comando
                string displayName = CommandHelper.GetDisplayName(Context);

                // Usa el Facade para obtener los movimientos del Pokémon actual
                var currentPokemonMoves = Facade.Instance.ShowMoves(displayName);

                if (currentPokemonMoves != null && currentPokemonMoves.Any())
                {
                    // Construye una respuesta con los movimientos disponibles
                    string moves = string.Join(", ", currentPokemonMoves);
                    await ReplyAsync($"Los movimientos disponibles de tu Pokémon actual son: {moves}");
                }
            }
        }
    }