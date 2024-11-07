using System.Collections.ObjectModel;
using ClassLibrary;

namespace ClassLibrary;

/// <summary>
/// La clase <c>WaitingList</c> es responsable de gestionar la lista de jugadores en espera para jugar.
/// Aplica el principio de responsabilidad única (SRP) al enfocarse exclusivamente en las operaciones
/// relacionadas con la lista de espera de jugadores, como agregar, remover y buscar.
/// Utiliza el patrón Expert, ya que posee toda la información necesaria para manejar la lista
/// de jugadores de manera eficiente, promoviendo una alta cohesión.
/// Además, está diseñada para ser extensible en el futuro, siguiendo el principio abierto/cerrado (OCP),
/// permitiendo, por ejemplo, la selección de un jugador aleatorio sin modificar la estructura básica.
/// La clase mantiene su robustez y seguridad al validar las entradas y evitar estados inválidos.
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
        // Verifica que el nombre no esté vacío o nulo
        if (string.IsNullOrEmpty(DisplayName))
        {
            throw new ArgumentException(nameof(DisplayName));
        }
        
        // Verifica que el nombre no esté vacío o nulo
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
        // Verifica que el nombre no esté vacío o nulo
        if (string.IsNullOrEmpty(DisplayName))
        {
            throw new ArgumentException("El nombre de usuario no puede estar vacío o nulo.", nameof(DisplayName));
        }
        Player player = this.FindPlayerByDisplayName(DisplayName);
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
    public Player FindPlayerByDisplayName(string DisplayName)
    {
        // Verifica que el nombre no esté vacío o nulo
        if (string.IsNullOrEmpty(DisplayName))
        {
            throw new ArgumentException("El nombre de usuario no puede estar vacío o nulo.", nameof(DisplayName));
        }
        
        // Busca en la lista de jugadores
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
    public Player GetAnyoneWaiting()
    {
        // Verifica si la lista está vacía
        if (this.players.Count == 0)
        {
            return null;
        }

        return this.players[0];
    }
}