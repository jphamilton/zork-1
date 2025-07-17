using Zork1.Library;
using Zork1.Scenic;
using Zork1.Things;

namespace Zork1.Rooms;

public class Temple : Room
{
    public Temple()
    {
        DryLand = true;
        Sacred = true;
        Light = true;
    }

    public override void Initialize()
    {
        Name = "Temple";
        Description = "This is the north end of a large temple. On the east wall is an ancient inscription, " +
            "probably a prayer in a long-forgotten language. Below the prayer is a staircase leading down. " +
            "The west wall is solid granite. The exit to the north end of the room is through huge marble pillars.";
        WithScenery<Stairs, Prayer>();
        IsHere<BrassBell>();
        OutTo<TorchRoom>();
        DownTo<EgyptianRoom>();
        UpTo<TorchRoom>();
        SouthTo<Altar>();
        EastTo<EgyptianRoom>();
        NorthTo<TorchRoom>();
    }
}
