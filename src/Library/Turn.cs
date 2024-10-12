namespace ClassLibrary;

//Esta clase conoce las especificaciones del turno de un jugador actual con sus correspondientes ataques 

public class Turn
{
    public Player CurrentPlayer;
    public Player WaitingPlayer;
    public Player PenalizedPlayer;

    public Turn(Player player1, Player player2)
    {
        CurrentPlayer = player1;
        WaitingPlayer = player2;
    }

    public void ChangeTurn()
    {
        var temp = CurrentPlayer;
        CurrentPlayer = WaitingPlayer;
        WaitingPlayer = temp;
    }

    public override bool Equals(object obj)
    {
        return obj is Turn turn &&
               EqualityComparer<Player>.Default.Equals(CurrentPlayer, turn.CurrentPlayer);
    }

    public void PenalizeTurn(Player player)
    {
        if (player == CurrentPlayer)
        {
            PenalizedPlayer = CurrentPlayer;
            ChangeTurn();
            Console.WriteLine($"{PenalizedPlayer.Name} has lost their turn.");
        }
        else
        {
            Console.WriteLine($"{player.Name} is not currently playing.");
        }
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
    