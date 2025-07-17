using Zork1.Handlers;
using Zork1.Things;

namespace Zork1.Scenic;

public class PseudoLake : Object
{
    public PseudoLake()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "";
        Adjectives = ["lake"];
        Before(() =>
        {
            if (Flags.LowTide)
            {
                return Print("There's not much lake left....");
            }

            if (Verb is Cross)
            {
                return Print("It's too wide to cross.");
            }

            if (Verb is Enter)
            {
                return Print("You can't swim in this lake.");
            }

            return false;
        });
    }
}
