namespace Zealot.Internals;

internal class WithRecursionLevel : IWithRecursionLevel
{
    private int _allowedRecursionLevel;

    public bool CanContinueDeeper(IContext context, Type type)
    {
        var (exist, level) = RecursionExist(context.Scope, type);
        if (exist)
        {
            return level[type] <= _allowedRecursionLevel;
        }

        return true;
    }

    private (bool exist, Dictionary<Type, int> level) RecursionExist(Scope scope, Type type)
    {
        Dictionary<Type, int> level = new Dictionary<Type, int>();
        var exist = false;
        while (true)
        {
            // no parent, no recursion
            if (scope.Parent == null) return (exist, level);
            
            // parent has same type, recursion
            if (scope.Parent.Entity?.GetType() == type)
            {
                exist = true;
                if(level.ContainsKey(type))
                {
                    level[type] += 1;
                }
                else
                {
                    level.Add(type, 1);
                }
            }

            scope = scope.Parent;
        }
    }

    public void SetAllowedRecursionLevel(int allowedRecursionLevel)
    {
        _allowedRecursionLevel = allowedRecursionLevel;
    }
}
