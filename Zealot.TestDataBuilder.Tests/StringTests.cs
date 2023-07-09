using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class StringTests
{
    [Fact]
    public void Support_string()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllPrimitives>()
            .WithOnly<string>()
            .Build();
        
        entity.StringProp.Should().Be($"{nameof(entity.StringProp)}");
        
        entity.StringNullableProp.Should().NotBeNull();
        entity.StringNullableProp2.Should().NotBeNull();
        
        entity.StringNullableProp.Should().Be($"{nameof(entity.StringNullableProp)}");
        entity.StringNullableProp2.Should().Be($"{nameof(entity.StringNullableProp2)}");
    }
    
    //todo: support default value for all primitive types 
    [Fact]
    public void Support_string_has_default_value()
    {
        var instance = TestDataBuilder
            .For<ClassWithStringHavingDefaultValue>()
            .Build();

        instance.Prop.Should().Be("DefaultValueStringProp1");
    }
}
