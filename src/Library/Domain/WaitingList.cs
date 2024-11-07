using System.Collections.ObjectModel;
using ClassLibrary;

namespace ClassLibrary;

/// <summary>
/// Esta clase representa la lista de jugadores esperando para jugar.
/// </summary>
public class WaitingList
{
    private readonly List<Player> players = new List<Player>();

    public int Count
    {
        get { return this.players.Count; }
    }

    public ReadOnlyCollection<Player> GetAllWaiting()
    {
        return this.players.AsReadOnly();
    }
    
    /// <summary>
    /// Agrega un jugador a la lista de espera.
    /// </summary>
    /// <param name="DisplayName">El nombre de usuario de Discord en el servidor
    /// del bot a agregar.
    /// </param>
    /// <returns><c>true</c> si se agrega el usuario; <c>false</c> en caso
    /// contrario.</returns>
    public bool AddPlayer(string DisplayName)
    {
        if (string.IsNullOrEmpty(DisplayName))
        {
            throw new ArgumentException(nameof(DisplayName));
        }
        
        if (this.FindPlayerByDisplayName(DisplayName) != null) return false;
        players.Add(new Player(DisplayName));
        return true;

    }

    /// <summary>
    /// Remueve un jugador de la lista de espera.
    /// </summary>
    /// <param name="DisplayName">El nombre de usuario de Discord en el servidor
    /// del bot a remover.
    /// </param>
    /// <returns><c>true</c> si se remueve el usuario; <c>false</c> en caso
    /// contrario.</returns>
    public bool RemovePlayer(string DisplayName)
    {
        Player? player = this.FindPlayerByDisplayName(DisplayName);
        if (player == null) return false;
        players.Remove(player);
        return true;

    }

    /// <summary>
    /// Busca un jugador por el nombre de usuario de Discord en el servidor del
    /// bot.
    /// </summary>
    /// <param name="DisplayName">El nombre de usuario de Discord en el servidor
    /// del bot a buscar.
    /// </param>
    /// <returns>El jugador encontrado o <c>null</c> en caso contrario.
    /// </returns>
    public Player? FindPlayerByDisplayName(string DisplayName)
    {
        foreach (Player player in this.players)
        {
            if (player.DisplayName == DisplayName)
            {
                return player;
            }
        }

        return null;
    }

    /// <summary>
    /// Retorna un jugador cualquiera esperando para jugar. En esta
    /// implementación provista no es cualquiera, sino el primero. En la
    /// implementación definitiva, debería ser uno aleatorio.
    /// 
    /// </summary>
    /// <returns></returns>
    public Player? GetAnyoneWaiting()
    {
        if (this.players.Count == 0)
        {
            return null;
        }

        return this.players[0];
    }
}