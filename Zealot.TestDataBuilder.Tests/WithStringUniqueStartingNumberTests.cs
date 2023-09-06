using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class WithStringUniqueStartingNumberTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    public void Support_changing_string_unique_number(int uniqueStartingNumber)
    {
        var instance = TestDataBuilder
            .For<ClassWithTwoString>()
            .WithStringUniqueStartingNumber(uniqueStartingNumber)
            .Build();
        
        instance.Should().NotBeNull();
        instance.Prop1.Should().Be($"{TestDataBuilder.DefaultStringBodyTemplate}{uniqueStartingNumber}");
        instance.Prop2.Should().Be($"{TestDataBuilder.DefaultStringBodyTemplate}{uniqueStartingNumber+1}");
    }
}
