using Microsoft.Extensions.Logging;

namespace Zealot.Internals.Interfaces;

internal interface IWithLogger
{
    public ILogger Logger { get; set; }
}
