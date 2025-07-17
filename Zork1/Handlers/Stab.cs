using Zork1.Library;
using Zork1.Library.Things;

namespace Zork1.Handlers;

public class Stab : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        var weapon = Player.Children.Where(x => x.Weapon).FirstOrDefault();
        if (weapon != null)
        {
            return Redirect.To<Attack>(noun, weapon);
        }

        return Print($"No doubt you propose to stab the {noun} with your pinky?");
    }
}