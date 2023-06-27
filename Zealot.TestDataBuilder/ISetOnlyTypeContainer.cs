namespace Zealot;

public interface ISetOnlyTypeContainer
{
    void Add(Type type);
    IEnumerable<Type> List();
    
    bool IsMemberOfSetOnly(Type type);
}