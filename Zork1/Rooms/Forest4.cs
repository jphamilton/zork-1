using Zork1.Handlers;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class Forest4 : SongBirdRoom
{
    public override void Initialize()
    {
        base.Initialize();

        Name = "Forest";
        Description = "This is a dimly lit forest, with large trees all around.";
        WithScenery<Tree, Songbird, WhiteHouse, Forest>();
        NorthTo<Clearing2>();
        NorthWestTo<SouthOfHouse>();
        WestTo<Forest1>();
        Before<Up>(() => Print("There is no tree here suitable for climbing."));
        Before<South>(() => Print("Storm-tossed trees block your way."));
        Before<East>(() => Print("The rank undergrowth prevents eastward movement."));
    }
}
