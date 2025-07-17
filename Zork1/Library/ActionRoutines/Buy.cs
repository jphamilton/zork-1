namespace Zork1.Library.ActionRoutines;

public class Buy : Routine
{
    public Buy()
    {
        Verbs = ["buy", "purchase"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object first, Object second = null)
    {
        return Print($"Nothing is on sale.");
    }
}
