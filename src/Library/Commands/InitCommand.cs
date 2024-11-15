using Discord.Commands;
using ClassLibrary;

namespace Library.Commands;

/// <summary>
/// Esta clase implementa el comando 'join' del bot. Este comando une al jugador
/// que envía el mensaje a la lista de jugadores esperando para jugar.
/// </summary>
// ReSharper disable once UnusedType.Global
public class InitCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'join'. Este comando une al jugador que envía el
    /// mensaje a la lista de jugadores esperando para jugar.
    /// </summary>
    [Command("init")]
    [Summary("")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        string[] attackerPokemons = new string[] { "Blaziken", "Tinkaton", "Salamence", };
        string[] defenderPokemons = new string[] { "Tinkaton", "Zangoose", "Rayquaza", };
        string move = "Patada Ígnea";
        string move2 = "Carantoña";
    
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Facade.Instance.AddPlayerToWaitingList(displayName);
        result = result + Facade.Instance.AddPlayerToWaitingList("player1");
        result = result + Facade.Instance.StartBattle(displayName, "player1");
        result = result + Facade.Instance.ChoosePokemons(displayName, attackerPokemons);
        result = result + Facade.Instance.ChoosePokemons("player1", defenderPokemons);
        Facade.Instance.ChoosePokemonAndMoveToAttack( displayName,  move, attackerPokemons[0]);
        Facade.Instance.ChoosePokemonAndMoveToAttack( "player1",  move2, defenderPokemons[0]);
        
        await ReplyAsync(result);
    }
}