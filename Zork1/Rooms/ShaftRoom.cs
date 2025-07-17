using Zork1.Library;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class ShaftRoom : Room
{
    public ShaftRoom()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "Shaft Room";
        Description = "This is a large room, in the middle of which is a small shaft descending through the " +
            "floor into darkness below. To the west and the north are exits from this room. Constructed over " +
            "the top of the shaft is a metal framework to which a heavy iron chain is attached.";
        WithScenery<PseudoChain>();
        IsHere<Basket1>();

        DownTo(() => NoGo("You wouldn't fit and would die if you could."));
        WestTo<BatRoom>();
        NorthTo<SmellyRoom>();
    }
}
