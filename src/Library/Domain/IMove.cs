namespace ClassLibrary;

public interface IMove
{
    string Name { get; set; }
    int AttackValue { get; set;}
    double Accuracy { get; set; }
    void ExecuteMove(Pokemon attacker, Pokemon target, double criticHit);
}
