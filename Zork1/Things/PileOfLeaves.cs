using Zork1.Handlers;
using Zork1.Scenic;

namespace Zork1.Things;

public class PileOfLeaves : Object
{
    public Grating Grating => Get<Grating>();
    public bool Moved { get; set; }

    public PileOfLeaves()
    {
        Flammable = true;
        PluralName = true;
        Size = 25;
        Takeable = true;
        TryTake = true;
    }

    public override void Initialize()
    {
        Name = "pile of leaves";
        Adjectives = ["leaves", "leaf", "pile"];
        Describe = () => "On the ground is a pile of leaves.";

        Before<Count>(() => Print("There are 69,105 leaves here."));

        Before<Burn>(() =>
        {
            RevealGrating();
            Remove();
            return JigsUp("The leaves burn, and so do you.");
        });

        Before<Cut>(() =>
        {
            Print("You rustle the leaves around, making quite a mess.^");
            RevealGrating();
            return true;
        });

        Before<Take, Move>(() =>
        {
            if (Verb is Move)
            {
                Print("Done.");
            }

            if (Moved)
            {
                return false;
            }

            RevealGrating();

            return Verb is not Take;
        });

        Before<LookUnder>(() =>
        {
            if (!Moved)
            {
                return Print("Underneath the pile of leaves is a grating. As you release the leaves, the grating is once again concealed from view.");
            }

            return false;
        });
    }

    private bool RevealGrating()
    {
        if (Grating.Open || Moved)
        {
            return false;
        }

        if (Verb is Take || Verb is Move)
        {
            Print("In disturbing the pile of leaves, a grating is revealed.");
        }
        else
        {
            Print("With the leaves moved, a grating is revealed.");
        }

        Grating.Concealed = false;
        Moved = true;

        return false;
    }
}