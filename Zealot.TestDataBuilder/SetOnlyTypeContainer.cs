namespace Zealot;

internal class SetOnlyTypeContainer : ISetOnlyTypeContainer
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

    public bool Exist(Type type) => _list.Any(p => p == type && p.IsNullable() == type.IsNullable());

    public bool HasNothing => !_list.Any();
}
