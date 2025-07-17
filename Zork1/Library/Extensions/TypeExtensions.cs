using System.Reflection;

namespace Zork1.Library.Extensions;

public static class TypeExtensions
{
    public static IList<Type> GetObjectTypes(this Assembly ax)
    {
        return ax.GetTypes().Where(t => t.IsObject()).ToList();
    }

    private static bool IsObject(this Type type)
    {
        return type.IsSubclassOf(typeof(Object)) && type.IsPublic && !type.IsAbstract;
    }
}
