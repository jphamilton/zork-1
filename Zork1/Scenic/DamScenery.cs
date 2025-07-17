using Zork1.Handlers;
using Zork1.Things;

namespace Zork1.Scenic;

public class DamScenery : Object
{
    public DamScenery()
    {
        Scenery = true;
        TryTake = true;
    }

    public override void Initialize()
    {
        Name = "dam";
        Adjectives = ["dam", "gate", "gates"];
        Before<Open, Close>(() => Print("Sounds reasonable, but this isn't how."));
        Before<Fix>(() =>
        {
            if (Second is PairOfHands)
            {
                return Print("Are you the little Dutch boy, then? Sorry, this is a big dam.");
            }

            return Print($"With a {Second}? Do you know how big this dam is? You could only stop a tiny leak with that.");
        });
    }
}
