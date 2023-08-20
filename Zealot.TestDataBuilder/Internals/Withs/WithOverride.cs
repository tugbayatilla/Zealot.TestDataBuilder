namespace Zealot.Internals.Withs;

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
