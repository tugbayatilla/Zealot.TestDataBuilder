namespace Zealot.Internals.Withs;

internal class With : IWith
{
    public IWithOnly Only { get; } = new WithOnly();
    public IWithRecursionLevel RecursionLevel { get; } = new WithRecursionLevel();
    public IWithNumber Number { get; } = new WithNumber();
    public IWithString String { get; } = new WithString();
    public IWithDate Date { get; } = new WithDate();
    public IWithGuid Guid { get; } = new WithGuid();
    public IWithLogger Log { get; } = new WithLog();
    public IWithOverride Override { get; } = new WithOverride();
    public IWithList List { get; } = new WithList();
}