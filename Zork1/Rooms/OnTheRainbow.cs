using Zork1.Scenic;

namespace Zork1.Rooms;

public class OnTheRainbow : AboveGround
{
    public override void Initialize()
    {
        Name = "On the Rainbow";
        Description = "You are on top of a rainbow (I bet you never thought you would walk on a rainbow), with a magnificent view of the Falls. The rainbow travels east-west here.";
        WithScenery<Rainbow>();
        WestTo<EndOfRainbow>();
        EastTo<AragainFalls>();
    }
}
