using Zork1.Handlers;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class SouthOfHouse : AboveGround
{
    public override void Initialize()
    {
        Name = "South of House";
        Description = "You are facing the south side of a white house. There is no door here, and all the windows are boarded.";
        WithScenery<Boards, BoardedWindow, WhiteHouse>();
        NorthWestTo<WestOfHouse>();
        NorthEastTo<BehindHouse>();
        SouthTo<Forest4>();
        WestTo<WestOfHouse>();
        EastTo<BehindHouse>();
        Before<North>(() => Print("The windows are all boarded."));
    }
}
