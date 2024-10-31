namespace ClassLibrary
{
    /// <summary>
    /// La clase PokemonCatalog tiene la responsabilidad de acceder a los atributos de los Pokémons y gestionar 
    /// un catálogo de Pokémons. Permite buscar un Pokémon por su nombre.
    ///
    /// Esta clase está separada para cumplir con el principio de responsabilidad única (SRP), ya que está especializada
    /// en conocer y gestionar únicamente el catálogo de Pokémons. Cualquier cambio en cómo se almacenan
    /// o gestionan los datos de los Pokémons se realizaría únicamente aquí.
    /// 
    /// Tener esta clase como experta en la gestión del catálogo de Pokémons facilita futuras expansiones, como cambiar
    /// la forma de almacenar los datos, añadir nuevas formas de búsqueda o modificar la fuente del catálogo, minimizando 
    /// así las razones de cambio y centralizando la responsabilidad.
    /// </summary>
    
    public class PokemonCatalog
    {
        // El builder crea y gestiona la lista de Pokémon del catálogo. Esta variable es estática porque el catállogo de pokemon es único y no cambainte en la solución.  
        private static PokemonCatalogBuilder catalog = new PokemonCatalogBuilder();
        
        // Lista de Pokémon obtenida a través del builder.
        private List<Pokemon> pokemons = catalog.GetPokemonList();

        /// <summary>
        /// Encuentra un Pokémon por su nombre en el catálogo.
        /// Recorre la lista de Pokémon y devuelve el objeto correspondiente si encuentra una coincidencia.
        /// Si no encuentra el Pokémon, retorna null.
        /// </summary>
        /// <param name="pokemonName">Nombre del Pokémon a buscar.</param>
        /// <returns>El objeto Pokemon si se encuentra, de lo contrario null.</returns>
        
        public Pokemon FindPokemonByName(string pokemonName) //que pokemonname no sea nulo
        {
            // Recorre la lista de Pokémons en busca del nombre proporcionado.
            foreach (Pokemon pokemon in catalog.GetPokemonList())
            {
                if (pokemon.Name.Equals(pokemonName, StringComparison.OrdinalIgnoreCase))
                {
                    return pokemon; // Retorna el Pokémon si encuentra coincidencia en el nombre.
                }
            }
    
            // Si no se encuentra ningún Pokémon, retorna null después de recorrer todo el catálogo.
            return null;
        }
    }
}