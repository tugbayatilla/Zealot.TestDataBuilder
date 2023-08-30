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

        instance.Prop.Should().MatchRegex("BaseStringProp_[0-9]");
        instance.PropBase.Should().MatchRegex( "StringProp1_[0-9]");
        instance.PropListBase.Count.Should().Be(2);
        instance.PropListBase[0].Should().MatchRegex("ListOfStringProp_[0-9]");
        instance.PropListBase[1].Should().MatchRegex("ListOfStringProp_[0-9]");
    }
}
