namespace Zork1.Library.ActionRoutines;

public class Search : Routine
{
    public Search()
    {
        Verbs = ["search"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object _, Object __)
    {
        return Fail("You find nothing of interest.");
    }
}
