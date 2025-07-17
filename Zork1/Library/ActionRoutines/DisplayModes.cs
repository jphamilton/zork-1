using Zork1.Library;

namespace Zork1.Library.ActionRoutines;

public class Brief : Routine
{
    public Brief()
    {
        Verbs = ["brief"];
        NoTurn = true;
    }

    public override bool Handler(Object _, Object __)
    {
        State.Verbose = false;
        return Print($"{Context.Story.Name} is now in \"brief\" mode, which gives long descriptions of places never before visited and short descriptions otherwise.");
    }
}

public class Verbose : Routine
{
    public Verbose()
    {
        Verbs = ["verbose"];
        NoTurn = true;
    }

    public override bool Handler(Object _, Object __)
    {
        State.Verbose = true;
        return Print($"{Context.Story.Name} is now in \"verbose\" mode, which always gives long descriptions of locations (even if you've been there before).");
    }
}