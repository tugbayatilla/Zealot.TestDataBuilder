using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Zealot.Interfaces;

namespace Zealot.Withs;

internal class WithLog : IWithLogger
{
    public ILogger Logger { get; set; } = NullLogger.Instance;
}
