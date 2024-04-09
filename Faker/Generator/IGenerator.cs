namespace DtoGenerator.Generator;

// Определяет общий контракт для всех генераторов, которые будут использоваться в генераторе DTO.
public interface IGenerator
{
    object Generate(Type t, Faker faker);
}
