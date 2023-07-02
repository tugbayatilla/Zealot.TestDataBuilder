using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class DatetimeTests
{
    [Fact]
    public void Support_datetime()
    {
        var now = DateTime.Now;
        var entity = TestDataBuilder
            .For<PublicDatetime>()
            .WithDate(now)
            .Build();

        entity.DateTimeProp.Should().Be(now);
    }
}
