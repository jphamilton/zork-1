using Zork1.Library;

namespace Zork1.Handlers;

public class Swing : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        if (second == null)
        {
            return Print("Whoosh!");
        }

        return Redirect.To<Attack>(noun, second);
    }
}