namespace Zealot.SampleBuilder.Tests;

public class PrimitivesTests
{
    [Fact]
    public void Support_string()
    {
        var entity = TestDataBuilder
            .For<string>()
            .Build();
        
        entity.Should().Be("_1");
    }
    
    [Fact]
    public void Support_multiple_strings()
    {
        var stringBuilder = TestDataBuilder
            .For<string>();
        
        stringBuilder.Build().Should().Be("_1");
        stringBuilder.Build().Should().Be("_2");
    }
    
    [Fact]
    public void Support_int()
    {
        var entity = TestDataBuilder
            .For<int>()
            .Build();
        
        entity.Should().Be(1);
    }
}
