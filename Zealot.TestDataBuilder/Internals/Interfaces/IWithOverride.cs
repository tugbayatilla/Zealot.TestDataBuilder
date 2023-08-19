namespace Zealot.Internals.Interfaces;

internal interface IWithOverride
{
    void Add(Action<object> overrideAction);
    void Apply(object entity);
}
