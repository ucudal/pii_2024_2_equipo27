namespace ClassLibrary;

//Esta clase conoce las especificaciones del turno de un jugador actual con sus correspondientes ataques 

public class Turn
{
    public bool SpecialMoveIsAvailable { get; set; }

    public Turn()
    {
        this.SpecialMoveIsAvailable = true;
    }
    
    public void PlayerAttack(Pokemon attacker, Pokemon defender, Move move)
    {
        double effectiveness = PokemonType.GetEffectiveness(attacker.Type, defender.Type);
        double baseDamage = move.AttackValue;
        
        // Calcular el daño total con la efectividad.
        double totalDamage = baseDamage * effectiveness;

        defender.HealthPoints -= (int)totalDamage;

        Console.WriteLine($"{attacker.Name} usó {move.Name} y causó {totalDamage} de daño. ¡Es {GetEffectivenessMessage(effectiveness)}!");
    }

    private string GetEffectivenessMessage(double effectiveness)
    {
        if (effectiveness > 1.0)
            return "¡súper efectivo!";
        else if (effectiveness < 1.0)
            return "no muy efectivo...";
        return "efectivo.";
    }
}
    