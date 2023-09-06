using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class WithStringUniqueNumberTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    public void Support_changing_string_unique_number(int uniqueStartingNumber)
    {
        var instance = TestDataBuilder
            .For<ClassWithTwoString>()
            .WithStringSeparator("_")
            .WithStringUniqueStartNumber(uniqueStartingNumber)
            .Build();
        
        instance.Should().NotBeNull();
        instance.Prop1.Should().Be($"{nameof(instance.Prop1)}_{uniqueStartingNumber}");
        instance.Prop2.Should().Be($"{nameof(instance.Prop2)}_{uniqueStartingNumber+1}");
    }
}
