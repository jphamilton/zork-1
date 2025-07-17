using Zork1.Handlers;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class Clearing2 : AboveGround
{
    public override void Initialize()
    {
        Name = "Clearing";
        Description = "You are in a small clearing in a well marked forest path that extends to the east and west.";
        WithScenery<Tree, Songbird, WhiteHouse, Forest>();
        SouthTo<Forest4>();
        WestTo<BehindHouse>();
        EastTo<CanyonView>();
        NorthTo<Forest2>();

        Before<Up>(() => Print("There is no tree here suitable for climbing."));
    }
}
