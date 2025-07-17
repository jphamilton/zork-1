namespace Zork1.Library.ActionRoutines;

public class Rub : Routine
{
    public Rub()
    {
        Verbs = ["rub", "clean", "dust", "polish", "scrub", "shine", "sweep", "wipe"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object _, Object __)
    {
        return Fail("You achieve nothing by this.");
    }
}
