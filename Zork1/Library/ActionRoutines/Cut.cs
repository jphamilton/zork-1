namespace Zork1.Library.ActionRoutines;

public class Cut : Routine
{
    public Cut()
    {
        Verbs = ["cut", "chop", "prune", "slice"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object first, Object second = null)
    {
        return Print($"Cutting {first.ThatOrThose} up would achieve little.");
    }
}
