using Zork1.Library;

namespace Zork1.Handlers;

public class Superbrief : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        State.SuperBrief = true;
        State.Verbose = false;
        return Print("Super-brief descriptions.");
    }
}
