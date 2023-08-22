using System.Reflection;

namespace Zealot.Internals;

internal static class Instance
{
    private delegate T ObjectActivator<out T>(params object[] args);

    public static object? Create(Type type)
    {
        object? instance = null!;
        if (type.ContainsGenericParameters)
        {
            type = type.MakeGenericType(type.GenericTypeArguments);
        }

        var constructorArguments = new List<object>();
        var ctorInfo = type.GetConstructors().FirstOrDefault();
        if (ctorInfo != null)
        {
            var ctorParametersInfo = ctorInfo.GetParameters();
            var parameters = ctorParametersInfo.Select(info => info.ParameterType.IsClass
                ? Create(info.ParameterType)
                : info.ParameterType.GetDefault());
            constructorArguments.AddRange(parameters!);

            var createdActivator = GetActivator<object>(ctorInfo);
            instance = createdActivator(constructorArguments.ToArray());
        }
        
        if (type.IsStruct())
        {
            instance = Activator.CreateInstance(type);
        }

        if (type.IsValueType)
        {
            instance = Activator.CreateInstance(type);
        }

        return instance;
    }

    private static ObjectActivator<T> GetActivator<T>(ConstructorInfo ctor)
    {
        var paramsInfo = ctor.GetParameters();
        var param = Expression.Parameter(typeof(object[]), "args");

        var argsExp = new Expression[paramsInfo.Length];

        for (var i = 0; i < paramsInfo.Length; i++)
        {
            Expression index = Expression.Constant(i);
            var paramType = paramsInfo[i].ParameterType;

            Expression paramAccessorExp = Expression.ArrayIndex(param, index);
            Expression paramCastExp = Expression.Convert(paramAccessorExp, paramType);

            argsExp[i] = paramCastExp;
        }

        var newExp = Expression.New(ctor, argsExp);
        var lambda = Expression.Lambda(typeof(ObjectActivator<T>), newExp, param);

        var compiled = (ObjectActivator<T>) lambda.Compile();
        return compiled;
    }
}
