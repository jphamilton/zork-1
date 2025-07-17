using Zork1.Library;

namespace Zork1.Handlers;

public class Unscript : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        return Output.StopScripting();
    }
}
