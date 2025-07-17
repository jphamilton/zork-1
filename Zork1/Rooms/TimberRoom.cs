using Zork1.Things;

namespace Zork1.Rooms;

public class TimberRoom : Drafty
{
    public TimberRoom()
    {
        DryLand = true;
        Sacred = true;
    }

    public override void Initialize()
    {
        Name = "Timber Room";
        Description = "This is a long and narrow passage, which is cluttered with broken timbers. " +
            "A wide passage comes from the east and turns at the west end of the room into a very narrow passageway. " +
            "From the west comes a strong draft.";
        IsHere<BrokenTimber>();
        WestTo(() => EmptyHanded() ? Get<DraftyRoom>() : NoGo(CantFit));
        EastTo<LadderBottom>();
    }
}
