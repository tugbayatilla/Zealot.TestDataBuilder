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

        instance.Prop.Should().MatchRegex("Prop_[0-9]");
        instance.PropBase.Should().MatchRegex( "PropBase_[0-9]");
        instance.PropListBase.Count.Should().Be(2);
        instance.PropListBase[0].Should().MatchRegex("PropListBase_[0-9]");
        instance.PropListBase[1].Should().MatchRegex("PropListBase_[0-9]");
    }
}
