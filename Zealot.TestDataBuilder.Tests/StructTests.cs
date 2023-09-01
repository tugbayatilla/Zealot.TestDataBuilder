using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class StructTests
{
    [Fact]
    public void Support_struct_as_property()
    {
        var subject = TestDataBuilder
            .For<ClassWithStructWithTwoString>()
            .Build();

        subject.Prop.Should().NotBeNull();
        subject.Prop.Prop.Should().MatchBuilderNamingRegex(nameof(subject.Prop.Prop));
        subject.Prop.PropNullable.Should().MatchBuilderNamingRegex(nameof(subject.Prop.PropNullable));
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
