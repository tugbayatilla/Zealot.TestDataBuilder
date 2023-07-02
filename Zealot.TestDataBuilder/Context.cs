namespace Zealot;

internal class Context : IContext
{
    public Context(object entity, IWithOnlyContainer withOnlyContainer)
    {
        Entity = entity;
        WithOnlyContainer = withOnlyContainer;
    }

    public object Entity { get; }
    public IWithOnlyContainer WithOnlyContainer { get; }
    public DateTime WithUtcDate { get; set; } = DateTime.UtcNow;
}