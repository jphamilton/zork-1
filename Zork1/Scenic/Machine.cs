using Zork1.Handlers;
using Zork1.Library;
using Zork1.Things;

namespace Zork1.Scenic;

public class Machine : Container
{
    public Machine()
    {
        Capacity = 50;
        TryTake = true;
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "machine";
        Adjectives = ["machine", "pdp1", "dryer", "lid"];
        Before<Take>(() => Print("It is far too large to carry."));
        Before<Open>(() =>
        {
            if (Open)
            {
                return Print(Tables.Dummy.Pick());
            }

            Open = true;

            if (Items.Count > 0)
            {
                return PrintContents("The lid opens, revealing");
            }

            return Print("The lid opens.");
        });

        Before<Close>(() =>
        {
            if (Open)
            {
                Open = false;
                return Print("The lid closes.");
            }

            return Print(Tables.Dummy.Pick());
        });

        Before<SwitchOn>(() =>
        {
            if (Second == null)
            {
                return Print("It's not clear how to turn it on with your bare hands.");
            }

            return Redirect.To<MoveWith>(this, Second);
        });
    }

    public bool TurnOn()
    {
        var (pile_of_coal, huge_diamond, vitreous_slag) = Get<PileOfCoal, HugeDiamond, VitreousSlag>();

        if (Open)
        {
            return Print("The machine doesn't seem to want to do anything.");
        }

        Print("The machine comes to life (figuratively) with a dazzling display of colored lights and bizarre noises. " +
            "After a few moments, the excitement abates.");

        if (Has(pile_of_coal))
        {
            pile_of_coal.Remove();
            huge_diamond.Move(this);
            return true;
        }

        if (Items.Count > 0)
        {
            foreach (var child in Items)
            {
                child.Remove();
            }

            vitreous_slag.Move(this);
        }

        return true;
    }
}
