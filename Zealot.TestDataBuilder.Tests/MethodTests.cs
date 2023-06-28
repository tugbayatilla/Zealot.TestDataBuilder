using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class MethodTests
{
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
        const int expected = 1_000_000;
        
        var entity = TestDataBuilder
            .For<PublicWithAll>()
            .WithValue(p=>p.IntProp, expected)
            .Build();
        
        entity.IntProp.Should().Be(expected);
    }
}
