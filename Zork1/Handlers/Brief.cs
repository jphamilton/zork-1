using Zork1.Library;

namespace Zork1.Handlers;

public class Brief : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        State.Verbose = false;
        State.SuperBrief = false;
        return Print("Brief descriptions.");
    }
}
