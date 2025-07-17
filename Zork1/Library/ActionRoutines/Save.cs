using Zork1.Library;
using Zork1.Library.Things;
using System.Text.Json;

namespace Zork1.Library.ActionRoutines;

public class Save : ForwardTokens
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters = { new SaveObjectConverter() },
        IgnoreReadOnlyProperties = true,
        PropertyNameCaseInsensitive = true,
    };

    public Save()
    {
        Verbs = ["save"];
        NoTurn = true;
    }

    public override bool Handler(Object first, Object second = null) => false;

    public override bool Handle(List<string> tokens)
    {
        if (tokens == null || tokens.Count <= 1)
        {
            Print("A file name is required.");
            return true;
        }

        try
        {
            var file = Path.GetFileNameWithoutExtension(tokens[1]) + ".sav";
            var dir = Path.GetDirectoryName(Context.Story.GetType().Assembly.Location);
            var path = Path.Combine(dir, file);

            var objects = Objects.All.Where(x => x.Id != 0).Select(x => new SaveObject(x)).ToList();

            var saveGame = new SaveGame
            {
                X = objects,
                I = [.. Inventory.Items.Select(x => x.Id)],
                L = Player.Location.Id,
                M = State.Moves,
                CS = State.Score,
            };

            var json = JsonSerializer.Serialize(saveGame, SerializerOptions);

            File.WriteAllText(path, json);

            return Print("Ok.");
        }
        catch
        {
            return Print("Unable to save game.");
        }

    }

}
