using Zork1.Handlers;
using Zork1.Library;
using Zork1.Rooms;
using Zork1.Things;

namespace Zork1.Scenic;

public class Chute : Object
{
    public Chute()
    {
        Climable = true;
    }

    public override void Initialize()
    {
        Name = "chute";
        Adjectives = ["chute", "ramp", "slide", "steep", "metal", "twisting"];

        Before<Climb, ClimbUp, ClimbDown, Enter>(() =>
        {
            if (Location is Cellar)
            {
                return Print("You try to ascend the ramp, but it is impossible, and you slide back down.");
            }

            Print("You tumble down the slide....");
            return GoTo<Cellar>();
        });

        Before<Insert>(() =>
        {
            if (Noun.Takeable)
            {
                // https://github.com/the-infocom-files/zork1/issues/43
                if (Location.Is<SlideRoom>())
                {
                    Print($"The {Noun} falls into the slide and is gone.");
                }
                else
                {
                    Print($"The {Noun} lands at your feet.");
                }

                if (Noun is QuantityOfWater)
                {
                    Noun.Remove();
                    return true;
                }

                Noun.Move<Cellar>();
                return true;
            }

            return Print(Tables.Yuks.Pick());
        });
    }
}