using Discord;
using Discord.Commands;
using ClassLibrary;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'change' del bot. Este comando permite al
/// jugador cambiar su Pokémon activo por otro de su equipo.
/// </summary>
// ReSharper disable once UnusedType.Global
public class ChangeCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'change'. Este comando toma el nombre del nuevo
    /// Pokémon que el jugador desea usar como activo y actualiza la selección.
    /// </summary>
    [Command("change")]
    [Summary(
        """
        Cambia el Pokémon activo del jugador por otro de su equipo. 
        El nombre debe coincidir con el de un Pokémon previamente seleccionado.
        """)]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync(
        [Remainder]
        [Summary("Nombre del Pokémon que se desea activar")]
        string newPokemonName)
    {
        try
        {
            // Validar que el usuario proporcionó un nombre de Pokémon
            if (string.IsNullOrWhiteSpace(newPokemonName))
            {
                await ReplyAsync("Debes especificar el nombre de un Pokémon para cambiar. Ejemplo: `!change Charizard`");
                return;
            }

            // Obtener el display name del jugador
            string playerDisplayName = CommandHelper.GetDisplayName(Context);

            // Llamar al método de la fachada para cambiar el Pokémon
            string result = Facade.Instance.ChangePokemon(playerDisplayName, newPokemonName);

            // Responder con el resultado de la operación
            await ReplyAsync(result);
        }
       
        catch (Exception ex)
        {
            // Manejo de errores genéricos
            Console.WriteLine($"Error en el comando 'change': {ex.Message}");
            await ReplyAsync("Ocurrió un error inesperado al intentar cambiar tu Pokémon activo. Inténtalo de nuevo.");
        }
    }
}