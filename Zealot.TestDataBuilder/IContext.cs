namespace Zealot;

public interface IContext
{
    object Entity { get; }
    IWithOnlyContainer WithOnlyContainer { get; }
    DateTime WithUtcDate { get; set; }
}
