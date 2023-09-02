using Microsoft.Extensions.Logging;

namespace Zealot.Tests;

internal class TestLogger : ILogger
{
    public int NumberOfExecution { get; private set; }
    public string Message { get; private set; }
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        ++NumberOfExecution;
        Message = state!.ToString()!;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return default;
    }
}
