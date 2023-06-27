namespace Zealot;

public class Context : IContext
{
    public Context(object entity, ISetOnlyTypeContainer setOnlyTypeContainer)
    {
        Entity = entity;
        SetOnlyTypeContainer = setOnlyTypeContainer;
    }

    public object Entity { get; }
    public ISetOnlyTypeContainer SetOnlyTypeContainer { get; }
}