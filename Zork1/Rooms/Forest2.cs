using Zork1.Handlers;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class Forest2 : SongBirdRoom
{
    public override void Initialize()
    {
        base.Initialize();

        Name = "Forest";
        Description = "This is a dimly lit forest, with large trees all around.";
        WithScenery<Tree, Songbird, WhiteHouse, Forest>();
        SouthTo<Clearing2>();
        WestTo<ForestPath>();
        EastTo<Forest3>();
        Before<Up>(() => Print("There is no tree here suitable for climbing."));
        Before<North>(() => Print("The forest becomes impenetrable to the north."));
    }
}
