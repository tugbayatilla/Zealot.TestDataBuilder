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
        
        entity.StringProp.Should().MatchRegex("StringProp_[0-9]");
        
        entity.StringNullableProp.Should().NotBeNull();
        entity.StringNullableProp2.Should().NotBeNull();
        
        entity.StringNullableProp.Should().MatchRegex("StringNullableProp_[0-9]");
        entity.StringNullableProp2.Should().MatchRegex("StringNullableProp2_[0-9]");
    }
    
    [Fact]
    public void Support_string_has_default_value()
    {
        var instance = TestDataBuilder
            .For<ClassWithStringHavingDefaultValue>()
            .Build();

        instance.Prop.Should().MatchRegex("Prop_[0-9]");
    }
}
