using Zork1.Library;

namespace Zork1.Handlers;

public class Wait : Sub
{
    public override bool Handler(Object noun, Object second)
    {
        // wait 3 turns unless a queued routine is run
        Print("Time passes...");
        var turns = 3;

        while (turns > 0)
        {
            turns--;

            if (Clock.Run(false))
            {
                break;
            }
        }

        Clock.Wait = true;

        return true;
    }
}
