using Zork1.Handlers;
using Zork1.Library;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class Kitchen : AboveGround
{
    private KitchenWindow Window => Objects.Get<KitchenWindow>();

    public override void Initialize()
    {
        Name = "Kitchen";
        WithScenery<KitchenWindow, WhiteHouse, Chimney, Stairs>();

        IsHere<KitchenTable>();

        TakeValue = 10;

        Describe = () =>
        {
            var state = Window.Open ? "open" : "slightly ajar";
            return "You are in the kitchen of the white house. A table seems to have been used recently " +
            "for the preparation of food. A passage leads to the west and a dark staircase can be seen leading upward. " +
            $"A dark chimney leads down and to the east is a small window which is {state}.";
        };

        UpTo<Attic>();
        WestTo<LivingRoom>();
        EastTo<KitchenWindow>();
        OutTo<KitchenWindow>();

        Before<Down>(() => Print("Only Santa Claus climbs down chimneys."));

        Before<ClimbDown>(() =>
        {
            if (Noun is Stairs)
            {
                return Print("There are no stairs leading down.");
            }

            return false;
        });
    }
}
