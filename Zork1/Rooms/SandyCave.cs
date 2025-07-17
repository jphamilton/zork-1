using Zork1.Library;
using Zork1.Scenic;
using Zork1.Things;

namespace Zork1.Rooms;

public class SandyCave : Room
{
    public SandyCave()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "Sandy Cave";
        Description = "This is a sand-filled cave whose exit is to the southwest.";
        WithScenery<Sand>();
        IsHere<Scarab>();
        SouthWestTo<SandyBeach>();
    }
}
