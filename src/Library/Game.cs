namespace ClassLibrary;

//Esta clase tiene la responsabilidad de conocer los jugadores y si el juego esta activo o terminó
public class Game
{
    public Player Player1 { get; }
    public Player Player2 { get; }
    public Player TurnPlayer { get; set; }
    public bool PlayIsOn {get; set;}

    // public Game(Player player1, Player player2)
    // {
    //     this.PlayIsOn = true;
    //     this.Player1 = player1;
    //     this.Player2 = player2;
    //     this.TurnPlayer = player1;
    // }
    
}