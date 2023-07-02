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
    
    [Fact]
    public void Support_datetime_is_close_to_now()
    {
        var entity = TestDataBuilder
            .For<PublicDatetime>()
            .Build();

        entity.DateTimeProp.Should().BeBefore(DateTime.UtcNow);
        entity.DateTimeProp.Should().BeAfter(DateTime.UtcNow.AddSeconds(-10));
    }
    
    [Fact]
    public void Support_datetime_nullable()
    {
        var now = DateTime.Now;
        var entity = TestDataBuilder
            .For<PublicDatetimeNullable>()
            .WithDate(now)
            .Build();

        entity.DateTimeNullableProp.Should().Be(now);
    }
}
