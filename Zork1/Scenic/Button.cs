using Zork1.Handlers;
using Zork1.Rooms;
using Zork1.Things;

namespace Zork1.Scenic;

public abstract class Button : Object
{
    public MaintenanceRoom maintenance_room => Get<MaintenanceRoom>();

    public Button()
    {
        Scenery = true;
        Before<Read>(() => Print("You think I can read EBCDIC??!?"));
    }
}

public class BlueButton : Button
{
    public override void Initialize()
    {
        Name = "blue button";
        Adjectives = ["blue", "button", "switch"];
        Before<Push>(() =>
        {
            if (maintenance_room.LeakSprung == 0)
            {
                return maintenance_room.TriggerLeak();
            }

            return Print("The blue button appears to be jammed.");
        });
    }
}

public class RedButton : Button
{
    public override void Initialize()
    {
        Name = "red button";
        Adjectives = ["red", "button", "switch"];
        Before<Push>(() =>
        {
            if (maintenance_room.Light)
            {
                maintenance_room.Light = false;
                return Print("The lights within the room shut off.");
            }

            maintenance_room.Light = true;
            return Print("The lights within the room come on.");
        });
    }
}

public class BrownButton : Button
{
    public override void Initialize()
    {
        Name = "brown button";
        Adjectives = ["brown", "button", "switch"];
        Before<Push>(() =>
        {
            var dam = Get<Dam>();
            dam.Visited = false;
            Flags.Gate = false;
            return Print("Click.");
        });
    }
}

public class YellowButton : Object
{
    public override void Initialize()
    {
        Name = "yellow button";
        Adjectives = ["yellow", "button", "switch"];
        Before<Push>(() =>
        {
            var dam = Get<Dam>();
            dam.Visited = false;
            Flags.Gate = true;
            return Print("Click.");
        });
    }
}