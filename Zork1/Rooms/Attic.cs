using Zork1.Scenic;
using Zork1.Things;

namespace Zork1.Rooms;

public class Attic : AboveGround
{
    public Attic()
    {
        Light = false;
    }

    public override void Initialize()
    {
        Name = "Attic";
        Description = "This is the attic. The only exit is a stairway leading down.";
        WithScenery<WhiteHouse, Stairs>();
        IsHere<Rope>();
        IsHere<AtticTable>();

        DownTo<Kitchen>();
    }
}
