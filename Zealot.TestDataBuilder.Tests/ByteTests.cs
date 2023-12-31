using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class ByteTests
{
    [Fact]
    public void Support_byte()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoByte>()
            .Build();
        
        subject.Prop1.Should().NotBe(default);
        subject.Prop2.Should().NotBe(default);
    }
    
    [Fact]
    public void Support_byte_nullable()
    {
        var subject = TestDataBuilder
            .For<ClassWithTwoByteNullable>()
            .WithOnly<byte?>()
            .Build();
        
        subject.Prop.Should().NotBeNull();
        subject.Prop2.Should().NotBeNull();
        
        subject.Prop.Should().NotBe(default);
        subject.Prop2.Should().NotBe(default);
    }
}
