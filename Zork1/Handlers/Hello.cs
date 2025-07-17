using Zork1.Library;

namespace Zork1.Handlers;

public class Hello : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        if (noun != null)
        {
            if (noun.Animate)
            {
                return Print($"The {noun} bows his head to you in greeting.");
            }

            return Print($"It's a well known fact that only schizophrenics say ~Hello~ to a {noun}.");
        }

        return Print(Tables.Hello.Pick());
    }
}
