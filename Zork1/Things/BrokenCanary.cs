using Zork1.Handlers;

namespace Zork1.Things;

public class BrokenCanary : Object
{
    public BrokenCanary()
    {
        TrophyValue = 1;
        Takeable = true;
    }

    public override void Initialize()
    {
        Name = "broken clockwork canary";
        Adjectives = ["broken", "canary", "clockw", "gold", "golden", "treasure"];
        Initial = "There is a golden clockwork canary nestled in the egg. It seems to have recently had a bad experience. The mountings for its jewel-like eyes are empty, and its silver beak is crumpled. Through a cracked crystal window below its left wing you can see the remains of intricate machinery. It is not clear what result winding it would have, as the mainspring seems sprung.";
        Before<WindUp>(() => Print("There is an unpleasant grinding noise from inside the canary."));
    }
}