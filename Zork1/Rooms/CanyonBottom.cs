using Zork1.Scenic;

namespace Zork1.Rooms;

public class CanyonBottom : AboveGround
{
    public override void Initialize()
    {
        Name = "Canyon Bottom";
        Description = "You are beneath the walls of the river canyon which may be climbable here. The lesser part of the runoff of Aragain Falls flows by below. To the north is a narrow path.";
        WithScenery<Water, Cliff, River>();
        UpTo<RockyLedge>();
        NorthTo<EndOfRainbow>();
    }
}
