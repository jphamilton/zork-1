using Zork1.Library;

namespace Zork1.Handlers;

public class LookOn : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        if (noun.Animate)
        {
            return Print("There is nothing special to be seen.");
        }

        if (noun is Supporter supporter)
        {
            var desc = Describer.Object(supporter);
            desc ??= $"The {supporter} is empty.";
            return Print(desc);
        }

        return Print($"Look on a {noun}???");
    }
}