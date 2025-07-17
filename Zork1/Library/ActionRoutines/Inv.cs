using Zork1.Library;

namespace Zork1.Library.ActionRoutines;

public class Inv : Routine
{
    public Inv()
    {
        Verbs = ["i", "inv", "inventory"];
    }

    public override bool Handler(Object _, Object __)
    {
        return Print(Inventory.Display());
    }
}
