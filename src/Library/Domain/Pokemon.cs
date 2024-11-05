
namespace ClassLibrary
{
    /// <summary>
    /// La clase  <c>Pokemon</c> es responsable de encapsular los atributos y comportamientos específicos de un Pokémon.
    /// Aplica el principio de responsabilidad única (SRP) al gestionar exclusivamente los datos y comportamientos de
    /// cada Pokémon. Utiliza el patrón Expert, ya que posee toda la información necesaria para administrar sus atributos,
    /// como puntos de vida y movimientos. Además, permite aplicar polimorfismo y respetar el principio de sustitución de 
    /// Liskov (LSP) si se crean subclases especializadas de Pokémon con comportamientos más específicos. Este diseño 
    /// facilita la extensión de la clase para añadir nuevas categorías de Pokémon o habilidades sin modificar la clase base,
    /// alineándose con el principio abierto/cerrado (OCP) y promoviendo una alta cohesión.
    /// </summary>
    
    public class Pokemon
    {
        // Nombre del Pokémon.
        public string Name { get; set; }

        // Puntos de vida del Pokémon.
        public int HealthPoints { get; set; }

        // Movimiento especial que puede realizar el Pokémon.
        public Move SpecialMove { get; set; }
        
        //tipo de pokemon
        public PokemonType.Type Type { get; set; }

        // Lista de movimientos regulares que el Pokémon puede realizar.
        public List<Move> Moves { get; set; }

        /// <summary>
        /// Constructor que inicializa la lista de movimientos del Pokémon.
        /// </summary>
        public Pokemon()
        {
            Moves = new List<Move>(); // Inicializa la lista de movimientos vacía.
        }

        /// <summary>
        /// Añade un movimiento a la lista de movimientos regulares del Pokémon.
        /// </summary>
        /// <param name="move">Movimiento a añadir a la lista de movimientos.</param>
        public void AddMove(Move move)
        {
            Moves.Add(move); // Agrega el movimiento a la lista de movimientos.
        }
    }
}