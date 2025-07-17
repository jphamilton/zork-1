using Zork1.Library;

namespace Zork1.Handlers;

public class Verbose : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        State.Verbose = true;
        State.SuperBrief = false;
        return Print("Maximum verbosity.");
    }
}
