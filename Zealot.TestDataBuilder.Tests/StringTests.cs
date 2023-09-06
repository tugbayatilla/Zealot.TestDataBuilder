using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class StringTests
{
    [Fact]
    public void Support_string()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoString>()
            .Build();

        entity.Prop1.Should().MatchBuilderNamingRegex();
        entity.Prop2.Should().MatchBuilderNamingRegex();
    }
    
    [Fact]
    public void Support_string_nullable()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoStringNullable>()
            .Build();

        entity.Prop1.Should().MatchBuilderNamingRegex();
        entity.Prop2.Should().MatchBuilderNamingRegex();
    }
    
    [Fact]
    public void Support_ignore_string_default_value()
    {
        var instance = TestDataBuilder
            .For<ClassWithStringHavingDefaultValue>()
            .Build();

        instance.Prop.Should().MatchBuilderNamingRegex();
    }
}
