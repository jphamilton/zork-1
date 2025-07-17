using Zork1.Handlers;

namespace Zork1.Scenic;

public class PseudoChain : Object
{
    public PseudoChain()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "";
        Adjectives = ["chain"];
        Before<Move, Take>(() => Print("The chain is secure."));
        Before<Lower, Raise>(() => Print("Perhaps you should do that to the basket."));
        Before<Examine>(() => Print("The chain secures a basket within the shaft."));
    }
}