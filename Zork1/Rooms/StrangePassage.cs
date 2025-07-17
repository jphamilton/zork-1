using Zork1.Library;

namespace Zork1.Rooms;

public class StrangePassage : Room
{
    public StrangePassage()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "Strange Passage";
        Description = "This is a long passage. To the west is one entrance. On the east there is an old wooden door, with a large opening in it (about cyclops sized).";
        InTo<CyclopsRoom>();
        WestTo<CyclopsRoom>();
        EastTo<LivingRoom>();
    }
}