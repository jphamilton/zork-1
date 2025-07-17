using System.Diagnostics.CodeAnalysis;

namespace Zork1.Library;

/// <summary>
/// Words that are replaced during parsing. Used to normalize input.
/// </summary>
[ExcludeFromCodeCoverage]
public static class ReplacedWords
{
    private static Dictionary<string, string> _replaced = [];

    public static void Load()
    {
        _replaced = new() {
            {"everything", "all"},
            {"each", "all"},
            {"every", "all"},
            {"both", "all"},
            {"but", "except"},
            {"n", "north"},
            {"s", "south"},
            {"e" , "east"},
            {"w" , "west"},
            {"d" , "down"},
            {"u" , "up"},
            {"nw" , "northwest"},
            {"ne" , "northeast"},
            {"sw" , "southwest"},
            {"se" , "southeast"},
        };
    }

    public static string Get(string word)
    {
        return _replaced.TryGetValue(word, out var value) ? value : word;
    }

    public static void Add(string synonym, string word)
    {
        _replaced.Add(synonym, word);
    }

    public static bool Contains(string word)
    {
        return _replaced.ContainsKey(word);
    }
}

public class Synonyms
{
    public Synonyms Add(string synonyms, string word)
    {
        foreach (var synonym in synonyms.Split("/").ToList())
        {
            ReplacedWords.Add(synonym, word);
        }

        return this;
    }

    public static Synonyms Begin()
    {
        ReplacedWords.Load();
        return new Synonyms();
    }

    public void End()
    {
    }
}