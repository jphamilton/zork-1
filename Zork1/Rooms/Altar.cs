using Zork1.Library;
using Zork1.Library.Things;
using Zork1.Scenic;
using Zork1.Things;

namespace Zork1.Rooms;

public class Altar : Room
{
    public Altar()
    {
        DryLand = true;
        Sacred = true;
        Light = true;
    }

    public override void Initialize()
    {
        Name = "Altar";
        Description = "This is the south end of a large temple. In front of you is what appears to be an altar. " +
            "In one corner is a small hole in the floor which leads into darkness. You probably could not get back up it.";
        WithScenery<AltarScenery>();
        IsHere<BlackBook>();
        IsHere<PairOfCandles>();
        DownTo(() => !Player.Has<GoldCoffin>() ? Get<Cave1>() : NoGo("You haven't a prayer of getting the coffin down there."));
        NorthTo<Temple>();
    }
}
