using System.Text.Json;
using Zork1.Library;

namespace Zork1.Handlers;

public abstract class GameFile : Sub
{
    protected string Encode(string data)
    {
        var raw = System.Text.Encoding.UTF8.GetBytes(data);
        return Convert.ToBase64String(raw);
    }

    protected string Decode(string data)
    {
        var bytes = Convert.FromBase64String(data);
        return System.Text.Encoding.UTF8.GetString(bytes);
    }
    protected string GetFile(bool save)
    {
        var slot = GetSlot();

        if (slot == null)
        {
            return null;
        }

        var file = $"SLOT{slot}";
        var dir = Path.GetDirectoryName(Context.Story.GetType().Assembly.Location);
        var path = Path.Combine(dir, file);

        if (!save && !File.Exists(path))
        {
            return null;
        }

        return path;
    }

    protected int? GetSlot()
    {
        Console.WriteLine("Type backspace to abort");
        Console.Write("Position (0-9) (default = 0): ");

        ConsoleKeyInfo key;

        while (true)
        {
            key = Console.ReadKey(intercept: true);

            if (key.Key == ConsoleKey.Backspace)
            {
                break;
            }

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                break;
            }

            if (key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9)
            {
                Console.WriteLine(key.KeyChar);
                return int.Parse(key.KeyChar.ToString());
            }
        }

        return null;
    }
}

public class Save : GameFile
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters = { new SaveObjectConverter() },
        IgnoreReadOnlyProperties = true,
        PropertyNameCaseInsensitive = true,
    };

    public override bool Handler(Object noun, Object second)
    {
        try
        {
            var path = GetFile(true);
            var objects = Objects.All.Where(x => x.Id != 0).Select(x => new SaveObject(x)).ToList();

            var saveGame = new SaveGame
            {
                X = objects,
            };

            var json = JsonSerializer.Serialize(saveGame, SerializerOptions);
            var encoded = Encode(json);

            File.WriteAllText(path, encoded);

            Print("Ok.");
            //Console.WriteLine();
        }
        catch
        {
            return Print("Unable to save game.");
        }

        return true;
    }
}
