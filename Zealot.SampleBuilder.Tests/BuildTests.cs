namespace Zealot.SampleBuilder.Tests;

public class BuildTests
{
    [Fact]
    public void Creates_new_instance_of_given_type()
    {
        var instanceOfStringClass = SampleBuilder<StringClass>
            .Build();

        instanceOfStringClass.Should().NotBeNull();
    }
}