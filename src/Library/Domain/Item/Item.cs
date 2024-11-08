namespace ClassLibrary
{
    /// <summary>
    /// La clase <c>Item</c> representa un ítem genérico que puede ser utilizado en el contexto del juego.
    /// - Principio de Responsabilidad Única (SRP): Se encarga exclusivamente de modelar las propiedades y el comportamiento básico de un ítem.
    /// - Patrón Polimorfismo (GRASP): Permite a las subclases sobrescribir el método <c>ApplyEffect</c> para definir comportamientos específicos de los ítems.
    /// - Inmutabilidad: La propiedad <c>Name</c> es de solo lectura, garantizando que el nombre del ítem no pueda ser modificado después de su creación.
    /// </summary>
    public class Item
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
        public virtual string ApplyEffect(Pokemon pokemon)
        {
            return $"{Name} no tiene ningún efecto.";
        }
    }
}