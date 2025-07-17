using Zork1.Library;

namespace Zork1.Handlers;

public class Strike : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        if (noun.Animate)
        {
            return Print($"Since you aren't versed in hand-to-hand combat, you'd better attack the {noun} with a weapon.");
        }

        return Redirect.To<SwitchOn>(noun);
    }
}