using System.Reflection;
using Zealot.Interfaces;
using Zealot.Internals;
using Zealot.SampleBuilder.Tests.Samples;
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
    public void IBuilder_WithValue()
    {
        const int expected = 1_000_000;
        
        var entity = TestDataBuilder
            .For<PublicWithAll>()
            .WithValue((e) => e.IntProp, expected)
            .Build();
        
        entity.IntProp.Should().Be(expected);
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
    
    // todo: create separate test file for WithValue
    // todo: add more scenario
    [Fact]
    public void IBuilder_WithValue_property_of_property()
    {
        var entity = TestDataBuilder
            .For<SimpleClassWithStruct>()
            .WithValue(p=>p.SimpleStruct.BoolProp, true)
            .Build();

        entity.SimpleStruct.BoolProp.Should().BeTrue();
    }
}

internal class NIntStrategy : Strategy
{
    public override Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        propertyInfo.SetValue(context.Entity, IntPtr.Parse("1"));
        return Task.CompletedTask;
    }

    public override IEnumerable<Type> AvailableTypes => new[] { typeof(IntPtr) };
}
