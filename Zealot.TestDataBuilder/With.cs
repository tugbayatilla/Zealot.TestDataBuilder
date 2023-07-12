using Microsoft.Extensions.Logging;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot;

internal class With : IWith
{
    public IWithOnly Only { get; } = new WithOnly();
    public IWithRecursionLevel RecursionLevel { get; } = new WithRecursionLevel();
    public IWithNumber Number { get; } = new WithNumber();
    public IWithString String { get; } = new WithString();
    public IWithDate Date { get; } = new WithDate();
    public IWithGuid Guid { get; } = new WithGuid();
    public IWithLogger Log { get; set; } = new WithLog();
}

internal class WithLog : IWithLogger
{
    public ILogger Logger { get; set; } = default!;
}