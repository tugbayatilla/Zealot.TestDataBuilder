namespace Zealot.Internals.Withs;

internal class SetValue<T>
{
    public bool IsSet { get; private set; }
    public T Value { get; private set; } = default!;

    public void Set(T value)
    {
        Value = value;
        IsSet = true;
    }

    public void Reset()
    {
        IsSet = false;
        Value = default!;
    }
}
