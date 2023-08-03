using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class CharTests
{
    [Fact]
    public void Support_char()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoChar>()
            .Build();
        
        subject.Prop.Should().NotBeNull();
        subject.Prop2.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_char_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoCharNullable>()
            .Build();

        subject.Prop.Should().NotBeNull();
        subject.Prop2.Should().NotBeNull();
        
        subject.Prop.Should().NotBe(default);
        subject.Prop2.Should().NotBe(default);
    }
}