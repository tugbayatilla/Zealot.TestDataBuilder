namespace Zealot.SampleBuilder.Tests;

public class StructTests
{
    [Fact]
    public void Support_struct()
    {
        var subject = TestDataBuilder
            .For<Samples.SimpleClassWithStruct>()
            .Build();

        subject.SimpleStruct.Should().NotBeNull();
        subject.SimpleStruct.BoolProp.Should().BeFalse();
        subject.SimpleStruct.StringProp.Should().Be(nameof(subject.SimpleStruct.StringProp));
    }
}
