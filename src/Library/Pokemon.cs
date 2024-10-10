namespace ClassLibrary;

//Esta clase tiene la responsabilidad de conocer los atributos de un pokemom, sus ataques, su ataque especial, puntos de salud, y nombre
public class Pokemon
{
    public string Name { get; set; }
    public int HealthPoints { get; set; }
    public Move SpecialMove { get; set; } 
    public List<Move> Moves { get; set; }
    
    
    // Agregamos un atributo para almacenar los puntos de salud máximos
    public int MaxHealthPoints { get; set; }
    
    public Pokemon()
    {
        Moves = new List<Move>(); 
    }

    public void AddMove(Move move)
    {
        Moves.Add(move);
    }
    
    // Método para recibir daño
    public void TakeDamage(int damage)
    {
        HealthPoints -= damage;
        if (HealthPoints < 0)
        {
            HealthPoints = 0; // Asegúrate de que no baje de cero
        }
    }

    // Método para restaurar salud, si es necesario
    public void Heal(int amount)
    {
        HealthPoints += amount;
        if (HealthPoints > MaxHealthPoints)
        {
            HealthPoints = MaxHealthPoints; // Asegúrate de que no supere el máximo
        }
    }
}