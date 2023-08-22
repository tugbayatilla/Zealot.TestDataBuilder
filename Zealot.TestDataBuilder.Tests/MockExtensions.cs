using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Moq;

namespace Zealot.Tests;

public static class MockExtensions
{
    public static void VerifyDebug(this Mock<ILogger> loggerMock, string message, Times times)
    {
        VerifyLog(loggerMock, 
            LogLevel.Debug, 
            message, 
            e => e == It.IsAny<Exception>(),  
            times);
    }

    private static void VerifyLog(this Mock<ILogger> loggerMock, LogLevel logLevel, string message,
        Expression<Func<Exception, bool>> exceptionMatch, Times times)
    {
        loggerMock.Verify(
            x => x.Log(
                It.Is<LogLevel>(l => l == logLevel),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains(message)),
                It.Is(exceptionMatch),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)!
            ), times);
    }
}
