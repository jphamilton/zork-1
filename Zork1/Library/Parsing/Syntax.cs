namespace Zork1.Library.Parsing;

public static class Syntax
{
    private static SyntaxDefinitons _syntax;

    public static void Load<T>() where T : SyntaxBase, new()
    {
        _syntax = new T().Load();
    }
}
