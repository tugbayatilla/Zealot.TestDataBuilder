using Microsoft.Extensions.Logging;

namespace Zealot.Interfaces;

public interface IWithLogger
{
    public ILogger Logger { get; set; }
}