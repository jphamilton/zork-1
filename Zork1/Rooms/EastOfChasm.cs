using Zork1.Library;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class EastOfChasm : Room
{
    public EastOfChasm()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "East of Chasm";
        Description = "You are on the east edge of a chasm, the bottom of which cannot be seen. A narrow passage goes north, and the path you are on continues to the east.";
        WithScenery<PseudoChasm>();
        DownTo(() =>
        {
            Print("The chasm probably leads straight to the infernal regions.");
            return this;
        });
        EastTo<Gallery>();
        NorthTo<Cellar>();
    }
}