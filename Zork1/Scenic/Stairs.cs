using Zork1.Handlers;

namespace Zork1.Scenic;

public class Stairs : Object
{
    public Stairs()
    {
        Climable = true;
        PluralName = true;
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "stairs";
        Adjectives = ["stairs", "steps", "staircase", "stairway", "stone", "dark", "marble", "forbidding", "steep"];

        Before<Enter>(() => Print("You should say whether you want to go up or down."));
    }
}
