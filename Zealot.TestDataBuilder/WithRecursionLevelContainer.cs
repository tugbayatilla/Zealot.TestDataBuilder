namespace Zealot;

internal class WithRecursionLevelContainer : IWithRecursionLevelContainer
{
    private readonly Dictionary<Type, int> _recursion = new();
    public bool CanContinueDeeper(Type type)
    {
        const int defaultRecursionLevel = 0;

        if (_recursion.TryGetValue(type, out var value))
        {
            return value > defaultRecursionLevel;
        }

        return true;
    }

    public void Register(Type type)
    {
        if (_recursion.ContainsKey(type))
        {
            _recursion[type] += 1;
        }
        else
        {
            _recursion.Add(type, 0);
        }
    }
}