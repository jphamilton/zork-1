using Zork1.Library;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class InStream : Room
{
    private static readonly string TooNarrow = "The channel is too narrow.";

    public InStream()
    {
        WaterRoom = true;
    }

    public override void Initialize()
    {
        Name = "Stream";
        Description = "You are on the gently flowing stream. The upstream route is too narrow to navigate, and the downstream route " +
            "is invisible due to twisting walls. There is a narrow beach to land on.";
        WithScenery<Water, PseudoStream>();
        LandTo<StreamView>();
        DownTo<Reservoir>();
        EastTo<Reservoir>();
        UpTo(() => NoGo(TooNarrow));
        WestTo(() => NoGo(TooNarrow));
    }
}

public class StreamView : Room
{
    public StreamView()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "Stream View";
        Description = "You are standing on a path beside a gently flowing stream. The path follows the stream, which flows from west to east.";
        WithScenery<Water, PseudoStream>();
        WestTo(() => NoGo("The stream emerges from a spot too small for you to enter."));
        EastTo<ReservoirSouth>();
    }
}