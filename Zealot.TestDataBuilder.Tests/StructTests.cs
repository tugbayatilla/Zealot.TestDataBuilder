using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class StructTests
{
    [Fact]
    public void Support_struct()
    {
        var subject = TestDataBuilder
            .For<AllPrimitivesStructClass>()
            .Build();

        subject.AllPrimitivesStructProp.Should().NotBeNull();
        subject.AllPrimitivesStructProp.BoolProp.Should().BeFalse();
        subject.AllPrimitivesStructProp.StringProp.Should().Be(nameof(subject.AllPrimitivesStructProp.StringProp));
    }
}
