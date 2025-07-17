using Zork1.Handlers;
using Zork1.Library;

namespace Zork1.Things;

public class ToolChests : Container
{
    public ToolChests()
    {
        Sacred = true;
        Open = true;
        TryTake = true;
    }

    public override void Initialize()
    {
        Name = "group of tool chests";
        Adjectives = ["chest", "chests", "group", "tool", "toolchests"];
        Before<Examine>(() => Print("The chests are all empty."));
        Before<Open, Take>(() =>
        {
            Remove();
            return Print("The chests are so rusty and corroded that they crumble when you touch them.");
        });
    }
}
