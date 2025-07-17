using Zork1.Library;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class Chasm : Room
{
    public Chasm()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "Chasm";
        Description = "A chasm runs southwest to northeast and the path follows it. You are on the south side of the chasm, where a crack opens into a passage.";
        WithScenery<PseudoChasm, Crack>();
        DownTo(() => NoGo("Are you out of your mind?"));
        NorthEastTo<ReservoirSouth>();
        SouthTo<NorthSouthPassage>();
        SouthWestTo<EastWestPassage>();
    }
}
