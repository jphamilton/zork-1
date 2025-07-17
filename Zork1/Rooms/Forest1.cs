using Zork1.Handlers;
using Zork1.Scenic;

namespace Zork1.Rooms;

public class Forest1 : SongBirdRoom
{
    public override void Initialize()
    {
        base.Initialize();

        Name = "Forest";
        Description = "This is a forest, with trees in all directions. To the east, there appears to be sunlight.";
        WithScenery<Tree, Songbird, WhiteHouse, Forest>();
        NorthTo<Clearing1>();
        EastTo<ForestPath>();
        SouthTo<Forest4>();
        Before<Up>(() => Print("There is no tree here suitable for climbing."));
        Before<West>(() => Print("You would need a machete to go further west."));
    }
}
