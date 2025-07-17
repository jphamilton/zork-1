using Zork1.Handlers;
using Zork1.Rooms;

namespace Zork1.Scenic;

public class Chimney : Object
{
    public Chimney()
    {
        Climable = true;
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "chimney";
        Adjectives = ["chimney", "dark", "narrow"];

        Before<Examine>(() =>
        {
            var dir = Location.Is<Kitchen>() ? "down" : "up";
            return Print($"The chimney leads {dir}ward, and looks climbable.");
        });
    }
}
