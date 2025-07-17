using Zork1.Handlers;

namespace Zork1.Scenic;

public class MountainRange : Object
{
    public MountainRange()
    {
        Climable = true;
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "mountain range";
        Adjectives = ["impassable", "flathead", "mountain", "range"];
        Before<ClimbUp, ClimbDown>(() => Print("Don't you believe me? The mountains are impassable!"));
    }
}
