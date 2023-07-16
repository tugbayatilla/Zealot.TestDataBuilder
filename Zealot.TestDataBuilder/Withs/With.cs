using System.Reflection;
using Zealot.Interfaces;
using Zealot.Internals;

namespace Zealot.Withs;

internal class With : IWith
{
    public IWithOnly Only { get; } = new WithOnly();
    public IWithRecursionLevel RecursionLevel { get; } = new WithRecursionLevel();
    public IWithNumber Number { get; } = new WithNumber();
    public IWithString String { get; } = new WithString();
    public IWithDate Date { get; } = new WithDate();
    public IWithGuid Guid { get; } = new WithGuid();
    public IWithLogger Log { get; set; } = new WithLog();
    public IWithOverride Override { get; set; } = new WithOverride();
}

internal class WithOverride : IWithOverride
{
    private readonly List<Action<object>> _overrideActions = new();

    public void Add(Action<object> overrideAction)
    {
        _overrideActions.Add(overrideAction);
    }

    public void Apply(object entity)
    {
        _overrideActions.ForEach(p=>
        {
            if (p.Method.ReflectedType != null && p.Method.ReflectedType.GenericTypeArguments.Contains(entity.GetType()))
            {
                p.Invoke(entity);
            }
        });
    }
}