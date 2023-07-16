using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class WithOverrideTests
{
    [Fact]
    public void Change_int_property()
    {
        const int expected = 1_000_000;

        var entity = TestDataBuilder
            .For<ClassWithTwoInteger>()
            .WithOverride(e => e.Prop1 = expected)
            .Build();

        entity.Prop1.Should().Be(expected);
    }

    [Fact]
    public void Change_struct_property()
    {
        var entity = TestDataBuilder
            .For<ClassWithStructWithAllPrimitives>()
            .WithOverride(p => p.Prop = new StructWithAllPrimitives {BoolProp = true})
            .Build();

        
        entity.Prop.BoolProp.Should().BeTrue();
    }

    [Fact]
    public void Change_struct_property_of_property()
    {
        var entity = TestDataBuilder
            .For<ClassWithIntAndItselfRecursively>()
            .Build();

        entity.Prop.IntProp.Should().Be(2);
    }

    [Fact]
    public void Change_called_2_times()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllPrimitives>()
            .WithOverride(p => p.IntProp = 1_000_000)
            .WithOverride(p => p.IntNullableProp = 2_000_000)
            .Build();

        entity.IntProp.Should().Be(1_000_000);
        entity.IntNullableProp.Should().Be(2_000_000);
    }
}