using Zork1.Handlers;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class NorthOfHouse : AboveGround
{
    public override void Initialize()
    {
        Name = "North of House";
        Description = "You are facing the north side of a white house. There is no door here, and all the windows are boarded up. To the north a narrow path winds through the trees.";
        WithScenery<Boards, BoardedWindow, WhiteHouse>();
        SouthWestTo<WestOfHouse>();
        SouthEastTo<BehindHouse>();
        WestTo<WestOfHouse>();
        EastTo<BehindHouse>();
        NorthTo<ForestPath>();

        Before<South>(() => Print("The windows are all boarded."));
    }
}
