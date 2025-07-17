using Zork1.Handlers;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class Forest3 : AboveGround
{
    public override void Initialize()
    {
        Name = "Forest";
        Description = "The forest thins out, revealing impassable mountains.";
        WithScenery<MountainRange, Tree, WhiteHouse>();
        NorthTo<Forest2>();
        SouthTo<Forest2>();
        WestTo<Forest2>();
        Before<Up>(() => Print("The mountains are impassable."));
        Before<East>(() => Print("The mountains are impassable."));
    }
}
