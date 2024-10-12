namespace ClassLibrary;

using System.Collections.Generic;
/// <summary>
/// La clase <c>PokemonType</c> gestiona los tipos de Pokémon y su efectividad en combates.
/// Proporciona una enumeración para definir los tipos de Pokémon y un método para calcular
/// la efectividad de un ataque basado en los tipos del atacante y del defensor.
/// </summary>

public class PokemonType
{
    /// <summary>
    /// Enumeración que define los tipos de Pokémon.
    /// </summary>
    public enum Type
    {
        Fire,
        Water,
        Grass,
        Rock,
        Psychic,
        Dragon,
        Normal,
        Fighting,
        Steel,
    }

    private static Dictionary<(Type, Type), double> typeEffectiveness = new Dictionary<(Type, Type), double>()
    {
         // Fire
    { (Type.Fire, Type.Grass), 2.0 },
    { (Type.Fire, Type.Water), 0.5 },
    { (Type.Fire, Type.Fire), 0.5 },
    { (Type.Fire, Type.Rock), 2.0 },
    { (Type.Fire, Type.Psychic), 1.0 },
    { (Type.Fire, Type.Dragon), 1.0 },
    { (Type.Fire, Type.Normal), 1.0 },
    { (Type.Fire, Type.Fighting), 1.0 },
    { (Type.Fire, Type.Steel), 1.0 },

    // Water
    { (Type.Water, Type.Fire), 2.0 },
    { (Type.Water, Type.Grass), 0.5 },
    { (Type.Water, Type.Water), 1.0 },
    { (Type.Water, Type.Rock), 2.0 },
    { (Type.Water, Type.Psychic), 1.0 },
    { (Type.Water, Type.Dragon), 1.0 },
    { (Type.Water, Type.Normal), 1.0 },
    { (Type.Water, Type.Fighting), 1.0 },
    { (Type.Water, Type.Steel), 1.0 },

    // Grass
    { (Type.Grass, Type.Fire), 0.5 },
    { (Type.Grass, Type.Water), 2.0 },
    { (Type.Grass, Type.Grass), 1.0 },
    { (Type.Grass, Type.Rock), 2.0 },
    { (Type.Grass, Type.Psychic), 1.0 },
    { (Type.Grass, Type.Dragon), 1.0 },
    { (Type.Grass, Type.Normal), 1.0 },
    { (Type.Grass, Type.Fighting), 1.0 },
    { (Type.Grass, Type.Steel), 0.5 },

    // Rock
    { (Type.Rock, Type.Fire), 0.5 },
    { (Type.Rock, Type.Water), 1.0 },
    { (Type.Rock, Type.Grass), 0.5 },
    { (Type.Rock, Type.Rock), 1.0 },
    { (Type.Rock, Type.Psychic), 1.0 },
    { (Type.Rock, Type.Dragon), 1.0 },
    { (Type.Rock, Type.Normal), 1.0 },
    { (Type.Rock, Type.Fighting), 1.0 },
    { (Type.Rock, Type.Steel), 1.0 },

    // Psychic
    { (Type.Psychic, Type.Fire), 1.0 },
    { (Type.Psychic, Type.Water), 1.0 },
    { (Type.Psychic, Type.Grass), 1.0 },
    { (Type.Psychic, Type.Rock), 1.0 },
    { (Type.Psychic, Type.Psychic), 1.0 },
    { (Type.Psychic, Type.Dragon), 1.0 },
    { (Type.Psychic, Type.Normal), 1.0 },
    { (Type.Psychic, Type.Fighting), 1.0 },
    { (Type.Psychic, Type.Steel), 1.0 },

    // Dragon
    { (Type.Dragon, Type.Fire), 1.0 },
    { (Type.Dragon, Type.Water), 1.0 },
    { (Type.Dragon, Type.Grass), 1.0 },
    { (Type.Dragon, Type.Rock), 1.0 },
    { (Type.Dragon, Type.Psychic), 1.0 },
    { (Type.Dragon, Type.Dragon), 2.0 },
    { (Type.Dragon, Type.Normal), 1.0 },
    { (Type.Dragon, Type.Fighting), 1.0 },
    { (Type.Dragon, Type.Steel), 1.0 },

    // Normal
    { (Type.Normal, Type.Fire), 1.0 },
    { (Type.Normal, Type.Water), 1.0 },
    { (Type.Normal, Type.Grass), 1.0 },
    { (Type.Normal, Type.Rock), 1.0 },
    { (Type.Normal, Type.Psychic), 1.0 },
    { (Type.Normal, Type.Dragon), 1.0 },
    { (Type.Normal, Type.Normal), 1.0 },
    { (Type.Normal, Type.Fighting), 1.0 },
    { (Type.Normal, Type.Steel), 1.0 },

    // Fighting
    { (Type.Fighting, Type.Fire), 1.0 },
    { (Type.Fighting, Type.Water), 1.0 },
    { (Type.Fighting, Type.Grass), 1.0 },
    { (Type.Fighting, Type.Rock), 2.0 },
    { (Type.Fighting, Type.Psychic), 0.5 },
    { (Type.Fighting, Type.Dragon), 1.0 },
    { (Type.Fighting, Type.Normal), 1.0 },
    { (Type.Fighting, Type.Fighting), 1.0 },
    { (Type.Fighting, Type.Steel), 1.0 },

    // Steel
    { (Type.Steel, Type.Fire), 0.5 },
    { (Type.Steel, Type.Water), 1.0 },
    { (Type.Steel, Type.Grass), 1.0 },
    { (Type.Steel, Type.Rock), 1.0 },
    { (Type.Steel, Type.Psychic), 1.0 },
    { (Type.Steel, Type.Dragon), 1.0 },
    { (Type.Steel, Type.Normal), 1.0 },
    { (Type.Steel, Type.Fighting), 1.0 },
    { (Type.Steel, Type.Steel), 1.0 }
    };
    
    

    // // Diccionario de efectividad: tipo atacante tipo defensor y multiplicador de daño
    // private static Dictionary<Type, Dictionary<Type, double>> typeEffectiveness = new Dictionary<Type, Dictionary<Type, double>>()
    // {
    //     { Type.Fire, new Dictionary<Type, double> { { Type.Grass, 2.0 }, { Type.Water, 0.5 }, { Type.Fire, 0.5 } } },
    //     { Type.Water, new Dictionary<Type, double> { { Type.Fire, 2.0 }, { Type.Grass, 0.5 }, { Type.Water, 0.5 } } },
    //     { Type.Grass, new Dictionary<Type, double> { { Type.Water, 2.0 }, { Type.Fire, 0.5 }, { Type.Grass, 0.5 } } },
    //     //otros tipos 
    // };

    // Método que devuelve la efectividad entre tipos.
    /// <summary>
    /// Método que devuelve la efectividad entre tipos.
    /// </summary>
    /// <param name="attackingType">Tipo del Pokémon atacante.</param>
    /// <param name="defendingType">Tipo del Pokémon defensor.</param>
    /// <returns>
    /// El multiplicador de daño según la efectividad entre tipos. 
    /// Devuelve 1.0 si no hay ventaja o desventaja.
    /// </returns>

    public static double GetEffectiveness(Type attackingType, Type defendingType)
    {
        // Verifica si la combinación de tipos está definida en el diccionario
        if (typeEffectiveness.ContainsKey((attackingType, defendingType)))
        {
            // Retorna la efectividad correspondiente
            return typeEffectiveness[(attackingType, defendingType)];
        }
        
        return 1.0; // Daño normal si no hay ninguna ventaja/desventaja
    } 
}