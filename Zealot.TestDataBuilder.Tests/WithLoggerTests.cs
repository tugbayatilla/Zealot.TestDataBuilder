using Microsoft.Extensions.Logging;
using Moq;
using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class WithLoggerTests
{
    [Fact]
    public void Null_value_will_be_ignored()
    {
        var entity = TestDataBuilder
            .For<ClassWithTwoInteger>()
            .WithLogger(null!)
            .Build();

        entity.Should().NotBeNull();
    }

    [Fact]
    public void Debug_log_on_build_start()
    {
        var loggerMock = new Mock<ILogger>();
        
        _ = TestDataBuilder
            .For<ClassWithTwoInteger>()
            .WithLogger(loggerMock.Object)
            .Build();

        loggerMock.VerifyDebug($"Build for {nameof(ClassWithTwoInteger)} starts", Times.Once());
    }
}
