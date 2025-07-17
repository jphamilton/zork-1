using Zork1.Handlers;
using Zork1.Library;
using Zork1.Scenic;
using Zork1.Things;

namespace Zork1.Rooms;

public class CyclopsRoom : Room
{
    public CyclopsRoom()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "Cyclops Room";
        WithScenery<Stairs>();

        var cyclops = IsHere<Cyclops>();

        Describe = () =>
        {
            string desc = "This room has an exit on the northwest, and a staircase leading up. ";

            if (cyclops.Fled)
            {
                desc += " The east wall, previously solid, now has a cyclops-sized opening in it.";
            }

            return desc;
        };

        NorthWestTo<Maze8>();

        EastTo(() =>
        {
            if (cyclops.Fled)
            {
                return Get<StrangePassage>();
            }

            Print("The east wall is solid rock.");
            return this;
        });

        UpTo(() =>
        {
            if (cyclops.Asleep)
            {
                return Get<TreasureRoom>();
            }

            Print("The cyclops doesn't look like he'll let you past.");
            return this;
        });

        After<Enter>(() =>
        {
            if (cyclops.Cyclowrath != 0)
            {
                cyclops.StartDaemon();
            }
        });
    }
}
