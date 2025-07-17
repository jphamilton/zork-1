using Zork1.Handlers;
using Zork1.Scenic;
using Zork1.Things;

namespace Zork1.Rooms;

public class EndOfRainbow : AboveGround
{
    public override void Initialize()
    {
        Name = "End of Rainbow";
        Description = "You are on a small, rocky beach on the continuation of the Frigid River past the Falls. The beach is narrow due to the presence of the White Cliffs. The river canyon opens here and sunlight shines in from above. A rainbow crosses over the falls to the east and a narrow path continues to the southwest.";
        IsHere<PotOfGold>();
        WithScenery<Water, Rainbow, River>();
        SouthWestTo<CanyonBottom>();
        Before<Up, Northeast, East>(() => Flags.Rainbow ? GoTo<OnTheRainbow>() : false);
    }
}
