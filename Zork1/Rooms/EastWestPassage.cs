using Zork1.Library;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class EastWestPassage : Room
{
    public EastWestPassage()
    {
        DryLand = true;
        TakeValue = 5;
    }

    public override void Initialize()
    {
        Name = "East-West Passage";
        Description = "This is a narrow east-west passageway. There is a narrow stairway leading down at the north end of the room.";
        WithScenery<Stairs>();
        DownTo<Chasm>();
        WestTo<TrollRoom>();
        EastTo<RoundRoom>();
        NorthTo<Chasm>();
    }
}