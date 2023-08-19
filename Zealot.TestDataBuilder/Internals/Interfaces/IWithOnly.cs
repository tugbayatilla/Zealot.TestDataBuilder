namespace Zealot.Internals.Interfaces;

internal interface IWithOnly
{
    void Add(Type type);

    bool Exist(Type type);

    bool IgnoreThis(Type ignoreType);
}
