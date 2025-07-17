using Zork1.Handlers;
using Zork1.Library;
using Zork1.Scenic;
using Zork1.Things;

namespace Zork1.Rooms;

public class DomeRoom : Room
{
    public DomeRoom()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "Dome Room";
        Describe = () =>
        {
            var desc = "You are at the periphery of a large dome, which forms the ceiling of another room below. " +
            "Protecting you from a precipitous drop is a wooden railing which circles the dome.";

            if (Flags.Dome)
            {
                desc += "^^Hanging down from the railing is a rope which ends about ten feet from the floor below.";
            }

            return desc;
        };

        WithScenery<WoodenRailing>();

        WestTo<EngravingsCave>();
        DownTo(() => Flags.Dome ? Get<TorchRoom>() : NoGo("You cannot go down without fracturing many bones."));

        Before<Kiss>(() => Print("No."));
        Before<Enter>(() =>
        {
            if (Flags.Dead)
            {
                var torch_room = Get<TorchRoom>();
                Print("As you enter the dome you feel a strong pull as if from a wind drawing you over the railing and down.");
                return GoTo(torch_room);
            }

            return false;
        });

        Before<Dive>(() => JigsUp("I'm afraid that the leap you attempted has done you in."));
    }
}
