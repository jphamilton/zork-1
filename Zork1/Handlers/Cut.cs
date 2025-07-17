using Zork1.Library;

namespace Zork1.Handlers;

public class Cut : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        if (noun.Animate)
        {
            return Redirect.To<Attack>(noun, second);
        }

        if (noun.Flammable && second.Weapon)
        {
            noun.Remove();
            return Print($"Your skillful {second}smanship slices the {noun} into innumerable slivers which blow away.");
        }

        if (!second.Weapon)
        {
            return Print($"The ~cutting edge~ of a {second} is hardly adequate.");
        }

        return Print($"Strange concept, cutting the {noun}....");
    }
}