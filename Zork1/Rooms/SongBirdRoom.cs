using Zork1.Handlers;
using Zork1.Scenic;

namespace Zork1.Rooms;

public abstract class SongBirdRoom : AboveGround
{
    public override void Initialize()
    {
        After<Enter>(() =>
        {
            var songbird = Get<Songbird>();
            songbird.StartDaemon();
        });

        After<Exit>(() =>
        {
            var songbird = Get<Songbird>();
            songbird.StopDaemon();
        });
    }
}
