using Zork1.Handlers;
using Zork1.Library;
using Zork1.Rooms;

namespace Zork1.Scenic;

public class StoneDoor : Door
{
    public StoneDoor()
    {
        Scenery = true;
        Open = true;
    }

    public override void Initialize()
    {
        Name = "stone door";
        Adjectives = ["huge", "stone", "door"];
        Before<Open, Close>(() => Print("The door is too heavy."));
        //https://github.com/the-infocom-files/zork1/issues/70
        DoorDirection(() => Direction<Enter>());
        DoorTo(() => Get<InsideTheBarrow>());
    }
}
