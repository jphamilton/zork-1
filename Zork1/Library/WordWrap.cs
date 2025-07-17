using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Zork1.Library;

public interface IOutputFormatter
{
    string Format(string text);
}

[ExcludeFromCodeCoverage]
public class WordWrap : IOutputFormatter
{
    private readonly int _columns;

    public WordWrap(int columns)
    {
        _columns = columns;
    }

    public string Format(string text)
    {
        text = text.Replace("~", "\"");
        text = text.Replace("^", Environment.NewLine);

        return WrapText(text);
    }

    private string WrapText(string text)
    {
        var lines = text.Split(Environment.NewLine);
        var sb = new StringBuilder();

        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                sb.AppendLine();
                continue;
            }

            var words = line.Split(' ');
            int charsInLine = 0;

            foreach (var word in words)
            {
                if (charsInLine + word.Length >= _columns)
                {
                    sb.AppendLine();
                    charsInLine = 0;
                }

                if (charsInLine > 0 || word == "")
                {
                    sb.Append(' ');
                    charsInLine++;
                }

                sb.Append(word);
                charsInLine += word.Length;
            }

            if (line != lines[lines.Length - 1])
            {
                sb.AppendLine();
            }
        }

        var output = sb.ToString();

        return output;
    }
}
