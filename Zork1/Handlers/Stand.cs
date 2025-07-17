using Zork1.Library;
using Zork1.Library.Things;

namespace Zork1.Handlers;

public class Stand : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        if (Player.Parent.Vehicle)
        {
            return Redirect.To<Disembark>(Player.Parent);
        }

        return Print("You are already standing, I think.");
    }
}