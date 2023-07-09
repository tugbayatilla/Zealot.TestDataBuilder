using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class DatetimeTests
{
    [Fact]
    public void Support_datetime()
    {
        var now = DateTime.Now;
        var entity = TestDataBuilder
            .For<ClassWithTwoDatetime>()
            .WithDate(now)
            .Build();

        entity.Prop1.Should().Be(now);
    }
    
    [Fact]
    public void Support_datetime_is_close_to_now()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoDatetime>()
            .Build();

        entity.Prop1.Should().BeBefore(DateTime.UtcNow);
        entity.Prop1.Should().BeAfter(DateTime.UtcNow.AddSeconds(-10));
    }
    
    [Fact]
    public void Support_datetime_nullable()
    {
        var now = DateTime.Now;
        var entity = TestDataBuilder
            .For<ClassWithTwoDatetimeNullable>()
            .WithDate(now)
            .Build();

        entity.Prop1.Should().Be(now);
    }
}
