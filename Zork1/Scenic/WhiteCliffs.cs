using Zork1.Handlers;

namespace Zork1.Scenic;

public class WhiteCliffs : Object
{
    public WhiteCliffs()
    {
        Climable = true;
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "white cliffs";
        Adjectives = ["cliffs", "cliff", "white"];
        Before<Climb, ClimbDown, ClimbUp>(() => Print("The cliff is too steep for climbing."));
    }
}
