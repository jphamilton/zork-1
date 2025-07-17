using Zork1.Handlers;
using Zork1.Library;
using Zork1.Things;

namespace Zork1.Scenic;

public class Mailbox : Container
{
    public Mailbox()
    {
        Openable = true;
        Open = false;
        Capacity = 10;
        TryTake = true;
    }

    public override void Initialize()
    {
        Name = "small mailbox";
        Adjectives = ["mailbox", "small"];
        IsHere<Advertisement>();
        Before<Take>(() => Print("It is securely anchored."));
    }
}
