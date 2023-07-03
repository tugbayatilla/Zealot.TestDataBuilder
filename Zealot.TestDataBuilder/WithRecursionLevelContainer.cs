namespace Zealot;

internal class WithRecursionLevelContainer : IWithRecursionLevelContainer
{
    private int _allowedRecursionLevel;
    private readonly Dictionary<Type, int> _recursion = new();
    
    public bool CanContinueDeeper(Type type)
    {
        if (_recursion.TryGetValue(type, out var value))
        {
            return value < _allowedRecursionLevel;
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

    public void SetAllowedRecursionLevel(int allowedRecursionLevel)
    {
        _allowedRecursionLevel = allowedRecursionLevel;
    }
}