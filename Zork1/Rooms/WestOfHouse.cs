using Zork1.Handlers;
using Zork1.Scenic;
using Zork1.Things;

namespace Zork1.Rooms;

public class WestOfHouse : AboveGround
{
    public override void Initialize()
    {
        Name = "West of House";
        WithScenery<FrontDoor, WhiteHouse, Boards>();

        IsHere<Mailbox>();

        Describe = () =>
        {
            var path = Flags.Won ? " A secret path leads southwest into the forest." : "";
            return $"You are standing in an open field west of a white house, with a boarded front door.{path}";
        };

        InTo(() => Flags.Won ? Get<StoneBarrow>() : null);
        SouthWestTo(() => Flags.Won ? Get<StoneBarrow>() : null);
        NorthTo<NorthOfHouse>();
        NorthEastTo<NorthOfHouse>();
        SouthEastTo<SouthOfHouse>();
        SouthTo<SouthOfHouse>();
        WestTo<Forest1>();
        Before<East>(() => Print("The door is boarded and you can't remove the boards."));
    }
}
