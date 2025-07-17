using Zork1.Handlers;

namespace Zork1.Scenic;

public class PseudoNails : Object
{
    public PseudoNails()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "nails";
        Adjectives = ["nails", "nail"];
        Before<Take>(() => Print("The nails, deeply imbedded in the door, cannot be removed."));
    }
}
