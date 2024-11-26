using Discord;
using Discord.Commands;
using Discord.WebSocket;
using ClassLibrary;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'choose' del bot. Este comando permite al
/// jugador seleccionar seis Pokémon para la batalla, separados por espacios.
/// </summary>
// ReSharper disable once UnusedType.Global
public class ChooseCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'choose'. Este comando toma una lista de seis nombres
    /// de Pokémon separados por espacios, los transforma en un array y pasa
    /// la información a la fachada para registrar la selección.
    /// </summary>
    [Command("choose")]
    [Summary(
        """
        Permite al jugador seleccionar seis Pokémon para la batalla, separados por
        espacios. Los nombres deben coincidir con los del catálogo disponible.
        """)]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync(
        [Remainder]
        [Summary("Nombres de los seis Pokémon, separados por espacios")]
        string pokemonsInput)
    {
        try
        {
            // Transformar la entrada del usuario en un array de nombres de Pokémon
            string[] pokemonNames = pokemonsInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Validar que el usuario haya ingresado exactamente seis nombres
            if (pokemonNames.Length != 6)
            {
                await ReplyAsync("Debes seleccionar exactamente 6 Pokémon, separados por espacios. Ejemplo: `!choose Lapras Gengar Charizard Pikachu Lucario Jigglypuff`");
                return;
            }

            // Obtener el display name del jugador
            string playerDisplayName = CommandHelper.GetDisplayName(Context);

            // Llamar al método de la fachada para registrar la selección
            string result = Facade.Instance.ChoosePokemons(playerDisplayName, pokemonNames);

            // Responder con el resultado de la operación
            await ReplyAsync(result);
        }
        catch (Exception ex)
        {
            // Manejo de errores genéricos
            Console.WriteLine($"Error en el comando 'choose': {ex.Message}");
            await ReplyAsync($"Ocurrió un error inesperado: {ex.Message}");
        }
    }
}
