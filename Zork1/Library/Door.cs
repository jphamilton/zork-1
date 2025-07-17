using Zork1.Handlers;

namespace Zork1.Library;

public abstract class Door : Room
{
    private Func<Room> _doorTo;
    private Func<Direction> _doorDirection;

    protected Door()
    {
        Openable = true;
        Door = true;

        Before<Enter>(() =>
        {
            if (_doorDirection != null)
            {
                var dir = _doorDirection();
                return dir.Handler();
            }
            return false;
        });
    }

    public string WhenOpen { get; set; }

    // override default "The door is closed." message
    public string WhenClosed { get; set; }

    public bool TryDisplay(out string message)
    {
        message = null;

        if (WhenOpen != null && Open)
        {
            message = $"^{WhenOpen}";
        }
        else if (WhenClosed != null && !Open)
        {
            message = $"^{WhenClosed}";
        }

        return message != null;
    }

    public void DoorTo(Func<Room> action)
    {
        _doorTo = action;
    }

    public Room DoorTo()
    {
        return _doorTo();
    }

    public Direction DoorDirection()
    {
        if (_doorDirection != null)
        {
            return _doorDirection();
        }

        return null;
    }

    public void DoorDirection(Func<Direction> action)
    {
        _doorDirection = action;
    }

    protected T Direction<T>() where T : Direction
    {
        return Routines.Get<T>();
    }

    public Room GetOtherSide()
    {
        if (!Locked && Open)
        {
            return _doorTo();
        }

        if (_doorDirection() is Down)
        {
            Print($"You are unable to descend by the {Name}.");
        }
        else if (_doorDirection() is Up)
        {
            Print($"You are unable to ascend by the {Name}.");
        }
        else if (_doorDirection() != null)
        {
            Print($"The {Name} is closed.");
            SetLast.Object(this);
        }
        else
        {
            string lead = PluralName ? "leads" : "lead";
            Print($"You can't since the {Name} {lead} to nowhere.");
        }

        return null;
    }

    protected bool OpenOrClose(string openMsg, string closeMsg)
    {
        if (Verb is Open)
        {
            if (Open)
            {
                Output.Print(Tables.Dummy.Pick());
            }
            else
            {
                Output.Print(openMsg);
                Open = true;
            }

            return true;
        }

        if (Verb is not Close)
        {
            return false;
        }

        if (Open)
        {
            Output.Print(closeMsg);
            Open = false;
        }
        else
        {
            Output.Print(Tables.Dummy.Pick());
        }

        return true;
    }
}