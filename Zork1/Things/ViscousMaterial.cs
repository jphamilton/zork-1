using Zork1.Handlers;

namespace Zork1.Things;

public class ViscousMaterial : Object
{
    public ViscousMaterial()
    {
        Size = 6;
        Takeable = true;
        Tool = true;
    }

    public override void Initialize()
    {
        Name = "viscous material";
        Adjectives = ["material", "gunk", "viscous"];
        // https://github.com/the-infocom-files/zork1/issues/25
        Before<Grease, Insert, PutOn>(() => Print("The all-purpose gunk isn't a lubricant."));
    }
}
