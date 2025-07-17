using Zork1.Library;
using Zork1.Things;

namespace Zork1.Rooms;

public class LandOfTheDead : Room
{
    public LandOfTheDead()
    {
        Light = true;
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "Land of the Dead";
        Description =
            "You have entered the Land of the Living Dead. Thousands of lost souls " +
            "can be heard weeping and moaning. In the corner are stacked the remains of dozens " +
            "of previous adventurers less fortunate than yourself. A passage exits to the north.";
        WithScenery<PileOfBodies>();
        IsHere<CrystalSkull>();
        OutTo<EntranceToHades>();
        NorthTo<EntranceToHades>();
    }
}
