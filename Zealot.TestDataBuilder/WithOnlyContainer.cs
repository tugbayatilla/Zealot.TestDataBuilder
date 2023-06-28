namespace Zealot;

internal class WithOnlyContainer : IWithOnlyContainer
{
    private readonly IList<Type> _list = new List<Type>();

    public void Add(Type type)
    {
        if (_list.All(p => p != type))
        {
            _list.Add(type);
        }
    }

    public IEnumerable<Type> List()
    {
        return _list.AsEnumerable();
    }

    public bool Exist(Type type) => _list.Any(p => p.IsSame(type));

    public bool HasSomething => _list.Any();
    public bool IgnoreThis(Type ignoreType) => HasSomething && !Exist(ignoreType);
}