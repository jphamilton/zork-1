namespace Zork1.Library.ActionRoutines;

public class Blow : Routine
{
    public Blow()
    {
        Verbs = ["blow"];
        Requires = [X.Held];
    }

    public override bool Handler(Object first, Object second = null)
    {
        return Print($"You can't usefully blow {first.ThatOrThose}.");
    }
}
