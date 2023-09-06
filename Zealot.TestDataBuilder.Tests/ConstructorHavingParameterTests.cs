using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class ConstructorHavingParameterTests
{
    [Fact]
    public void Class_in_constructor_set()
    {
        var entity = TestDataBuilder
            .For<ClassWithOneClassInConstructor>()
            .Build();
        
        entity.Should().NotBeNull();
        entity.Prop1.Should().MatchBuilderNamingRegex();
        entity.Prop2.Should().MatchBuilderNamingRegex();
    }
    
    [Fact]
    public void Strings_in_constructor_set()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoStringInConstructor>()
            .Build();

        entity.Prop1.Should().MatchBuilderNamingRegex();
        entity.Prop2.Should().MatchBuilderNamingRegex();
    }
    
    [Fact]
    public void DateTime_in_constructor_set()
    {
        var now = DateTime.Now;
        var sample = TestDataBuilder
            .For<ClassWithOneDateTimeInConstructor>()
            .WithDate(now)
            .Build();

        sample.Should().NotBeNull();
        sample.Prop.Should().Be(now);
    }
}