namespace ClassLibrary
{
    /// <summary>
    /// La clase <c>Item</c> representa un ítem genérico que puede ser utilizado en el contexto del juego.
    /// Sigue el principio de responsabilidad única ya que se encarga exclusivamente de modelar las propiedades y el comportamiento básico de un ítem.
    /// Hicimos uso del patrón de diseño Strategy que permite diferentes estrategias de implementación
    /// de un mismo método, usando el polimorfismo para sobrescribir el método <c>ApplyEffect</c> para definir comportamientos específicos de los ítems.
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
        /// - Principio de Sustitución de Liskov (LSP): Las subclases pueden proporcionar su propia implementación de este método sin alterar su comportamiento general.
        /// </summary>
        /// <param name="pokemon">El Pokémon al que se aplicará el efecto del ítem.</param>
        /// <returns>Un mensaje que indica el resultado de aplicar el efecto.</returns>
        public abstract string ApplyEffect(Pokemon pokemon);
    }
}