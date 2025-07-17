using Zork1.Library;

namespace Zork1.Handlers;

public class Examine : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        if (noun.Text != null)
        {
            return Print(noun.Text);
        }

        if (noun is Container || noun is Door)
        {
            return Redirect.To<LookIn>(noun);
        }

        return Print($"There's nothing special about the {noun}.");
    }
}