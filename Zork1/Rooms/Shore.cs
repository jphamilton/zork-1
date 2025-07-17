using Zork1.Scenic;

namespace Zork1.Rooms;

public class Shore : AboveGround
{
    public override void Initialize()
    {
        Name = "Shore";
        Description = "You are on the east shore of the river. The water here seems somewhat treacherous. A path travels from north to south here, the south end quickly turning around a sharp corner.";
        WithScenery<Water, River>();
        SouthTo<AragainFalls>();
        NorthTo<SandyBeach>();
    }
}