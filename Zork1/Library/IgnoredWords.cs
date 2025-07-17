using System.Diagnostics.CodeAnalysis;

namespace Zork1.Library;

/// <summary>
/// Words ignored by the parser
/// </summary>
[ExcludeFromCodeCoverage]
public static class IgnoredWords
{
    private static readonly List<string> ignored = [
       "", "a", "an", "and", "the", "then", "of"
    ];

    public static void Add(string word)
    {
        if (!ignored.Contains(word))
        {
            ignored.Add(word);
        }
    }

    public static bool Contains(string word)
    {
        return ignored.Contains(word);
    }
}
