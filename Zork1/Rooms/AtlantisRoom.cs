using Zork1.Library;
using Zork1.Scenic;
using Zork1.Things;

namespace Zork1.Rooms;

public class AtlantisRoom : Room
{
    public AtlantisRoom()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "Atlantis Room";
        Description = "This is an ancient room, long under water. There is an exit to the south and a staircase leading up.";
        WithScenery<Stairs>();
        IsHere<CrystalTrident>();
        UpTo<Cave2>();
        SouthTo<ReservoirNorth>();
    }
}
