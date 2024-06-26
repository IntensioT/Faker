using DtoGenerator;
using DtoGenerator.Config;
using DtoGenerator.Generator;
using FluentAssertions;
using Tests.ExampleClasses;
using Tests.ExampleGenerators;

namespace Tests;

[TestClass]
public class FakerTests
{
    [TestMethod]
    public void TestCyclicDependency()
    {
        Faker faker = new Faker(new GeneratorsLoader(), new FakerConfig());
        Person person = faker.Create<Person>();

        person.Mom.Should().BeNull();
        person.Dad.Should().BeNull();
    }

    

    [TestMethod]
    public void TestListGeneration()
    {
        Faker faker = new Faker(new GeneratorsLoader(), new FakerConfig());
        List<Person> people = faker.Create<List<Person>>();
        foreach (Person person in people)
        {
            person.Name.Should().NotBeNull();
        }

        List<int> ints = faker.Create<List<int>>();
        ints.Should().NotBeNull();
    }

    [TestMethod]
    public void TestGeneratingClassWithoutGenerator()
    {
        Faker faker = new(new GeneratorsLoader(), new FakerConfig());

        ClassWIthoutGenerator o = faker.Create<ClassWIthoutGenerator>();

        o.Should().BeNull();
    }

    [TestMethod]
    public void TestConfig()
    {
        FakerConfig fakerConfig = new();

        fakerConfig.Add<Person, string, NameGenerator>(person => person.Name);

        Faker faker = new(new GeneratorsLoader(), fakerConfig);

        Person person = faker.Create<Person>();

        person.Name.Should().Be("SomeRandomName");
    }

    [TestMethod]
    public void TestLoadingPlugins()
    {
        Faker faker = new Faker(new GeneratorsLoader(), new FakerConfig());
        faker.LoadPlugins([
            //"..\\GeneratorsPlugin\\bin\\Debug\\net8.0\\GeneratorsPlugin.dll"
            "D:\\Bugor\\6sem\\ProgrammingPlatforms\\projects\\2. Faker\\Faker\\GeneratorsPlugin\\bin\\Debug\\net8.0\\GeneratorsPlugin.dll"
            ]);

        string generatedValue = faker.Create<string>();

        generatedValue.Should().Be("Some Test Value");
    }
}