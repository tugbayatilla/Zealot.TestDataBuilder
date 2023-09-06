namespace Zealot.Tests;

public class PrimitivesTests
{
    [Fact]
    public void Support_string()
    {
        var entity = TestDataBuilder
            .For<string>()
            .Build();
        
        entity.Should().Be("");
    }
    
    [Fact]
    public void Support_multiple_strings()
    {
        var stringBuilder = TestDataBuilder
            .For<string>()
            .WithStringUniqueStartNumber(1);
        
        stringBuilder.Build().Should().Be("1");
        stringBuilder.Build().Should().Be("2");
    }
    
    [Fact]
    public void Support_int()
    {
        var entity = TestDataBuilder
            .For<int>()
            .Build();
        
        entity.Should().Be(1);
    }
    
    [Fact]
    public void Support_int_nullable()
    {
        var entity = TestDataBuilder
            .For<int?>()
            .Build();
        
        entity.Should().Be(1);
    }
    
    [Fact]
    public void Support_bool()
    {
        var entity = TestDataBuilder
            .For<bool>()
            .Build();
        
        entity.Should().Be(true);
    }
    
    [Fact]
    public void Support_datetime()
    {
        var entity = TestDataBuilder
            .For<DateTime>()
            .Build();
        
        entity.Should().BeAfter(DateTime.UtcNow.AddSeconds(-1));
    }
}
