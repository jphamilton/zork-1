using Zork1.Library;
using Zork1.Things;

namespace Zork1.Rooms;

public class RoundRoom : Room
{
    public RoundRoom()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "Round Room";
        Description = "This is a circular stone room with passages in all directions. Several of them have unfortunately been blocked by cave-ins.";
        IsHere<Thief>();
        SouthEastTo<EngravingsCave>();
        SouthTo<NarrowPassage>();
        WestTo<EastWestPassage>();
        EastTo<LoudRoom>();
        NorthTo<NorthSouthPassage>();
    }
}