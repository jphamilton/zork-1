using Zork1.Library;

namespace Zork1.Handlers;

public class Dive : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        if (noun != null)
        {
            if (Location.Has(noun))
            {
                if (noun.Animate)
                {
                    return Print($"The {noun} is too big to jump over.");
                }

                return Redirect.To<Jump>();
            }

            return Print("That would be a good trick.");
        }

        return Redirect.To<Jump>();
    }
}