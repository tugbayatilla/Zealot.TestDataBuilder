using Zealot.Interfaces;
using Zealot.Internals;
using Zealot.SampleBuilder.Tests.TestObjects;
using Zealot.Strategies;

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
    public void IWithOnlyContainer_Exist_with_IReadOnlyDictionary()
    {
        IWithOnly container = new WithOnly();
        container.Add(typeof(IReadOnlyDictionary<,>));

        container
            .Exist(typeof(IReadOnlyDictionary<string, int>))
            .Should()
            .BeTrue();
    }
    
    [Fact]
    public void IWithOnlyContainer_Exist_with_NullableDouble()
    {
        IWithOnly container = new WithOnly();
        container.Add(typeof(double?));

        container
            .Exist(typeof(int?))
            .Should()
            .BeFalse();
    }
    
    [Fact]
    public void IBuilder_WithStrategy_Unsupported()
    {
        Assert.Throws<NotSupportedException>(() =>
        {
             TestDataBuilder
                .For<PublicNInt>()
                .Build();
        });
        
        var entity = TestDataBuilder
            .For<PublicNInt>()
            .WithStrategy(new NIntStrategy())
            .Build();

        entity.NIntProp.Should().Be(1);

    }
    
    
}

internal class NIntStrategy : Strategy
{
    public override IEnumerable<Type> AvailableTypes => new[] { typeof(IntPtr) };
    public override object GenerateValue(IContext context, Type type)
    {
        return IntPtr.Parse("1");
    }
}
