using Zork1.Handlers;
using Zork1.Rooms;

namespace Zork1.Scenic;

public class StoneBarrowOb : Object
{
    public StoneBarrowOb()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "stone barrow";
        Adjectives = ["massive", "stone", "barrow", "tomb"];
        Before<Enter>(() => GoTo<InsideTheBarrow>());
    }
}
