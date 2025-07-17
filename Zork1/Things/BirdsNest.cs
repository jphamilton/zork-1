using Zork1.Library;

namespace Zork1.Things;

public class BirdsNest : Container
{
    public BirdsNest()
    {
        Capacity = 20;
        Flammable = true;
        Open = true;
        Search = true;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "bird's nest";
        Adjectives = ["nest", "birds"];
        Initial = "Beside you on the branch is a small bird's nest.";
        IsHere<JeweledEgg>();
    }
}
