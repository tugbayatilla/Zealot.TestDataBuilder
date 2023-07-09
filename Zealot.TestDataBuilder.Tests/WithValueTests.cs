using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class WithValueTests
{
    [Fact]
    public void WithValue_int_property()
    {
        const int expected = 1_000_000;

        var entity = TestDataBuilder
            .For<ClassWithTwoInteger>()
            .WithValue(e => e.Prop1 = expected)
            .Build();

        entity.Prop1.Should().Be(expected);
    }

    [Fact]
    public void WithValue_struct_property()
    {
        var entity = TestDataBuilder
            .For<ClassWithStructWithAllPrimitives>()
            .WithValue(p => p.Prop = new StructWithAllPrimitives() {BoolProp = true})
            .Build();

        entity.Prop.BoolProp.Should().BeTrue();
    }

    [Fact]
    public void WithValue_struct_property_of_property()
    {
        var entity = TestDataBuilder
            .For<ClassWithIntAndItselfRecursively>()
            .Build();

        entity.Prop.IntProp.Should().Be(2);
    }
    
    [Fact]
    public void WithValue_called_2_times()
    {
        var entity = TestDataBuilder
            .For<ClassWithAllPrimitives>()
            .WithValue(p=>p.IntProp = 1_000_000)
            .WithValue(p=>p.IntNullableProp = 2_000_000)
            .Build();

        entity.IntProp.Should().Be(1_000_000);
        entity.IntNullableProp.Should().Be(2_000_000);
    }
}