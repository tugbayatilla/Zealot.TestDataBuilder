using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Zealot.Internals.Interfaces;

namespace Zealot.Internals.Withs;

internal class WithLog : IWithLogger
{
    public ILogger Logger { get; set; } = NullLogger.Instance;
}
