using Zork1.Handlers;
using Zork1.Library;
using Zork1.Scenic;
using Zork1.Things;

namespace Zork1.Rooms;

public abstract class RiverRoom : Room
{
    public RiverRoom()
    {
        WaterRoom = true;
        Sacred = true;
    }

    public override void Initialize()
    {
        Before<Up>(() => Print("You cannot go upstream due to strong currents."));
    }
}

public class River1 : RiverRoom
{
    public River1()
    {
        Light = true;
    }

    public override void Initialize()
    {
        Name = "Frigid River";
        Description = "The sound of rushing water is nearly unbearable here. On the east shore is a large landing area.";
        WithScenery<Water, River>();
        LandTo<Shore>();
        EastTo<Shore>();
    }
}

public class FrigidRiver : RiverRoom
{
    public override void Initialize()
    {
        Name = "Frigid River";
        Description = "The river is running faster here and the sound ahead appears to be that of rushing water. " +
            "On the east shore is a sandy beach. A small area of beach can also be seen below the cliffs on the west shore.";
        IsHere<RedBuoy>();
        LandTo(() => NoGo("You can land either to the east or the west."));
        DownTo<River1>();
        WestTo<Beach1>();
        EastTo<SandyBeach>();
    }
}

public class River2 : RiverRoom
{
    public override void Initialize()
    {
        Name = "Frigid River";
        Description = "The river descends here into a valley. There is a narrow beach on the west shore below the cliffs. In the distance a faint rumbling can be heard.";
        LandTo<Beach2>();
        DownTo<FrigidRiver>();
        WestTo<Beach2>();
    }
}

public class River3 : RiverRoom
{
    public override void Initialize()
    {
        Name = "Frigid River";
        Description = "The river turns a corner here making it impossible to see the Dam. The White Cliffs loom on " +
            "the east bank and large rocks prevent landing on the west.";
        WithScenery<Water, River>();
        LandTo(() => NoGo("There is no safe landing spot here."));
        DownTo<River2>();
        Before<West>(() => Print("Just in time you steer away from the rocks."));
        Before<East>(() => Print("The White Cliffs prevent your landing here."));
    }
}

public class River4 : RiverRoom
{
    public River4()
    {
        Light = true;
    }

    public override void Initialize()
    {
        Name = "Frigid River";
        Description = "You are on the Frigid River in the vicinity of the Dam. The river flows quietly here. There is a landing on the west shore.";
        WithScenery<Water, River>();
        LandTo<DamBase>();
        DownTo<River3>();
        WestTo<DamBase>();
        Before<East>(() => Print("The White Cliffs prevent your landing here."));
    }
}