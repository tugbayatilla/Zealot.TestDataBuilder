namespace Zealot;

public class Context : IContext
{
    public Context(object entity)
    {
        Entity = entity;
    }

    public object Entity { get; }
}