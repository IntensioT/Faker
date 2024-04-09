namespace DtoGenerator.Generator;

// представляет  атрибут, который используется для маркировки классов, реализующих интерфейс IGenerator
public class GeneratorAttribute : Attribute
{
    public Type GenereatorType
    { get; set; }

    public GeneratorAttribute(Type genereatorType)
    {
        GenereatorType = genereatorType;
    }
}
