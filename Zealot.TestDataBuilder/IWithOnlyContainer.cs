using System.Reflection;

namespace Zealot;

public interface IWithOnlyContainer
{
    void Add(Type type);
    IEnumerable<Type> List();
    
    bool Exist(Type type);
    bool HasSomething { get; }

    bool IgnoreThis(Type ignoreType);
}