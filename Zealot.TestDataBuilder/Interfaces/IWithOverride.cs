namespace Zealot.Interfaces;

public interface IWithOverride
{
    void Add(Action<object> overrideAction);
    void Apply(object entity);
}
