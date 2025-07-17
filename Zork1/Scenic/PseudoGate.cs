using Zork1.Library;
using Zork1.Rooms;

namespace Zork1.Scenic;

public class PseudoGate : Door
{
    public PseudoGate()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Adjectives = ["gate", "gates"];
        DoorTo(Get<LandOfTheDead>);
        Before(() => Print("The gate is protected by an invisible force. It makes your teeth ache to touch it."));
    }
}
