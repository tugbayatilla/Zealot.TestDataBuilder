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

        instance.Prop.Should().MatchBuilderNamingRegex();
        instance.PropBase.Should().MatchBuilderNamingRegex();
        instance.PropListBase.Count.Should().Be(2);
        instance.PropListBase[0].Should().MatchBuilderNamingRegex();
        instance.PropListBase[1].Should().MatchBuilderNamingRegex();
    }
    
    [Fact]
    public void Support_setting_base_class_properties_having_setter()
    {
        var now = DateTime.Now;
        var sample = TestDataBuilder
            .For<ClassWithOneDateTimeAndInheritingClassWithTwoInteger>()
            .WithDate(now)
            .Build();

        sample.Should().NotBeNull();
        sample.DateTimeProperty.Should().Be(now);
        sample.Prop1.Should().Be(1);
        sample.Prop2.Should().Be(2);
    }
}
