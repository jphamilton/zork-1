using Zork1.Handlers;
using Zork1.Library;
using Zork1.Things;

namespace Zork1.Rooms;

public class TrollRoom : Room
{
    private static string Menacing = "The troll fends you off with a menacing gesture.";

    public TrollRoom()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "The Troll Room";
        Description = "This is a small room with passages to the east and south and a forbidding hole leading west. Bloodstains and deep scratches (perhaps made by an axe) mar the walls.";
        IsHere<Troll>();
        SouthTo<Cellar>();
        WestTo(() => Flags.Troll ? Get<Maze1>() : NoGo(Menacing));
        EastTo(() => Flags.Troll ? Get<EastWestPassage>() : NoGo(Menacing));
        After<Enter>(() => SetLast.Object(Get<Troll>()));
    }
}