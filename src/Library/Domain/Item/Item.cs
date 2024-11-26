namespace ClassLibrary;

/// <summary>
/// La clase <c>Item</c> representa un ítem genérico utilizado en el contexto del juego y se enfoca exclusivamente
/// en modelar las propiedades y el comportamiento básico de un ítem, cumpliendo así con el principio de
/// Responsabilidad Única (SRP). Actúa como una clase base abstracta que establece una estructura común para
/// todos los ítems, permitiendo que las subclases definan comportamientos específicos mediante la sobrescritura
/// del método abstracto <c>ApplyEffect</c>. Este método aplica el efecto del ítem a un Pokémon determinado, y su diseño
/// sigue el principio de Sustitución de Liskov (LSP), ya que las subclases pueden extenderlo sin alterar el contrato
/// general de la clase. Además, el diseño de la clase refleja el patrón de Template Method, ya que el método abstracto
/// sirve como una plantilla que las subclases deben implementar según su funcionalidad específica. Con estas
/// características, la clase <c>Item</c> proporciona una base sólida y extensible para la creación de diferentes tipos
/// de ítems en el juego.
/// </summary>
public abstract class Item
{
    /// <summary>
    /// Propiedad que almacena el nombre del ítem.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Constructor de la clase <c>Item</c>.
    /// Inicializa el ítem con un nombre específico.
    /// </summary>
    /// <param name="name">Nombre del ítem.</param>
    public Item(string name)
    {
        this.Name = name;
    }

    /// <summary>
    /// Aplica el efecto del ítem en el Pokémon especificado.
    /// Este método está diseñado para ser sobrescrito por subclases que implementen efectos específicos.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se aplicará el efecto del ítem.</param>
    /// <returns>Un mensaje que indica el resultado de aplicar el efecto.</returns>
    public abstract string ApplyEffect(Pokemon pokemon);
}