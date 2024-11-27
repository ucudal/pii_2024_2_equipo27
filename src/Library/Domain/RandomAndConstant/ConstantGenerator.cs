using ClassLibrary;

public class ConstantGenerator : RandomGenerator
{
    private readonly int _constantValue;

    public ConstantGenerator(int value)
    {
        _constantValue = value;
    }

    public int Generate()
    {
        return _constantValue;
    }
}