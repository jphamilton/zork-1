using Zork1.Library.Extensions;

namespace Zork1.Library;

public static class Display
{
    public static string List(IEnumerable<Object> objects, bool definiteArticle = false, string concat = "and")
    {
        string article(Object x) => definiteArticle ? x.DArticle : x.IArticle;
        var list = objects.Select(x => $"{article(x)} {x.Name}").ToList();
        return list.Join(concat);
    }
}
