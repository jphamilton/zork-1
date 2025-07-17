using Zork1.Handlers;
using Zork1.Library;

namespace Zork1.Scenic;

public abstract class FakeDoor : Object
{
    protected FakeDoor()
    {
        Scenery = true;
        Door = true;
    }

    protected static bool FakeDoorAction()
    {
        if (Verb is Open)
        {
            return Print("The door cannot be opened.");
        }

        if (Verb is Burn)
        {
            return Print("You cannot burn this door.");
        }

        if (Verb is Poke)
        {
            return Print(Tables.Door.Pick());
        }

        if (Verb is LookBehind)
        {
            return Print("It won't open.");
        }

        return false;
    }
}