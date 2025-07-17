using Zork1.Library;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class MachineRoom : Room
{
    public MachineRoom()
    {
        DryLand = true;
    }

    public override void Initialize()
    {
        Name = "Machine Room";
        Describe = () =>
        {
            var machine = Get<Machine>();
            var state = machine.Open ? "open" : "closed";
            return "This is a large, cold room whose sole exit is to the north. In one corner there is a " +
            "machine which is reminiscent of a clothes dryer. On its face is a switch which is labelled ~START~. " +
            "The switch does not appear to be manipulable by any human hand (unless the fingers are about 1/16 by 1/4 inch). " +
            $"On the front of the machine is a large lid, which is {state}.";
        };
        WithScenery<Machine, Switch>();
        NorthTo<DraftyRoom>();
    }
}
