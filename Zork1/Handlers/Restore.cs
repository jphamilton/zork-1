using System.Text.Json;
using Zork1.Library;

namespace Zork1.Handlers;

public class Restore : GameFile
{
    public override bool Handler(Object noun, Object second)
    {
        try
        {
            var path = GetFile(false);

            var encoded = File.ReadAllText(path);
            var json = Decode(encoded);

            var options = new JsonSerializerOptions
            {
                IgnoreReadOnlyProperties = true,
                PropertyNameCaseInsensitive = true,
            };

            var game = JsonSerializer.Deserialize<SaveGame>(json, options);

            if (game != null)
            {
                foreach (var w in game.X)
                {
                    var obj = SaveObjectConverter.Restore(w);
                }

                CurrentRoom.Look(true);
            }

            return true;
        }
        catch
        {
            return Print("Unable to restore game.");
        }
    }
}
