using Zork1.Handlers;
using Zork1.Library;
using Zork1.Scenic;
using Zork1.Things;

namespace Zork1.Rooms;

public class Clearing1 : AboveGround
{
    private Grating grating => Get<Grating>();
    private PileOfLeaves leaves => Get<PileOfLeaves>();

    public override void Initialize()
    {
        Name = "Clearing";
        WithScenery<WhiteHouse, Grating>();
        IsHere<PileOfLeaves>();

        Describe = () =>
        {
            var desc = "You are in a clearing, with a forest surrounding you on all sides. A path leads south.";

            if (grating.Open)
            {
                desc += "^^There is an open grating, descending into darkness.";
            }
            else if (leaves.Moved)
            {
                desc += "^^There is a grating securely fastened into the ground.";
            }

            return desc;
        };

        DownTo(() =>
        {
            if (leaves.Moved)
            {
                if (grating.Open)
                {
                    return Get<GratingRoom>();
                }

                Print("The grating is closed!");
                SetLast.Object(grating);
                return this;
            }

            Print("You can't go that way.");

            return this;
        });

        SouthTo<ForestPath>();
        WestTo<Forest1>();
        EastTo<Forest2>();

        Before<North>(() => "The forest becomes impenetrable to the north.");
    }
}
