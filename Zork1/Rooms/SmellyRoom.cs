using Zork1.Library;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class SmellyRoom : Room
{
    public SmellyRoom()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "Smelly Room";
        Description = "This is a small non-descript room. However, from the direction of a small descending staircase a foul odor can be detected. To the south is a narrow tunnel.";
        WithScenery<PseudoGas, Stairs>();
        DownTo<GasRoom>();
        SouthTo<ShaftRoom>();
    }
}
