namespace ClassLibrary
{
    /// <summary>
    /// La clase  <c>PokemonCatalog</c> se encarga de gestionar el acceso y la manipulación de un catálogo de Pokémon, siguiendo
    /// el Principio de Responsabilidad Única (SRP), lo que significa que se especializa exclusivamente en la gestión de
    /// datos de los Pokémon. Esto asegura que cualquier modificación en la forma de almacenar o buscar Pokémon se realice
    /// centralizadamente en esta clase, minimizando el impacto en el resto del sistema. Además, al aplicar el patrón
    /// Expert de GRASP, PokemonCatalog se convierte en la autoridad en la gestión del catálogo, lo que facilita la
    /// incorporación de nuevas características, como métodos de búsqueda adicionales o cambios en la fuente de datos,
    /// sin necesidad de alteraciones significativas en otras partes del código. Se utilizan distintas instancias del mismo
    /// catálogo al seleccionar los pokemones, para asegurar que no compartan una misma instancia.  
    /// </summary>
    
    public class PokemonCatalog
    {
        // Lista de Pokémon obtenida a través del builder.
        private IReadOnlyList<Pokemon> pokemons;

        public PokemonCatalog()
        {
            PokemonCatalogBuilder builder = new PokemonCatalogBuilder();
            this.pokemons = builder.PokemonList;
        }
 
        /// <summary>
        /// Encuentra un Pokémon por su nombre en el catálogo.
        /// Recorre la lista de Pokémon y devuelve el objeto correspondiente si encuentra una coincidencia.
        /// Si no encuentra el Pokémon, retorna null.
        /// </summary>
        /// <param name="pokemonName">Nombre del Pokémon a buscar.</param>
        /// <returns>El objeto Pokemon si se encuentra, de lo contrario null.</returns>
        public Pokemon FindPokemonByName(string pokemonName) 
        {
            // Verifica que la string no esté vacía.
            if (string.IsNullOrWhiteSpace(pokemonName))
            {
                throw new ArgumentException("El nombre del Pokémon no puede estar vacío.", nameof(pokemonName));
            }
            
            // Recorre la lista de Pokémons en busca del nombre proporcionado.
            foreach (Pokemon pokemon in this.pokemons)
            {
                if (pokemon.Name.Equals(pokemonName, StringComparison.OrdinalIgnoreCase))
                {
                    return pokemon; // Retorna el Pokémon si encuentra coincidencia en el nombre.
                }
            }
    
            // Si no se encuentra ningún Pokémon, retorna null después de recorrer todo el catalog.
            return null;
        }
    }
}