using Zork1.Library;
using Zork1.Things;

namespace Zork1.Rooms;

public class DamLobby : Room
{
    public DamLobby()
    {
        DryLand = true;
        Light = true;
    }

    public override void Initialize()
    {
        Name = "Dam Lobby";
        Description = "This room appears to have been the waiting room for groups touring the dam. " +
            "There are open doorways here to the north and east marked ~Private~, and there is an path leading south over the top of the dam.";
        IsHere<Matchbook>();
        IsHere<TourGuidebook>();
        SouthTo<Dam>();
        EastTo<MaintenanceRoom>();
        NorthTo<MaintenanceRoom>();
    }
}
