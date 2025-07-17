using Zork1.Library;
using Zork1.Library.Things;
using Zork1.Things;

namespace Zork1.Handlers;

public class PumpUp : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        if (second != null && second is not AirPump)
        {
            return Print($"Pump it up with a {second}?");
        }

        if (Player.Has<AirPump>())
        {
            return Redirect.To<Inflate>(noun, Get<AirPump>());
        }

        return Print("It's really not clear how.");
    }
}
