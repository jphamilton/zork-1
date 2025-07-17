using Zork1.Library;
using Zork1.Library.Things;
using System.Text.Json;

namespace Zork1.Library.ActionRoutines;

public class Restore : ForwardTokens
{
    public Restore()
    {
        Verbs = ["restore", "load"];
        NoTurn = true;
    }

    public override bool Handler(Object first, Object second = null) => false;

    public override bool Handle(List<string> tokens)
    {
        if (tokens == null || tokens.Count <= 1)
        {
            return Print("A file name is required.");
        }

        var file = Path.GetFileNameWithoutExtension(tokens[1]) + ".sav";
        var dir = Path.GetDirectoryName(Context.Story.GetType().Assembly.Location);
        var path = Path.Combine(dir, file);

        if (!File.Exists(path))
        {
            return Print("File not found.");
        }

        var json = File.ReadAllText(path);

        var options = new JsonSerializerOptions
        {
            IgnoreReadOnlyProperties = true,
            PropertyNameCaseInsensitive = true,
        };

        var game = JsonSerializer.Deserialize<SaveGame>(json, options) ?? new SaveGame();

        foreach (var w in game.X)
        {
            var obj = SaveObjectConverter.Restore(w);
            if (game.I.Contains(obj.Id))
            {
                Player.Add(obj);
            }
        }

        State.Moves = game.M;
        State.Score = game.CS;

        Player.Location = (Room)Objects.All.Single(x => x.Id == game.L);
        CurrentRoom.Look(true);

        return true;
    }

}
