namespace ClassLibrary;

using System.Collections.Generic;
/// <summary>
/// La clase <c>PokemonType</c> es responsable de gestionar los tipos de Pokémon y su efectividad en combates.
/// Aplica el principio de responsabilidad única (SRP) al enfocarse exclusivamente en la lógica de tipos y 
/// efectividad de ataques entre tipos.
/// Utiliza el patrón Expert, ya que posee toda la información necesaria para determinar la efectividad de los ataques
/// entre tipos, promoviendo alta cohesión y bajo acoplamiento con otras clases.
/// Además, sigue el principio abierto/cerrado (OCP), permitiendo agregar nuevos tipos o combinaciones de efectividad
/// sin modificar la estructura de la clase.
/// La robustez y seguridad de esta clase se aseguran al validar la existencia de combinaciones de tipos y evitar
/// estados inválidos, facilitando la detección y manejo de errores en el uso de esta clase.
/// </summary>

public static class PokemonType
{
    /// <summary>
    /// Enumeración que define los tipos de Pokémon.
    /// </summary>
    public enum Type
    {
        Water, Bug, Dragon, Electric, Ghost, Fire,
        Ice, Fighting, Normal, Grass, Psychic, Rock,
        Ground, Poison, Flying
    }

    private static Dictionary<(Type, Type), double> typeEffectiveness = new Dictionary<(Type, Type), double>() 
    {
    // Water defender
    { (Type.Water, Type.Electric), 2.0 },
    { (Type.Water, Type.Grass), 2.0 },
    { (Type.Water, Type.Water), 0.5 },
    { (Type.Water, Type.Fire), 0.5 },
    { (Type.Water, Type.Ice), 0.5 },

    // Bug defender
    { (Type.Bug, Type.Fire), 2.0 },
    { (Type.Bug, Type.Rock), 2.0 },
    { (Type.Bug, Type.Flying), 2.0 },
    { (Type.Bug, Type.Poison), 2.0 },
    { (Type.Bug, Type.Fighting), 0.5 },
    { (Type.Bug, Type.Grass), 0.5 },
    { (Type.Bug, Type.Ground), 0.5 },

    // Dragon defender
    { (Type.Dragon, Type.Dragon), 2.0 },
    { (Type.Dragon, Type.Ice), 2.0 },
    { (Type.Dragon, Type.Water), 0.5 },
    { (Type.Dragon, Type.Electric), 0.5 },
    { (Type.Dragon, Type.Fire), 0.5 },
    { (Type.Dragon, Type.Grass), 0.5 },

    // Electric defender
    { (Type.Electric, Type.Ground), 2.0 },
    { (Type.Electric, Type.Flying), 0.5 },
    { (Type.Electric, Type.Electric), 0.0 },

    // Ghost defender
    { (Type.Ghost, Type.Ghost), 2.0 },
    { (Type.Ghost, Type.Normal), 0.5 },
    { (Type.Ghost, Type.Poison), 0.5 },
    { (Type.Ghost, Type.Fighting), 0.5 },

    // Fire defender
    { (Type.Fire, Type.Water), 2.0 },
    { (Type.Fire, Type.Rock), 2.0 },
    { (Type.Fire, Type.Ground), 2.0 },
    { (Type.Fire, Type.Bug), 0.5 },
    { (Type.Fire, Type.Grass), 0.5 },
    
    // Ice defender
    { (Type.Ice, Type.Fire), 2.0 },
    { (Type.Ice, Type.Fighting), 2.0 },
    { (Type.Ice, Type.Rock), 2.0 },
    { (Type.Ice, Type.Ice), 0.5 },

    // Fighting defender
    { (Type.Fighting, Type.Psychic), 2.0 },
    { (Type.Fighting, Type.Flying), 2.0 },
    { (Type.Fighting, Type.Bug), 2.0 },
    { (Type.Fighting, Type.Rock), 2.0 },

    // Normal defender
    { (Type.Normal, Type.Fighting), 2.0},
    { (Type.Normal, Type.Ghost), 0.0 },

    // Grass defender
    { (Type.Grass, Type.Bug), 2.0 },
    { (Type.Grass, Type.Fire), 2.0 },
    { (Type.Grass, Type.Ice), 2.0 },
    { (Type.Grass, Type.Poison), 2.0 },
    { (Type.Grass, Type.Flying), 2.0 },
    { (Type.Grass, Type.Water), 0.5 },
    { (Type.Grass, Type.Ground), 0.5 },
    { (Type.Grass, Type.Electric), 0.5 },
    { (Type.Grass, Type.Grass), 0.5 },

    // Psychic defender
    { (Type.Psychic, Type.Bug), 2.0 },
    { (Type.Psychic, Type.Fighting), 2.0 },
    { (Type.Psychic, Type.Ghost), 2.0 },

    // Rock defender
    { (Type.Rock, Type.Water), 2.0 },
    { (Type.Rock, Type.Fighting), 2.0 },
    { (Type.Rock, Type.Grass), 2.0 },
    { (Type.Rock, Type.Ground), 2.0 },
    { (Type.Rock, Type.Fire), 0.5 },
    { (Type.Rock, Type.Poison), 0.5 },
    { (Type.Rock, Type.Flying), 0.5 },
    { (Type.Rock, Type.Normal), 0.5 },

    // Ground defender
    { (Type.Ground, Type.Water), 2.0  },
    { (Type.Ground, Type.Ice), 2.0  },
    { (Type.Ground, Type.Grass), 2.0  },
    { (Type.Ground, Type.Rock), 2.0 },
    { (Type.Ground, Type.Poison), 2.0 },
    { (Type.Ground, Type.Electric), 0.5 },

    // Poison defender
    { (Type.Poison, Type.Bug), 2.0 },
    { (Type.Poison, Type.Psychic), 2.0 },
    { (Type.Poison, Type.Ground), 2.0 },
    { (Type.Poison, Type.Fighting), 2.0 },
    { (Type.Poison, Type.Grass), 0.5 },
    { (Type.Poison, Type.Poison), 0.5 },

    // Flying defender
    { (Type.Flying, Type.Electric), 2.0 },
    { (Type.Flying, Type.Ice), 2.0 },
    { (Type.Flying, Type.Rock), 2.0 },
    { (Type.Flying, Type.Grass), 0.5 },
    { (Type.Flying, Type.Bug), 0.5 },
    { (Type.Flying, Type.Fighting), 0.5 },
    { (Type.Flying, Type.Ground), 0.5 }
    };

    // Método que devuelve la efectividad entre tipos.
    /// <summary>
    /// Método que devuelve la efectividad entre tipos.
    /// </summary>
    /// <param name="defendingType">Tipo del Pokémon atacante.</param>
    /// <param name="attackingType">Tipo del Pokémon defensor.</param>
    /// <returns>
    /// El multiplicador de daño según la efectividad entre tipos. 
    /// Devuelve 1.0 si no hay ventaja o desventaja.
    /// </returns>

    public static double GetEffectiveness(Type defendingType, Type attackingType)
    {
        // Comprobación de argumentos
        if (!Enum.IsDefined(typeof(Type), defendingType) || !Enum.IsDefined(typeof(Type), attackingType))
        {
            throw new ArgumentException("Los tipos de Pokémon proporcionados no son válidos.");
        }
        
        // Verifica si la combinación de tipos está definida en el diccionario
        if (typeEffectiveness.ContainsKey((defendingType, attackingType)))
        {
            // Retorna la efectividad correspondiente
            return typeEffectiveness[(defendingType, attackingType)];
        }
        
        return 1.0; // Daño normal si no hay ninguna ventaja/desventaja
    } 
}