namespace ClassLibrary;

public class Item
{
    public string Name { get;  }

    public Item(string name)
    {
        this.Name = name;
    }
    /// <summary>
    /// Aplica el efecto del ítem en el Pokémon especificado.
    /// Este método será sobrescrito por las subclases.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se le aplicará el efecto.</param>
    /// <returns>Un mensaje con el resultado de aplicar el efecto.</returns>
    public virtual string ApplyEffect(Pokemon pokemon)
    {
        return $"{Name} no tiene ningún efecto.";
    }
}


