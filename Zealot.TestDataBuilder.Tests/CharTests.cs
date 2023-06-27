using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class CharTests
{
    [Fact]
    public void Support_char()
    {
        var subject = TestDataBuilder.For<PublicWithTwoChar>().Build();
        subject.CharProp.Should().NotBeNull();
        subject.CharProp2.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_char_nullable()
    {
        var subject = TestDataBuilder.For<PublicWithTwoCharNullable>().Build();
        subject.CharProp.Should().NotBeNull();
        subject.CharProp2.Should().NotBeNull();
    }
}
