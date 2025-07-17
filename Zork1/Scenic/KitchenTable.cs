using Zork1.Library;
using Zork1.Things;

namespace Zork1.Scenic;

public class KitchenTable : Supporter
{
    public KitchenTable()
    {
        Capacity = 50;
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "kitchen table";
        Adjectives = ["table", "kitchen"];
        IsHere<BrownSack>();
        IsHere<GlassBottle>();
    }
}
