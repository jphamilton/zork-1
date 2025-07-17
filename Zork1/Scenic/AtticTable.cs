using Zork1.Library;
using Zork1.Things;

namespace Zork1.Scenic;

public class AtticTable : Supporter
{
    public AtticTable()
    {
        Capacity = 40;
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "table";
        IsHere<NastyKnife>();
    }
}
