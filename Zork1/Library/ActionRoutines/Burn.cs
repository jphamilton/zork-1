namespace Zork1.Library.ActionRoutines;

public class Burn : Routine
{
    public Burn()
    {
        Verbs = ["burn"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object first, Object second = null)
    {
        return Print($"This dangerous act would achieve little.");
    }
}

public class BurnWith : Routine
{
    public BurnWith()
    {
        Verbs = ["burn"];
        Prepositions = ["with"];
        Requires = [X.Noun, X.Held];
    }

    public override bool Handler(Object first, Object second = null)
    {
        return Print($"This dangerous act would achieve little.");
    }
}
