using Zork1.Library;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class EngravingsCave : Room
{
    public EngravingsCave()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "Engravings Cave";
        Description = "You have entered a low cave with passages leading northwest and east.";
        IsHere<WallWithEngravings>();
        NorthWestTo<RoundRoom>();
        EastTo<DomeRoom>();
    }
}