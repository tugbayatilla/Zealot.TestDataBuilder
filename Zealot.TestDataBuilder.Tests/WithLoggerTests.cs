using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

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
        var logger = new TestLogger();
        
        _ = TestDataBuilder
            .For<ClassWithTwoInteger>()
            .WithLogger(logger)
            .Build();

        logger.NumberOfExecution.Should().Be(1);
        logger.Message.Should().Be($"Build for {nameof(ClassWithTwoInteger)} starts");
    }
}
