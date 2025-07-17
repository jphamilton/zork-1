using Zork1.Handlers;
using Zork1.Library;
using Zork1.Library.Extensions;

namespace Zork1.Rooms;

public class Forest : Room
{
    private List<Room> ForestAround = [];

    public Forest()
    {
        Scenery = true;
    }

    public override void Initialize()
    {
        Name = "forest";
        Adjectives = ["forest", "trees", "pines", "hemlocks"];
        Before<Find>(() => Print("You cannot see the forest for the trees."));
        Before<Listen>(() => Print("The pines and the hemlocks seem to be murmuring."));
        Before<WalkAround>(() => ForestAround.GoNext());
        Before<Disembark>(() => Print("You will have to specify a direction."));
        ForestAround = [
            Get<Forest1>(),
            Get<Forest2>(),
            Get<Forest4>(),
            Get<ForestPath>(),
            Get<Clearing2>(),
        ];
    }
}