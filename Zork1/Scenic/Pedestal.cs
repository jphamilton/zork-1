using Zork1.Handlers;
using Zork1.Library;
using Zork1.Things;

namespace Zork1.Scenic;

public class Pedestal : Supporter
{
    public Pedestal()
    {
        Capacity = 30;
        Open = true;
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "pedestal";
        Adjectives = ["pedestal", "white", "marble"];
        IsHere<Torch>();
        Before<Examine>(() => Print($"It looks pretty much like a {Name}."));
        Before<Insert>(() => Second == this && Print("You can't. I guess the pedestal wasn't intended to be used that way."));
    }
}
