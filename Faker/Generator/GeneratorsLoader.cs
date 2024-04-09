using System.Reflection;

namespace DtoGenerator.Generator;

//Класс используется для динамической загрузки и инициализации генераторов на основе плагинов, реализующих интерфейс IGenerator и имеющих атрибут GeneratorAttribute
public class GeneratorsLoader
{
    internal bool IsGenerator(Type t)
    {
        string? generatorInterfacePath = typeof(IGenerator).FullName;
        if (generatorInterfacePath == null )
        {
            return false;
        }
        // Проверка реализует ли тип этот интерфейс
        Type? type = t.GetInterface(generatorInterfacePath);
        if (type == null)
        {
            return false;
        }
            
        Attribute? attribute = t.GetCustomAttribute(typeof(GeneratorAttribute));
        return attribute != null;
    }

    public Dictionary<Type, IGenerator> LoadGenerators(string pluginAssemblyPath)
    {
        Dictionary<Type, IGenerator> loadedGenerators = new();

        // Загружаем сборку плагинов и получаем все ожидаемые типы 
        Assembly pluginAssembly = Assembly.LoadFile(pluginAssemblyPath);
        Type[] expectedPlugins = pluginAssembly.GetTypes();

        foreach (Type expectedPlugin in expectedPlugins)
        {
            // Проверяем является ли тип генератором
            if (IsGenerator(expectedPlugin))
            {
                GeneratorAttribute generatorAttribute = (GeneratorAttribute)expectedPlugin
                    .GetCustomAttribute(typeof(GeneratorAttribute))!;
                //Создаем экземпляр генератора 
                Type generatedValueType = generatorAttribute.GenereatorType;
                IGenerator? generator = Activator.CreateInstance(expectedPlugin) as IGenerator;
                loadedGenerators[generatedValueType] = generator!;
            }
        }

        return loadedGenerators;
    }
}
