using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class ByteTests
{
    [Fact]
    public void Support_byte()
    {
        var subject = TestDataBuilder.For<PublicWithTwoByte>().Build();
        subject.ByteProp.Should().NotBe(default);
        subject.ByteProp2.Should().NotBe(default);
    }
}
