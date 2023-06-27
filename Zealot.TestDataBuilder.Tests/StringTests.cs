using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class StringTests
{
    [Fact]
    public void Support_string()
    {
        var entity = TestDataBuilder
            .For<PublicWithAll>()
            .WithOnly<string>()
            .Build();
        
        entity.StringProp.Should().Be($"{nameof(entity.StringProp)}");
        
        entity.StringNullableProp.Should().NotBeNull();
        entity.StringNullableProp2.Should().NotBeNull();
        
        entity.StringNullableProp.Should().Be($"{nameof(entity.StringNullableProp)}");
        entity.StringNullableProp2.Should().Be($"{nameof(entity.StringNullableProp2)}");
    }
    
    [Fact]
    public void Support_SetOnly_method()
    {
        var entity = TestDataBuilder
            .For<PublicWithAll>()
            .WithOnly<string>()
            .Build();

        TestHelper.CheckDefaultExcept<string>(entity);
    }
    
    [Fact]
    public void Support_SetValue()
    {
        var expected = 1_000_000;
        
        var entity = TestDataBuilder
            .For<PublicWithAll>()
            .WithValue(p=>p.IntProp, expected)
            .Build();
        
        entity.IntProp.Should().Be(expected);
    }
}
