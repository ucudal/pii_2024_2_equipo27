namespace ClassLibrary;

//Esta clase  tiene la responsabilidad de conocer los valores de ataque defensa y cura de los ataques o movimientos
public class Move
{
    public string Name { get; private set; }
    public int AttackValue { get; private set; }
    public int DefenseValue { get; private set; }
    public int CureValue { get; private set; }

    public Move(string name, int attackValue, int defenseValue, int cureValue)
    {
        this.Name = name;
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
        this.CureValue = cureValue;
    }
}