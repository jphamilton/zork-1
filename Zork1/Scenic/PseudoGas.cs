using Zork1.Handlers;

namespace Zork1.Scenic;

public class PseudoGas : Object
{
    public PseudoGas()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "";
        Adjectives = ["odor", "gas"];

        Before<BlowIn>(() => Print("There is too much gas to blow away."));
        Before<Smell>(() => Print("It smells like coal gas in here."));
    }
}