using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class InheritanceTests
{
    [Fact]
    public void Support_inheritance()
    {
        var instance = TestDataBuilder
            .For<ClassWithInheritance>()
            .Build();

        instance.Prop.Should().MatchBuilderNamingRegex(nameof(instance.Prop));
        instance.PropBase.Should().MatchBuilderNamingRegex(nameof(instance.PropBase));
        instance.PropListBase.Count.Should().Be(2);
        instance.PropListBase[0].Should().MatchBuilderNamingRegex(nameof(instance.PropListBase));
        instance.PropListBase[1].Should().MatchBuilderNamingRegex(nameof(instance.PropListBase));
    }
}
