namespace Zealot;

public interface ISetOnlyTypeContainer
{
    void Add(Type type);
    IEnumerable<Type> List();
    
    bool Exist(Type type);
    bool HasNothing { get; }
}