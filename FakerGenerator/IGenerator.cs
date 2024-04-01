using DtoGenerator;

namespace FakerGenerator;

public interface IGenerator
{
    object Generate(Type t, Faker faker);
}
