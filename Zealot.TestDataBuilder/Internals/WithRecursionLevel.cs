using Zealot.Interfaces;

namespace Zealot.Internals;

internal class WithRecursionLevel : IWithRecursionLevel
{
    private int _allowedRecursionLevel;

    public bool CanContinueDeeper(IContext context, Type type)
    {
        var (exist, level) = RecursionExist(context, type);
        if (exist)
        {
            return level[type] <= _allowedRecursionLevel;
        }

        return true;
    }

    private (bool exist, Dictionary<Type, int> level) RecursionExist(IContext context, Type type)
    {
        Dictionary<Type, int> level = new Dictionary<Type, int>();
        var exist = false;
        while (true)
        {
            // no parent, no recursion
            if (context.Parent == null) return (exist, level);
            
            // parent has same type, recursion
            if (context.Parent.Entity.GetType() == type)
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

            context = context.Parent;
        }
    }

    public void SetAllowedRecursionLevel(int allowedRecursionLevel)
    {
        _allowedRecursionLevel = allowedRecursionLevel;
    }
}
