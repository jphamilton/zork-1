namespace Zork1.Library.ActionRoutines;

public class Release : Routine
{
    public Release()
    {
        Verbs = ["release", "free"];
        Requires = [X.Animate];
    }

    public override bool Handler(Object obj, Object _ = null)
    {
        return Fail("You can't release that.");
    }
}
