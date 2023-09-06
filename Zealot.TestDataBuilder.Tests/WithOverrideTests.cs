using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

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
        const string alteredText = "AlteredText";
        var entity = TestDataBuilder
            .For<ClassWithStructWithTwoString>()
            .WithOverride(p 
                => p.Prop = p.Prop with {PropNullable = alteredText})
            .Build();
        
        entity.Prop.Prop.Should().MatchBuilderNamingRegex();
        entity.Prop.PropNullable.Should().Be(alteredText);
    }

    [Fact]
    public void Change_struct_property_of_property()
    {
        var entity = TestDataBuilder
            .For<ClassWithIntAndItselfRecursively>()
            .WithRecursionLevel(1)
            .Build();

        entity.Prop.IntProp.Should().Be(2);
    }

    [Fact]
    public void Change_called_2_times()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoInteger>()
            .WithOverride(p => p.Prop1 = 1_000_000)
            .WithOverride(p => p.Prop2 = 2_000_000)
            .Build();

        entity.Prop1.Should().Be(1_000_000);
        entity.Prop2.Should().Be(2_000_000);
    }
}