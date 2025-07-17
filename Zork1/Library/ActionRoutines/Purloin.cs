using Zork1.Library;
using Zork1.Library.Things;

namespace Zork1.Library.ActionRoutines;

public class Purloin : Routine
{
    public Purloin()
    {
        Verbs = ["purloin"];
        InScopeOnly = false;
        Requires = [X.Noun];
    }

    public override bool Handler(Object obj, Object _)
    {
        Player.Add(obj);
        Print("[Purloined.]");
        return true;
    }
}
