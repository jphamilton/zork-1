using Zork1.Library;
using Zork1.Scenic;
using Zork1.Things;
namespace Zork1.Rooms;

public class EgyptianRoom : Room
{
    public EgyptianRoom()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "Egyptian Room";
        Description = "This is a room which looks like an Egyptian tomb. There is an ascending staircase to the west.";
        WithScenery<Stairs>();
        IsHere<GoldCoffin>();
        UpTo<Temple>();
        WestTo<Temple>();
    }
}
