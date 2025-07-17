using Zork1.Things;

namespace Zork1.Library.ActionRoutines;

public class Count : Routine
{
    public Count()
    {
        Verbs = ["count"];
        Requires = [X.Noun];
    }
    public override bool Handler(Object first, Object second = null)
    {
        if (first is Blessings)
        {
            return Print("Well, for one, you are playing Zork...");
        }

        return Print("You have lost your mind.");
    }
}
