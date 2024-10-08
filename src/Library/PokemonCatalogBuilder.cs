namespace ClassLibrary
{
    /// <summary>
    /// La clase PokemonCatalogBuilder se encarga de la creación y configuración de un catálogo de Pokémon,
    /// gestionando la asignación de atributos y movimientos para cada Pokémon. 
    /// Aplica el principio de responsabilidad única (SRP) al dedicarse exclusivamente a construir el catálogo
    /// de Pokémon, separando la lógica de creación de los Pokémon del resto de la aplicación. 
    /// Utiliza el patrón Expert, ya que es la clase que mejor conoce cómo crear un Pokémon con sus movimientos
    /// y atributos. También sigue el principio de sustitución de Liskov (LSP), ya que puede ser extendida
    /// o modificada sin afectar el funcionamiento del catálogo en otras clases.
    /// </summary>
    public class PokemonCatalogBuilder
    {
        // Lista de Pokémons que serán añadidos al catálogo.
        public List<Pokemon> Pokemons = new List<Pokemon>();

        /// <summary>
        /// Constructor de la clase que inicializa y añade varios Pokémon al catálogo.
        /// </summary>
        public PokemonCatalogBuilder()
        {
            AddPokemonToCatalog("Blaziken", new List<Move>
            {
                new Move("Patada Ígnea", 80, 20, 0),
                new Move("Llamarada", 90, 15, 0),
                new Move("Tajo Aéreo", 70, 20, 0)
            }, new Move("Anillo Ígneo", 120, 0, 0));

            AddPokemonToCatalog("Tinkaton", new List<Move>
            {
                new Move("Carantoña", 90, 20, 0),
                new Move("Roca Afilada", 80, 20, 0),
                new Move("Golpe Mordaza", 85, 25, 0)
            }, new Move("Martillo Gigante", 150, 0, 0));

            AddPokemonToCatalog("Salamence", new List<Move>
            {
                new Move("Enfado", 120, 10, 0),
                new Move("Lanzallamas", 90, 15, 0),
                new Move("Cabeza de Hierro", 80, 20, 0)
            }, new Move("Vuelo", 100, 0, 0));

            AddPokemonToCatalog("Bellsprout", new List<Move>
            {
                new Move("Absorber", 20, 10, 30),
                new Move("Látigo Cepa", 45, 20, 0),
                new Move("Ácido", 40, 15, 0)
            }, new Move("Rayo Solar", 120, 0, 0));

            AddPokemonToCatalog("Zangoose", new List<Move>
            {
                new Move("Cuchillada", 70, 20, 0),
                new Move("Garra Brutal", 90, 15, 0),
                new Move("Despejar", 60, 25, 0)
            }, new Move("Danza Espada", 0, 0, 0));

            AddPokemonToCatalog("Rayquaza", new List<Move>
            {
                new Move("Ascenso Draco", 120, 10, 0),
                new Move("Pulso Dragón", 85, 20, 0),
                new Move("Rayo Hielo", 90, 15, 0)
            }, new Move("Hiperrayo", 150, 0, 0));

            AddPokemonToCatalog("Wailord", new List<Move>
            {
                new Move("Hidrobomba", 110, 5, 0),
                new Move("Cuerpo Pesado", 85, 15, 0),
                new Move("Ventisca", 110, 5, 0)
            }, new Move("Salto Cañón", 120, 0, 0));

            AddPokemonToCatalog("Sudowoodo", new List<Move>
            {
                new Move("Avalancha", 75, 20, 0),
                new Move("Lanzarrocas", 50, 30, 0),
                new Move("Terremoto", 100, 10, 0)
            }, new Move("Maldición", 0, 20, 0));

            AddPokemonToCatalog("Mew", new List<Move>
            {
                new Move("Psíquico", 90, 15, 0),
                new Move("Sombra Vil", 70, 20, 0),
                new Move("Corte", 50, 30, 0)
            }, new Move("Aurasfera", 120, 0, 0));

            AddPokemonToCatalog("Azumarill", new List<Move>
            {
                new Move("Rayo Burbuja", 65, 20, 0),
                new Move("Cola Férrea", 75, 20, 0),
                new Move("Carantoña", 90, 15, 0)
            }, new Move("Acua Jet", 40, 0, 0));

            AddPokemonToCatalog("Jigglypuff", new List<Move>
            {
                new Move("Placaje", 40, 35, 0),
                new Move("Doble Bofetón", 30, 20, 0),
                new Move("Bostezo", 0, 0, 0)
            }, new Move("Hipnosis", 0, 0, 0));

            AddPokemonToCatalog("Lucario", new List<Move>
            {
                new Move("Esfera Aural", 80, 20, 0),
                new Move("Velocidad Extrema", 80, 5, 0),
                new Move("Puño Incremento", 50, 20, 0)
            }, new Move("Aurasfera", 120, 0, 0));
        }

        /// <summary>
        /// Método privado que añade un Pokémon al catálogo, asignando su nombre, lista de movimientos y movimiento especial.
        /// </summary>
        /// <param name="name">Nombre del Pokémon.</param>
        /// <param name="moves">Lista de movimientos del Pokémon.</param>
        /// <param name="specialMove">Movimiento especial del Pokémon.</param>
        private void AddPokemonToCatalog(string name, List<Move> moves, Move specialMove)
        {
            // Crea una nueva instancia de un Pokémon y le asigna sus atributos.
            Pokemon pokemon = new Pokemon();
            pokemon.Name = name;
            pokemon.HealthPoints = 100;
            pokemon.SpecialMove = specialMove;
            pokemon.Moves = moves;
            this.Pokemons.Add(pokemon); // Añade el Pokémon a la lista del catálogo.
        }

        /// <summary>
        /// Devuelve la lista de todos los Pokémon creados en el catálogo.
        /// </summary>
        /// <returns>Lista de Pokémon.</returns>
        public List<Pokemon> GetPokemonList()
        {
            return Pokemons; // Retorna la lista de Pokémon del catálogo.
        }
    }
}
