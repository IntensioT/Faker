namespace DtoGenerator.Generator.Generators;

[Generator(typeof(int))]
public class IntGenerator : IGenerator
{
    private readonly Random _random;

    public IntGenerator()
    {
        _random = new Random();
    }

    // generates random values from [Int32.MinValue + 1; Int32.MaxValue]
    public object Generate(Type t, Faker faker)
    {
        return _random.Next() - _random.Next();
    }
}