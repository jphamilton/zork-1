using Zork1.Handlers;

namespace Zork1.Scenic;

public abstract class Wall : Object
{
    protected Wall()
    {
        Before(Handler);
    }

    private bool Handler()
    {
        if (Verb is Climb || Verb is ClimbUp || Verb is ClimbDown || Verb is ClimbOn)
        {
            return Print("Climbing the walls is to no avail.");
        }

        return false;
    }
}
