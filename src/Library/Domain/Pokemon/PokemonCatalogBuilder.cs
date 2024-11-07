namespace ClassLibrary
{
    /// <summary>
    /// La clase  <c>PokemonCatalogBuilder</c> se encarga de crear y configurar un catálogo de Pokémon, gestionando la asignación
    /// de atributos y movimientos. Aplica el Principio de Responsabilidad Única (SRP) al centralizar toda la lógica
    /// de construcción, lo que facilita el mantenimiento. Como patrón de diseño, se puede considerar un Builder, ya que
    /// permite crear objetos complejos de manera controlada. Además, utiliza el patrón Expert de GRASP, siendo la autoridad
    /// en la creación de Pokémon, lo que asegura una implementación coherente. Cumple con el Principio de Sustitución de
    /// Liskov (LSP), permitiendo su extensión sin afectar al catálogo. Esta estructura promueve un diseño desacoplado y escalable,
    /// facilitando la integración de nuevas funcionalidades en el sistema.
    /// </summary>
    public class PokemonCatalogBuilder
    {
        // Lista de Pokémons que serán añadidos al catálogo.
        private List<Pokemon> Pokemons = new List<Pokemon>();

        /// <summary>
        /// Constructor de la clase que inicializa y añade varios Pokémon al catálogo.
        /// </summary>
        public PokemonCatalogBuilder()
        {
            AddPokemonToCatalog("Blaziken", new List<Move>
            {
                new MoveNormal("Patada Ígnea", 80, 0.5),
                new MoveNormal("Llamarada", 90, 0.7),
                new MoveNormal("Tajo Aéreo", 70, 0.5),
                new MoveBurn("Anillo Ígneo", 0, 0.3) 
            }, PokemonType.Type.Fire);

            AddPokemonToCatalog("Tinkaton", new List<Move>
            {
                new MoveNormal("Carantoña", 90, 0.6),
                new MoveNormal("Roca Afilada", 80, 0.5),
                new MoveNormal("Golpe Mordaza", 85, 0.8),
                new MovePoison("Martillo Gigante", 5, 0.8) 
            }, PokemonType.Type.Poison);

            AddPokemonToCatalog("Salamence", new List<Move>
            {
                new MoveNormal("Enfado", 120, 0.4),
                new MoveNormal("Lanzallamas", 90, 0.6),
                new MoveNormal("Cabeza de Hierro", 80, 0.9),
                new MoveParalize("Vuelo", 5, 0.4) 
            }, PokemonType.Type.Dragon);

            AddPokemonToCatalog("Bellsprout", new List<Move>
            {
                new MoveNormal("Absorber", 20, 0.7),
                new MoveNormal("Látigo Cepa", 45, 0.4),
                new MoveNormal("Ácido", 40, 0.9),
                new MoveBurn("Rayo Solar", 15, 0.3) 
            }, PokemonType.Type.Grass);

            AddPokemonToCatalog("Zangoose", new List<Move>
            {
                new MoveNormal("Cuchillada", 70, 0.85),
                new MoveNormal("Garra Brutal", 90, 0.6),
                new MoveNormal("Despejar", 60, 0.9),
                new MoveSleep("Danza Espada", 0, 1.0) 
            }, PokemonType.Type.Normal);

            AddPokemonToCatalog("Rayquaza", new List<Move>
            {
                new MoveNormal("Ascenso Draco", 120, 0.5),
                new MoveNormal("Pulso Dragón", 85, 0.8),
                new MoveNormal("Rayo Hielo", 90, 0.7),
                new MoveNormal("Hiperrayo", 40, 0.9) 
            }, PokemonType.Type.Dragon);

            AddPokemonToCatalog("Wailord", new List<Move>
            {
                new MoveNormal("Hidrobomba", 110, 0.5),
                new MoveNormal("Cuerpo Pesado", 85, 0.8),
                new MoveNormal("Ventisca", 110, 0.5),
                new MovePoison("Salto Cañón", 5, 0.9) 
            }, PokemonType.Type.Water);

            AddPokemonToCatalog("Sudowoodo", new List<Move>
            {
                new MoveNormal("Avalancha", 75, 0.7),
                new MoveNormal("Lanzarrocas", 50, 0.85),
                new MoveNormal("Terremoto", 100, 0.5),
                new MoveParalize("Maldición", 10, 0.8) 
            }, PokemonType.Type.Rock);

            AddPokemonToCatalog("Mew", new List<Move>
            {
                new MoveNormal("Psíquico", 90, 0.9),
                new MoveNormal("Sombra Vil", 70, 0.8),
                new MoveNormal("Corte", 50, 1.0),
                new MoveSleep("Aurasfera", 0, 0.9) 
            }, PokemonType.Type.Psychic);

            AddPokemonToCatalog("Azumarill", new List<Move>
            {
                new MoveNormal("Rayo Burbuja", 65, 0.8),
                new MoveNormal("Cola Férrea", 75, 0.7),
                new MoveNormal("Carantoña", 90, 0.6),
                new MoveBurn("Acua Jet", 5, 1.0) 
            }, PokemonType.Type.Water);

            AddPokemonToCatalog("Jigglypuff", new List<Move>
            {
                new MoveNormal("Placaje", 40, 0.9),
                new MoveNormal("Doble Bofetón", 30, 0.8),
                new MoveNormal("Bostezo", 20, 0.85),
                new MoveNormal("Hipnosis", 25, 0.6) 
            }, PokemonType.Type.Normal);

            AddPokemonToCatalog("Lucario", new List<Move>
            {
                new MoveNormal("Esfera Aural", 80, 0.9),
                new MoveNormal("Velocidad Extrema", 80, 0.95),
                new MoveNormal("Puño Incremento", 50, 0.85),
                new MovePoison("Aurasfera", 10, 1.0) 
            }, PokemonType.Type.Fighting);
            
            AddPokemonToCatalog("Pikachu", new List<Move>
            {
                new MoveNormal("Impactrueno", 40, 0.95),
                new MoveNormal("Rayo", 90, 0.7),
                new MoveParalize("Onda Trueno", 0, 0.9), 
                new MoveNormal("Voltio Cruel", 100, 0.6) 
            }, PokemonType.Type.Electric);

            AddPokemonToCatalog("Charizard", new List<Move>
            {
                new MoveNormal("Lanzallamas", 90, 0.7),
                new MoveNormal("Garra Dragón", 80, 0.8),
                new MoveBurn("Anillo Ígneo", 5, 0.8),     
                new MoveNormal("Tajo Aéreo", 70, 0.9)     
            }, PokemonType.Type.Fire);

            AddPokemonToCatalog("Gengar", new List<Move>
            {
                new MoveNormal("Bola Sombra", 80, 0.8),
                new MoveNormal("Psíquico", 90, 0.7),
                new MoveSleep("Hipnosis", 0, 0.6),        
                new MovePoison("Bomba Lodo", 90, 0.7)     
            }, PokemonType.Type.Ghost);

            AddPokemonToCatalog("Lapras", new List<Move>
            {
                new MoveNormal("Surf", 90, 0.8),
                new MoveNormal("Ventisca", 110, 0.6),
                new MoveBurn("Canto Helado", 5, 0.9),     
                new MoveNormal("Cabeza de Hierro", 80, 0.8) 
            }, PokemonType.Type.Water);
}

        
        /// <summary>
        /// Método privado que añade un Pokémon al catálogo, asignando su nombre, lista de movimientos y movimiento especial.
        /// </summary>
        /// <param name="name">Nombre del Pokémon.</param>
        /// <param name="moves">Lista de movimientos del Pokémon.</param>
        /// <param name="specialNormalMove">Movimiento especial del Pokémon.</param>
        /// <param name="type">El tipo del Pokémon.</param>
        private void AddPokemonToCatalog(string name, List<Move> moves, PokemonType.Type type)
        {
            // Validar todos los parámetros en una única condición
            if (string.IsNullOrWhiteSpace(name) || moves == null || moves.Count == 0 || !Enum.IsDefined(typeof(PokemonType.Type), type))
            {
                throw new ArgumentException("Uno o más parámetros son inválidos. Verifique el nombre, la lista de movimientos o el tipo.");
            }
            
            // Crea una nueva instancia de un Pokémon y le asigna sus atributos.
            Pokemon pokemon = new Pokemon();
            pokemon.Name = name;
            pokemon.HealthPoints = 100;
            pokemon.Moves = moves;
            pokemon.Type = type;
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
