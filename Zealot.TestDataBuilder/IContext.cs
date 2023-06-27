namespace Zealot;

public interface IContext
{
    object Entity { get; }
    IWithOnlyContainer WithOnlyContainer { get; }
}
