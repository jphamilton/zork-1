using Zork1.Library;

namespace Zork1.Rooms;

public class NorthSouthPassage : Room
{
    public NorthSouthPassage()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "North-South Passage";
        Description = "This is a high north-south passage, which forks to the northeast.";
        NorthEastTo<DeepCanyon>();
        SouthTo<RoundRoom>();
        NorthTo<Chasm>();
    }
}