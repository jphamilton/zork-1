using Zork1.Library;
using System.Linq;

namespace Zork1.Library.ActionRoutines;

//Verb 'wear' 'don'
//    * held -> Wear;

public class Wear : Routine
{
    public Wear()
    {
        Verbs = ["wear", "don"];
        Requires = [X.Held];
        ImplicitObject = (_) =>
        {
            var clothing = Inventory.Items.Where(x => x.Clothing).ToList();
            return clothing.Count == 1 ? clothing[0] : null;
        };
    }

    public override bool Handler(Object obj, Object _ = null)
    {
        if (!obj.Clothing)
        {
            return Fail("You can't wear that!");
        }

        obj.Worn = true;

        return Success($"You put on {obj.DName}.");
    }
}