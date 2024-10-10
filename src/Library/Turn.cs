using ClassLibrary;

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

    public string ShowCurrentTurn()
    {
        return $"Current turn: {CurrentPlayer.Name} (Attack/Wait)";
    }
}
