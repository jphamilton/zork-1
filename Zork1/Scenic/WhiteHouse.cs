using Zork1.Handlers;
using Zork1.Library;
using Zork1.Library.Extensions;
using Zork1.Rooms;

namespace Zork1.Scenic;

public class WhiteHouse : Object
{
    private List<Room> InHouse = [];
    private List<Room> OutHouse = [];

    public WhiteHouse()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "white house";
        Adjectives = ["white", "house", "beautiful", "colonial"];

        InHouse = [
            Get<LivingRoom>(),
            Get<Kitchen>(),
            Get<Attic>(),
            Get<Kitchen>(),
        ];

        OutHouse = [
            Get<WestOfHouse>(),
            Get<NorthOfHouse>(),
            Get<BehindHouse>(),
            Get<SouthOfHouse>(),
        ];

        Before(() =>
        {
            if (!Location.Is<BehindHouse, WestOfHouse, NorthOfHouse, SouthOfHouse>())
            {
                return Print("You're not at the house.");
            }

            return false;
        });

        Before<WalkAround>(() =>
        {
            if (Location.Is<Kitchen, LivingRoom, Attic>())
            {
                return InHouse.GoNext();
            }

            return OutHouse.GoNext();
        });

        Before<Find>(() =>
        {
            if (Location.Is<Kitchen, LivingRoom, Attic>())
            {
                return Print("Why not find your brains?");
            }

            if (Location.Is<Clearing2>())
            {
                return Print("It seems to be to the west.");
            }

            return Print("It's right in front of you. Are you blind or something?");
        });

        Before<Examine>(() => Print("The house is a beautiful colonial house which is painted white. It is clear that the owners must have been extremely wealthy."));
        Before<Open, Enter>(() =>
        {
            var window = Get<KitchenWindow>();
            if (Location.Is<BehindHouse>())
            {
                if (window.Open)
                {
                    return GoTo<Kitchen>();
                }

                Print("The window is closed.");
                SetLast.Object(window);
                return true;
            }

            return Print("I can't see how to get in from here.");
        });

        Before<Burn>(() => Print("You must be joking."));
    }
}
