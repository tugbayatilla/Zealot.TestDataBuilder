namespace Zealot.Interfaces;

public interface IWith
{
    IWithOnly Only { get; }
    IWithRecursionLevel RecursionLevel { get; }
    IWithNumber Number { get; }
    IWithString String { get; }
    IWithDate Date { get; }
    IWithGuid Guid { get; }
    IWithLogger Log { get; set; }
}