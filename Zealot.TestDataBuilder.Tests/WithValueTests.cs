using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class WithValueTests
{
    [Fact]
    public void WithValue_int_property()
    {
        const int expected = 1_000_000;

        var entity = TestDataBuilder
            .For<IntPropertyClass>()
            .WithValue(e => e.IntProp = expected)
            .Build();

        entity.IntProp.Should().Be(expected);
    }

    [Fact]
    public void WithValue_struct_property()
    {
        var entity = TestDataBuilder
            .For<AllPrimitivesStructClass>()
            .WithValue(p => p.AllPrimitivesStructProp = new AllPrimitivesStruct() {BoolProp = true})
            .Build();

        entity.AllPrimitivesStructProp.BoolProp.Should().BeTrue();
    }

    [Fact]
    public void WithValue_struct_property_of_property()
    {
        var entity = TestDataBuilder
            .For<RecursiveItselfClass>()
            .Build();

        entity.RecursiveItselfProp.intProp.Should().Be(2);
    }
    //todo: support struct in For
    [Fact]
    public void WithValue_called_2_times()
    {
        var entity = TestDataBuilder
            .For<AllPrimitivesClass>()
            .WithValue(p=>p.IntProp = 1_000_000)
            .WithValue(p=>p.IntNullableProp = 2_000_000)
            .Build();

        entity.IntProp.Should().Be(1_000_000);
        entity.IntNullableProp.Should().Be(2_000_000);
    }
}