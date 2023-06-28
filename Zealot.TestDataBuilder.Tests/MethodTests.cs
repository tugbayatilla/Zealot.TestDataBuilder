using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class MethodTests
{
    [Fact]
    public void IBuilder_WithOnly()
    {
        var entity = TestDataBuilder
            .For<PublicWithAll>()
            .WithOnly<string>()
            .Build();

        TestHelper.CheckDefaultExcept<string>(entity);
    }
    
    [Fact]
    public void IBuilder_WithValue()
    {
        const int expected = 1_000_000;
        
        var entity = TestDataBuilder
            .For<PublicWithAll>()
            .WithValue(p=>p.IntProp, expected)
            .Build();
        
        entity.IntProp.Should().Be(expected);
    }
    
    [Fact]
    public void IWithOnlyContainer_Exist_with_IReadOnlyDictionary()
    {
        IWithOnlyContainer container = new WithOnlyContainer();
        container.Add(typeof(IReadOnlyDictionary<,>));

        container
            .Exist(typeof(IReadOnlyDictionary<string, int>))
            .Should()
            .BeTrue();
    }
    
    [Fact]
    public void IWithOnlyContainer_Exist_with_NullableDouble()
    {
        IWithOnlyContainer container = new WithOnlyContainer();
        container.Add(typeof(double?));

        container
            .Exist(typeof(int?))
            .Should()
            .BeFalse();
    }
}
