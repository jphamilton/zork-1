namespace Zork1.Library.ActionRoutines;

public class WaveAt : Routine
{
    public WaveAt()
    {
        Verbs = ["wave"];
        Prepositions = ["at"];
        Requires = [X.Noun, X.Noun];
    }

    public override bool Handler(Object obj, Object indirect)
    {
        return Print($"You wave {obj.DName} at {indirect.DName}, feeling foolish.");
    }
}

public class Wave : Routine
{
    public Wave()
    {
        Verbs = ["wave"];
        Requires = [X.Noun];
    }

    public override bool Handler(Object first, Object _)
    {
        Print($"You look ridiculous waving {first.DName}.");
        return true;
    }
}

public class WaveHands : Routine
{
    public WaveHands()
    {
        Verbs = ["wave"];
    }

    public override bool Handler(Object _, Object __)
    {
        return Print("You wave your hands, feeling foolish.");
    }
}