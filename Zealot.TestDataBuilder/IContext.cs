namespace Zealot;

public interface IContext
{
    object Entity { get; }
    ISetOnlyTypeContainer SetOnlyTypeContainer { get; }
}
