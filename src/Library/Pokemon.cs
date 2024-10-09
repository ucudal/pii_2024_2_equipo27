namespace ClassLibrary;

//Esta clase tiene la responsabilidad de conocer los atributos de un pokemom, sus ataques, su ataque especial, puntos de salud, y nombre
public class Pokemon
{
    public string Name { get; set; }
    public int HealthPoints { get; set; }
    public Move SpecialMove { get; set; } 
    public List<Move> Moves { get; set; }
    
    public Pokemon()
    {
        Moves = new List<Move>(); 
    }

    public void AddMove(Move move)
    {
        Moves.Add(move);
    }
    
}