namespace Zork1.Library;

public static class Output
{
    private static DynamicTeeTextWriter _target;
    private static IOutputFormatter _formatter;
    private static Object _context;

    public static TextWriter Out => _target;

    public static void Initialize(TextWriter destination, IOutputFormatter formatter)
    {
        _target = new DynamicTeeTextWriter(destination);
        _formatter = formatter;
    }

    public static void Bold(string text)
    {
        _target.Bold(text);
    }

    public static void Debug(string message)
    {
        if (State.Debug && !string.IsNullOrEmpty(message))
        {
            Print($"<{message}>");
        }
    }

    public static void Print(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            return;
        }

        // message will have newlines added bc of formatting 
        // ..." +
        // dead.";
        message = message.Replace(Environment.NewLine, "^");

        if (_context != null)
        {
            _target.Write($"{_context}: ");
        }

        if (string.IsNullOrEmpty(message))
        {
            _target.WriteLine();
        }
        else
        {
            var formatted = _formatter.Format(message);
            _target.WriteLine(formatted);
        }
    }

    public static void ScriptWrite(string message)
    {
        _target.ScriptWrite(message);
    }

    public static void Write(string message)
    {
        _target.Write(message);
    }

    public static void NewLine()
    {
        _target.WriteLine();
    }

    public static void SetObject(Object context)
    {
        _context = context;
    }

    public static bool StartScripting(string file)
    {
        _target.StartLogging(file);
        Print("Here begins a transcript of interaction with");
        Print(Messages.Version);
        return true;
    }

    public static bool StopScripting()
    {
        Print("Here ends a transcript of interaction with");
        Print(Messages.Version);
        _target.StopLogging();
        return true;
    }
}