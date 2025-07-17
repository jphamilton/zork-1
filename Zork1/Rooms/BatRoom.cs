using Zork1.Library;
using Zork1.Scenic;
using Zork1.Things;

namespace Zork1.Rooms;

public class BatRoom : Room
{
    public BatRoom()
    {
        DryLand = true;
        Sacred = true;
    }

    public override void Initialize()
    {
        Name = "Bat Room";
        Description = "You are in a small room which has doors only to the east and south.";
        IsHere<JadeFigurine>();
        var bat = IsHere<Bat>();

        Initial = () =>
        {
            if (!bat.Pacified)
            {
                bat.MovePlayer();
                return false;
            }

            return true;
        };

        EastTo<ShaftRoom>();
        SouthTo<SqueakyRoom>();
    }
}