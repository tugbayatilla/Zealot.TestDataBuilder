namespace Zealot.Internals;

internal class WithOnly : IWithOnly
{
    private readonly IList<Type> _list = new List<Type>();

    public void Add(Type type)
    {
        if (_list.All(p => p != type))
        {
            _list.Add(type);
        }
    }
    
    public bool Exist(Type type) => _list.Any(p => p.IsSame(type));
    public bool IgnoreThis(Type ignoreType) => HasSomething && !Exist(ignoreType);
    private bool HasSomething => _list.Any();
}
