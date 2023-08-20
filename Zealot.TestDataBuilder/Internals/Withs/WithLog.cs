using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Zealot.Internals.Withs;

internal class WithLog : IWithLogger
{
    public ILogger Logger { get; set; } = NullLogger.Instance;
}
