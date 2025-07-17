using Zork1.Library;
using System.Linq;

namespace Zork1.Library.ActionRoutines;

public class SwitchOff : Routine
{
    public SwitchOff()
    {
        Verbs = ["switch", "off", "turn", "rotate", "screw", "twist", "unscrew"];
        Prepositions = ["off"];
        Requires = [X.Noun];

        ImplicitObject = (X _) =>
        {
            var held = Inventory.Items.Where(o => o.Switchable).ToList();
            return held.Count == 1 ? held[0] : null;
        };
    }

    public override bool Handler(Object obj, Object _ = null)
    {
        if (obj.Switchable)
        {
            if (obj.On)
            {
                obj.On = false;
                return Print($"You switch {obj.DName} off.");
            }
            else
            {
                return Fail("That's already off.");
            }
        }
        else
        {
            return Fail("That's not something you can switch off.");
        }
    }
}