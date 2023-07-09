using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class StructTests
{
    [Fact]
    public void Support_struct_as_property()
    {
        var subject = TestDataBuilder
            .For<AllPrimitivesStructClass>()
            .Build();

        subject.AllPrimitivesStructProp.Should().NotBeNull();
        subject.AllPrimitivesStructProp.BoolProp.Should().BeFalse();
        subject.AllPrimitivesStructProp.StringProp.Should().Be(nameof(subject.AllPrimitivesStructProp.StringProp));
    }
    
    [Fact]
    public void Support_struct_directly()
    {
        var subject = TestDataBuilder
            .For<AllPrimitivesStruct>()
            .Build();

        subject.Should().NotBeNull();
        subject.IntProp.Should().Be(1);
    }
}
