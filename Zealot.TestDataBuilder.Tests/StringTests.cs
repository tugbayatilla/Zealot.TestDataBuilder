using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class StringTests
{
    [Fact]
    public void Support_string()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllPrimitives>()
            .WithOnly<string>()
            .Build();

        entity.StringProp.Should().MatchBuilderNamingRegex(nameof(entity.StringProp));
        
        entity.StringNullableProp.Should().NotBeNull();
        entity.StringNullableProp2.Should().NotBeNull();
        
        entity.StringNullableProp.Should().MatchBuilderNamingRegex(nameof(entity.StringNullableProp));
        entity.StringNullableProp2.Should().MatchBuilderNamingRegex(nameof(entity.StringNullableProp2));
    }
    
    [Fact]
    public void Support_string_has_default_value()
    {
        var instance = TestDataBuilder
            .For<ClassWithStringHavingDefaultValue>()
            .Build();

        instance.Prop.Should().MatchBuilderNamingRegex(nameof(instance.Prop));
    }
    
    [Fact]
    public void Support_unique_string_content()
    {
        var instance = TestDataBuilder
            .For<ClassWithTwoString>()
            .Build();

        instance.Prop1.Should().MatchBuilderNamingRegex(nameof(instance.Prop1));
        instance.Prop2.Should().MatchBuilderNamingRegex(nameof(instance.Prop2));
    }
}
