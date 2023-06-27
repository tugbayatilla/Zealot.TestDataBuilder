using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class CharTests
{
    [Fact]
    public void Support_char()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .SetOnly<char>()
            .Build();
        
        subject.CharProp.Should().NotBeNull();
        subject.CharProp2.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_char_nullable()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .SetOnly<char?>()
            .Build();

        subject.CharNullableProp.Should().NotBeNull();
        subject.CharNullableProp2.Should().NotBeNull();
        
        subject.CharNullableProp.Should().NotBe(default);
        subject.CharNullableProp2.Should().NotBe(default);
    }
}