namespace ClassLibrary;

public class PokemonType
{
    public enum Type
    {
        Fire,
        Water,
        Grass,
        Electric,
        Rock,
        Psychic,
        Dragon,
        Normal,
        Fighting,
        Steel,
        // Otros tipos...
    }

    // Diccionario de efectividad: tipo atacante tipo defensor y multiplicador de daño
    private static Dictionary<Type, Dictionary<Type, double>> typeEffectiveness = new Dictionary<Type, Dictionary<Type, double>>()
    {
        { Type.Fire, new Dictionary<Type, double> { { Type.Grass, 2.0 }, { Type.Water, 0.5 }, { Type.Fire, 0.5 } } },
        { Type.Water, new Dictionary<Type, double> { { Type.Fire, 2.0 }, { Type.Grass, 0.5 }, { Type.Water, 0.5 } } },
        { Type.Grass, new Dictionary<Type, double> { { Type.Water, 2.0 }, { Type.Fire, 0.5 }, { Type.Grass, 0.5 } } },
        // Otros tipos...
    };

    // Método que devuelve la efectividad entre tipos.
    public static double GetEffectiveness(Type attackingType, Type defendingType)
    {
        if (typeEffectiveness.ContainsKey(attackingType) && typeEffectiveness[attackingType].ContainsKey(defendingType))
        {
            return typeEffectiveness[attackingType][defendingType];
        }
        return 1.0; // Daño normal si no hay ninguna ventaja/desventaja
    } 
}