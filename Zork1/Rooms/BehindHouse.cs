using Zork1.Library;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class BehindHouse : AboveGround
{
    private KitchenWindow window;

    public override void Initialize()
    {
        window = Get<KitchenWindow>();

        Name = "Behind House";
        WithScenery<WhiteHouse, KitchenWindow>();
        Describe = () =>
        {
            var status = window.Open ? "open" : "slightly ajar";
            return "You are behind the white house. A path leads into the forest to the east. " +
            $"In one corner of the house there is a small window which is {status}.";
        };
        InTo(EnterHouse);
        WestTo(EnterHouse);
        SouthWestTo<SouthOfHouse>();
        NorthWestTo<NorthOfHouse>();
        SouthTo<SouthOfHouse>();
        EastTo<Clearing2>();
        NorthTo<NorthOfHouse>();
    }

    private Room EnterHouse()
    {
        if (window.Open)
        {
            return Get<Kitchen>();
        }

        return Get<KitchenWindow>();
    }
}
