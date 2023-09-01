using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class StructTests
{
    [Fact]
    public void Support_struct_as_property()
    {
        var subject = TestDataBuilder
            .For<ClassWithStructWithAllPrimitives>()
            .Build();

        subject.Prop.Should().NotBeNull();
        subject.Prop.BoolProp.Should().BeTrue();
        subject.Prop.StringProp.Should().MatchBuilderNamingRegex(nameof(subject.Prop.StringProp));
    }
    
    [Fact]
    public void Support_struct_directly()
    {
        var subject = TestDataBuilder
            .For<StructWithAllPrimitives>()
            .Build();

        subject.Should().NotBeNull();
        subject.IntProp.Should().Be(1);
    }
    
    [Fact]
    public void Support_struct_recursion()
    {
        var subject = TestDataBuilder
            .For<StructWithIntAndItselfRecursively>()
            .WithRecursionLevel(1)
            .Build();

        subject.Should().NotBeNull();
        subject.Prop.IntProp.Should().Be(2);
    }
}
