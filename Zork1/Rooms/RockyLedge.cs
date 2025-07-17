using Zork1.Scenic;

namespace Zork1.Rooms;

public class RockyLedge : AboveGround
{
    public override void Initialize()
    {
        Name = "Rocky Ledge";
        Description = "You are on a ledge about halfway up the wall of the river canyon. You can see from here that the main flow from Aragain Falls twists along a passage which it is impossible to enter. Below you is the canyon bottom. Above you is more cliff, which appears climbable.";
        WithScenery<Cliff, River>();
        DownTo<CanyonBottom>();
        UpTo<CanyonView>();
    }
}
