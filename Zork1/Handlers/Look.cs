using Zork1.Library;
using Zork1.Things;

namespace Zork1.Handlers;

public class Look : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        CurrentRoom.Look(true);
        return true;
    }
}