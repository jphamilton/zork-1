using Zork1.Handlers;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class CanyonView : AboveGround
{
    public override void Initialize()
    {
        Name = "Canyon View";
        Description = "You are at the top of the Great Canyon on its west wall. From here there is a marvelous view of the canyon " +
            "and parts of the Frigid River upstream. Across the canyon, the walls of the White Cliffs join the mighty ramparts of the " +
            "Flathead Mountains to the east. Following the Canyon upstream to the north, Aragain Falls may be seen, complete with rainbow. " +
            "The mighty Frigid River flows out from a great dark cavern. To the west and south can be seen an immense forest, stretching " +
            "for miles around. A path leads northwest. It is possible to climb down into the canyon from here.";
        WithScenery<Cliff, River, Rainbow>();

        DownTo<RockyLedge>();
        NorthWestTo<Clearing2>();
        WestTo<Forest4>();
        EastTo<RockyLedge>();

        Before<South>(() => Print("Storm-tossed trees block your way."));
        Before<Dive>(() => JigsUp("Nice view, lousy place to jump."));
    }
}
