using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class ByteTests
{
    [Fact]
    public void Support_byte()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .WithOnly<byte>()
            .Build();
        
        subject.ByteProp.Should().NotBe(default);
        subject.ByteProp2.Should().NotBe(default);
    }
    
    [Fact]
    public void Support_byte_nullable()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .WithOnly<byte?>()
            .Build();
        
        subject.ByteNullableProp.Should().NotBeNull();
        subject.ByteNullableProp2.Should().NotBeNull();
        
        subject.ByteNullableProp.Should().NotBe(default);
        subject.ByteNullableProp2.Should().NotBe(default);
    }
}
