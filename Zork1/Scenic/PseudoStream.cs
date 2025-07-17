using Zork1.Handlers;

namespace Zork1.Scenic;

public class PseudoStream : Object
{
    public PseudoStream()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "";
        Adjectives = ["stream"];
        Before<Enter, Swim>(() => Print("You can't swim in the stream."));
        Before<Cross>(() => Print("The other side is a sheer rock cliff."));
    }
}
